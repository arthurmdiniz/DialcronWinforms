-- ============================================
-- Dialcron - Schema SQLite
-- Mapeado a partir do banco Dialcron3 (MySQL)
-- ============================================

PRAGMA foreign_keys = ON;

-- ============================================
-- TABELAS GLOBAIS (compartilhadas entre segmentos)
-- ============================================

-- Unidade (filial/estabelecimento)
CREATE TABLE IF NOT EXISTS cad_unidade (
    id_unidade      INTEGER PRIMARY KEY AUTOINCREMENT,
    nome_fantasia   TEXT,
    razao_social    TEXT,
    cnpj            TEXT,
    insc_estadual   TEXT,
    insc_municipal  TEXT,
    cep             INTEGER,
    logradouro      TEXT,
    numero          INTEGER,
    bairro          TEXT,
    complemento     TEXT,
    municipio       TEXT,
    uf              TEXT,
    pais            TEXT,
    email           TEXT,
    ddd             INTEGER,
    telefone        INTEGER,
    cliente         INTEGER,
    FOREIGN KEY (cliente) REFERENCES cad_cliente(cliente)
);

-- Cliente
CREATE TABLE IF NOT EXISTS cad_cliente (
    cliente        INTEGER PRIMARY KEY AUTOINCREMENT,
    nome           TEXT,
    logradouro     TEXT,
    numero         INTEGER,
    cpf_cnpj       TEXT,
    dta_nascimento TEXT,            -- DATE
    dta_criacao    TEXT,            -- DATE
    ddd_telefone   INTEGER,
    telefone       INTEGER,
    ddd_celular    INTEGER,
    celular        INTEGER,
    email          TEXT,
    sexo           TEXT             -- M/F
);

-- Usuario do sistema
CREATE TABLE IF NOT EXISTS cad_usuario (
    id             INTEGER PRIMARY KEY AUTOINCREMENT,
    login          TEXT,
    senha          TEXT,
    nome           TEXT,
    perfil         TEXT,
    email          TEXT,
    grupo          INTEGER,
    ativo          TEXT NOT NULL DEFAULT 'S',
    dta_criacao    TEXT,            -- DATE
    dta_inativacao TEXT             -- DATE
);

-- Atendimento (registro global do agendamento/registro)
CREATE TABLE IF NOT EXISTS cad_atendimento (
    id                   INTEGER PRIMARY KEY AUTOINCREMENT,
    unidade              INTEGER NOT NULL,
    cliente              INTEGER,
    descricao            TEXT,
    situacao             TEXT,
    dta_criacao          TEXT,            -- DATETIME
    dta_encerramento     TEXT,            -- DATETIME
    usuario_criacao      INTEGER,
    usuario_encerramento INTEGER,
    FOREIGN KEY (unidade) REFERENCES cad_unidade(id_unidade),
    FOREIGN KEY (cliente) REFERENCES cad_cliente(cliente),
    FOREIGN KEY (usuario_criacao) REFERENCES cad_usuario(id),
    FOREIGN KEY (usuario_encerramento) REFERENCES cad_usuario(id)
);

-- ============================================
-- TABELAS SEGMENTO SALAO (bel_*)
-- ============================================

-- Servico do salao
CREATE TABLE IF NOT EXISTS bel_servico (
    id              INTEGER PRIMARY KEY AUTOINCREMENT,
    unidade         INTEGER NOT NULL,
    nome            TEXT NOT NULL,
    preco           REAL NOT NULL DEFAULT 0,
    duracao_minutos INTEGER NOT NULL DEFAULT 30,
    ativo           TEXT NOT NULL DEFAULT 'S',
    FOREIGN KEY (unidade) REFERENCES cad_unidade(id_unidade)
);

-- Profissional do salao
CREATE TABLE IF NOT EXISTS bel_profissional (
    id             INTEGER PRIMARY KEY AUTOINCREMENT,
    unidade        INTEGER NOT NULL,
    nome           TEXT NOT NULL,
    especialidade  TEXT,
    ddd_telefone   INTEGER,
    telefone       INTEGER,
    ddd_celular    INTEGER,
    celular        INTEGER,
    ddd_outros     INTEGER,
    telefone_outros INTEGER,
    ativo          TEXT NOT NULL DEFAULT 'S',
    FOREIGN KEY (unidade) REFERENCES cad_unidade(id_unidade)
);

-- Atendimento do salao (campos especificos do segmento)
CREATE TABLE IF NOT EXISTS bel_atendimento (
    id              INTEGER PRIMARY KEY AUTOINCREMENT,
    atendimento     INTEGER NOT NULL,
    profissional    INTEGER NOT NULL,
    dta_atendimento TEXT NOT NULL,      -- DATETIME do atendimento
    dta_criacao     TEXT DEFAULT (datetime('now')),
    dta_encerramento TEXT,
    situacao        TEXT NOT NULL DEFAULT 'a',  -- a=agendado, c=cancelado, v=confirmado, f=concluido, n=nao_compareceu
    valor           REAL NOT NULL DEFAULT 0,
    pago            INTEGER NOT NULL DEFAULT 0, -- 0=nao pago, 1=pago
    observacao      TEXT,
    FOREIGN KEY (atendimento) REFERENCES cad_atendimento(id),
    FOREIGN KEY (profissional) REFERENCES bel_profissional(id)
);

-- Tabela pivoi: atendimento x servico (N:N)
CREATE TABLE IF NOT EXISTS bel_atendimento_servico (
    id          INTEGER PRIMARY KEY AUTOINCREMENT,
    atendimento INTEGER NOT NULL,
    servico     INTEGER NOT NULL,
    FOREIGN KEY (atendimento) REFERENCES bel_atendimento(id),
    FOREIGN KEY (servico) REFERENCES bel_servico(id)
);

-- Tipo de atendimento do salao
CREATE TABLE IF NOT EXISTS bel_tipo_atendimento (
    id                   INTEGER PRIMARY KEY AUTOINCREMENT,
    unidade              INTEGER NOT NULL,
    des_tipo_atendimento TEXT NOT NULL,
    ativo                TEXT NOT NULL DEFAULT 'S',
    FOREIGN KEY (unidade) REFERENCES cad_unidade(id_unidade)
);

-- ============================================
-- INDICES
-- ============================================

CREATE INDEX IF NOT EXISTS idx_cad_atendimento_unidade ON cad_atendimento(unidade);
CREATE INDEX IF NOT EXISTS idx_cad_atendimento_cliente ON cad_atendimento(cliente);
CREATE INDEX IF NOT EXISTS idx_cad_atendimento_situacao ON cad_atendimento(situacao);
CREATE INDEX IF NOT EXISTS idx_cad_atendimento_dta_criacao ON cad_atendimento(dta_criacao);
CREATE INDEX IF NOT EXISTS idx_bel_atendimento_atendimento ON bel_atendimento(atendimento);
CREATE INDEX IF NOT EXISTS idx_bel_atendimento_profissional ON bel_atendimento(profissional);
CREATE INDEX IF NOT EXISTS idx_bel_atendimento_dta ON bel_atendimento(dta_atendimento);
CREATE INDEX IF NOT EXISTS idx_bel_servico_unidade ON bel_servico(unidade);
CREATE INDEX IF NOT EXISTS idx_bel_profissional_unidade ON bel_profissional(unidade);
CREATE INDEX IF NOT EXISTS idx_bel_atendimento_servico_atendimento ON bel_atendimento_servico(atendimento);
CREATE INDEX IF NOT EXISTS idx_cad_unidade_cliente ON cad_unidade(cliente);
CREATE INDEX IF NOT EXISTS idx_bel_tipo_atendimento_unidade ON bel_tipo_atendimento(unidade);
