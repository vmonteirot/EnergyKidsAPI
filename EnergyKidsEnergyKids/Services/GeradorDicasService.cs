using System.Collections.Generic;
using EnergyKids.Models;
using EnergyKids.Factories;


namespace EnergyKids.Services
{
    public class GeradorDicasService
    {
        public List<DicaEconomia> GerarDicasComBaseNoConsumo(List<Dispositivo> dispositivos)
        {
            var dicas = new List<DicaEconomia>();

            foreach (var dispositivo in dispositivos)
            {
                // Verifica se o consumo ultrapassa um limite (ex.: 150 kWh/mês)
                double consumo = (dispositivo.Potencia / 1000) * dispositivo.HorasPorDia * 30; // kWh
                if (consumo > 150)
                {
                    dicas.Add(new DicaEconomia
                    {
                        Titulo = $"Reduza o uso de {dispositivo.Nome}",
                        Descricao = $"O dispositivo {dispositivo.Nome} consome mais de 150 kWh/mês. Tente reduzir o tempo de uso."
                    });
                }
                else
                {
                    dicas.Add(new DicaEconomia
                    {
                        Titulo = $"Consumo do {dispositivo.Nome} está em nível eficiente",
                        Descricao = $"Seu consumo está dentro de um limite aceitável. Continue assim!"
                    });
                }
            }

            return dicas;
        }
    }
}
