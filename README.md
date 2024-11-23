# EnergyKids API

## Integrantes do grupo:
Carlos Flores - RM 97528

Kaique Gabriel Toschi - RM 551165

Vinícius Ariel Monteiro Teixeira - RM 98839

(todos da 2TDSPX)

## Breve Descrição da Solução Proposta

A **EnergyKids API** foi desenvolvida como parte de uma solução tecnológica para promover o consumo sustentável de energia elétrica, especialmente no ambiente doméstico. 

O projeto inclui as seguintes funcionalidades:
- Gestão de dispositivos elétricos.
- Estimativa de consumo elétrico mensal.
- Geração de dicas personalizadas para economia de energia.

A solução foi projetada com foco em:
- **Escalabilidade:** Estruturada para facilitar a integração com outros sistemas.
- **Modularidade:** Organizada em componentes reutilizáveis.
- **Banco de Dados Relacional:** Utiliza Oracle como base para armazenamento confiável das informações.

---

## Benefícios para o Negócio

1. **Consumo Consciente**  
   A API auxilia usuários no monitoramento e redução do consumo de energia elétrica por meio de sugestões práticas e personalizadas.

2. **Automatização de Processos**  
   Com estimativas automáticas do consumo mensal de dispositivos elétricos, os usuários recebem dicas práticas para ajustar seu consumo.

3. **Sustentabilidade**  
   Incentiva práticas de consumo consciente, alinhadas às metas globais de sustentabilidade, promovendo o uso eficiente de energia.

4. **Escalabilidade**  
   Projetada para suportar novas funcionalidades, como:
   - Integração com novos serviços.
   - Implementação de análise preditiva usando Inteligência Artificial para prever o consumo futuro.

---


## Scripts do Azure CLI para a Criação dos Recursos em Nuvem

Abaixo estão os comandos do Azure CLI utilizados para a criação dos recursos necessários na nuvem para a implementação da **EnergyKids API**.

### 1. Criar um Grupo de Recursos
```bash
az group create --name rg-energykids --location eastus
```

### 2. Criando um Plano de serviços
```bash
az appservice plan create --name appservice-energykids-plan --resource-group rg-energykids --sku F1 --is-linux
```
### 3. Criar o Serviço de Aplicativo
```bash
az webapp create --name energykids-api --resource-group rg-energykids --plan appservice-energykids-plan --runtime "DOTNETCORE:8.0"
```

### 4. Configurar a Conexão com o Banco de Dados
```bash
az webapp config connection-string set --name energykids-api --resource-group rg-energykids --settings "DefaultConnection=<string_de_conexão>" --connection-string-type SQLAzure
```

### 5. Configurar Variáveis de Ambiente
```bash
az webapp config appsettings set --name energykids-api --resource-group rg-energykids --settings "ASPNETCORE_ENVIRONMENT=Production"
```

---

## Arquivo YAML para a criação da Pipeline:

```bash
trigger:
  branches:
    include:
      - main

pool:
  vmImage: 'ubuntu-latest'

variables:
  buildConfiguration: 'Release'
  azureSubscription: 'conexao-energykids'
  webAppName: 'energykids'
  resourceGroup: 'rg-energykids'

stages:
  - stage: Build
    displayName: 'Build and Test Stage'
    jobs:
      - job: Build
        displayName: 'Compilar, Testar e Publicar Artefatos'
        steps:
          - task: UseDotNet@2
            inputs:
              packageType: 'sdk'
              version: '8.x' 

          - task: DotNetCoreCLI@2
            inputs:
              command: 'restore'
              projects: '**/*.csproj'

          - task: DotNetCoreCLI@2
            inputs:
              command: 'build'
              arguments: '--configuration $(buildConfiguration)'
              projects: '**/*.csproj'

          - task: DotNetCoreCLI@2
            inputs:
              command: 'test'
              arguments: '--configuration $(buildConfiguration) --no-build --logger trx'
              projects: '**/*Tests/*.csproj'
            
          - task: PublishTestResults@2
            inputs:
              testResultsFiles: '**/*.trx'
              testRunTitle: 'Resultados dos Testes Unitários'
              mergeTestResults: true

          - task: DotNetCoreCLI@2
            inputs:
              command: 'publish'
              arguments: '--configuration $(buildConfiguration) --output $(Build.ArtifactStagingDirectory)'
              projects: '**/*.csproj'

          - task: PublishBuildArtifacts@1
            inputs:
              pathToPublish: '$(Build.ArtifactStagingDirectory)'
              artifactName: 'drop'
              publishLocation: 'Container'

  - stage: Deploy
    displayName: 'Deploy Stage'
    dependsOn: Build
    jobs:
      - deployment: DeployWebApp
        displayName: 'Deploy para o App Service'
        environment: 'production'
        strategy:
          runOnce:
            deploy:
              steps:
                - download: current
                  artifact: drop

                - task: AzureWebApp@1
                  inputs:
                    azureSubscription: '$(azureSubscription)'
                    appName: '$(webAppName)'
                    package: '$(Pipeline.Workspace)/drop/*'
                    runtimeStack: 'DOTNETCORE|8.0'

                - task: AzureCLI@2
                  inputs:
                    azureSubscription: '$(azureSubscription)'
                    scriptType: 'bash'
                    scriptLocation: 'inlineScript'
                    inlineScript: |
                      az webapp update --resource-group $(resourceGroup) --name $(webAppName) --https-only true
                      echo "Configuração HTTPS realizada com sucesso"
```