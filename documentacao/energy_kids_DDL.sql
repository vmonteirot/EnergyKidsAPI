CREATE TABLE Usuario (
    usuario_id INTEGER PRIMARY KEY,
    nome VARCHAR2(100) NOT NULL,
    email VARCHAR2(100) UNIQUE NOT NULL,
    senha_hash VARCHAR2(255) NOT NULL,
    data_cadastro DATE DEFAULT SYSDATE
);

CREATE TABLE Dispositivo (
    dispositivo_id INTEGER PRIMARY KEY,
    nome_dispositivo VARCHAR2(100) NOT NULL,
    potencia_watts NUMBER(5,2) NOT NULL,
    horas_uso_diario NUMBER(4,2) NOT NULL,
    usuario_id INTEGER NOT NULL,
    CONSTRAINT fk_usuario_dispositivo FOREIGN KEY (usuario_id) REFERENCES Usuario(usuario_id)
);

CREATE TABLE Consumo (
    consumo_id INTEGER PRIMARY KEY,
    data_registro DATE DEFAULT SYSDATE,
    consumo_mensal_kwh NUMBER(6,2) NOT NULL,
    dispositivo_id INTEGER NOT NULL,
    CONSTRAINT fk_dispositivo_consumo FOREIGN KEY (dispositivo_id) REFERENCES Dispositivo(dispositivo_id)
);

CREATE TABLE DicaEconomia (
    dica_id INTEGER PRIMARY KEY,
    texto_dica CLOB NOT NULL,
    categoria VARCHAR2(50),
    relevancia VARCHAR2(20)
);

CREATE TABLE Auditoria (
    audit_id INTEGER PRIMARY KEY,
    tabela VARCHAR2(50) NOT NULL,
    operacao VARCHAR2(10) NOT NULL,
    data TIMESTAMP DEFAULT SYSTIMESTAMP,
    usuario_id INTEGER,
    descricao CLOB
);