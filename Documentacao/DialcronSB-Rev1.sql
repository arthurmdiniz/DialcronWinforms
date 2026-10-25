-- ============================================
-- Dialcron - Schema SQLite (Revisado)
-- Gerado a partir de DialcronSBDB.db.sql (banco de testes pré-preenchido)
-- ============================================

PRAGMA foreign_keys = ON;

-- cad_unidade
CREATE TABLE IF NOT EXISTS cad_unidade (
	id_unidade	INTEGER,
	nome_fantasia	TEXT,
	razao_social	TEXT,
	cnpj	TEXT,
	insc_estadual	TEXT,
	insc_municipal	TEXT,
	cep	INTEGER,
	logradouro	TEXT,
	numero	INTEGER,
	bairro	TEXT,
	complemento	TEXT,
	municipio	TEXT,
	uf	TEXT,
	pais	TEXT,
	email	TEXT,
	ddd	INTEGER,
	telefone	INTEGER,
	cliente	INTEGER,
	PRIMARY KEY(id_unidade AUTOINCREMENT),
	FOREIGN KEY(cliente) REFERENCES cad_cliente(cliente)
);

-- cad_cliente
CREATE TABLE IF NOT EXISTS cad_cliente (
	cliente	INTEGER,
	nome	TEXT,
	logradouro	TEXT,
	numero	INTEGER,
	cpf_cnpj	TEXT,
	dta_nascimento	TEXT,
	dta_criacao	TEXT,
	ddd_telefone	INTEGER,
	telefone	INTEGER,
	ddd_celular	INTEGER,
	celular	INTEGER,
	email	TEXT,
	sexo	TEXT,
	PRIMARY KEY(cliente AUTOINCREMENT)
);

-- cad_usuario
CREATE TABLE IF NOT EXISTS cad_usuario (
	id	INTEGER,
	login	TEXT,
	senha	TEXT,
	nome	TEXT,
	perfil	TEXT,
	email	TEXT,
	grupo	INTEGER,
	ativo	TEXT NOT NULL DEFAULT 'S',
	dta_criacao	TEXT,
	dta_inativacao	TEXT,
	PRIMARY KEY(id AUTOINCREMENT)
);

-- cad_atendimento
CREATE TABLE IF NOT EXISTS cad_atendimento (
	id	INTEGER,
	unidade	INTEGER NOT NULL,
	cliente	INTEGER,
	descricao	TEXT,
	situacao	TEXT,
	dta_criacao	TEXT,
	dta_encerramento	TEXT,
	usuario_criacao	INTEGER,
	usuario_encerramento	INTEGER,
	PRIMARY KEY(id AUTOINCREMENT),
	FOREIGN KEY(cliente) REFERENCES cad_cliente(cliente),
	FOREIGN KEY(unidade) REFERENCES cad_unidade(id_unidade),
	FOREIGN KEY(usuario_criacao) REFERENCES cad_usuario(id),
	FOREIGN KEY(usuario_encerramento) REFERENCES cad_usuario(id)
);

-- bel_servico
CREATE TABLE IF NOT EXISTS bel_servico (
	id	INTEGER,
	unidade	INTEGER NOT NULL,
	nome	TEXT NOT NULL,
	preco	REAL NOT NULL DEFAULT 0,
	duracao_minutos	INTEGER NOT NULL DEFAULT 30,
	ativo	TEXT NOT NULL DEFAULT 'S',
	PRIMARY KEY(id AUTOINCREMENT),
	FOREIGN KEY(unidade) REFERENCES cad_unidade(id_unidade)
);

-- bel_profissional
CREATE TABLE IF NOT EXISTS bel_profissional (
	id	INTEGER,
	unidade	INTEGER NOT NULL,
	nome	TEXT NOT NULL,
	especialidade	TEXT,
	ddd_telefone	INTEGER,
	telefone	INTEGER,
	ddd_celular	INTEGER,
	celular	INTEGER,
	ddd_outros	INTEGER,
	telefone_outros	INTEGER,
	ativo	TEXT NOT NULL DEFAULT 'S',
	PRIMARY KEY(id AUTOINCREMENT),
	FOREIGN KEY(unidade) REFERENCES cad_unidade(id_unidade)
);

-- bel_atendimento
CREATE TABLE IF NOT EXISTS bel_atendimento (
	id	INTEGER,
	atendimento	INTEGER NOT NULL,
	profissional	INTEGER NOT NULL,
	dta_atendimento	TEXT NOT NULL,
	dta_criacao	TEXT DEFAULT (datetime('now')),
	dta_encerramento	TEXT,
	situacao	TEXT NOT NULL DEFAULT 'a',
	valor	REAL NOT NULL DEFAULT 0,
	pago	INTEGER NOT NULL DEFAULT 0,
	observacao	TEXT,
	PRIMARY KEY(id AUTOINCREMENT),
	FOREIGN KEY(atendimento) REFERENCES cad_atendimento(id),
	FOREIGN KEY(profissional) REFERENCES bel_profissional(id)
);

-- bel_atendimento_servico
CREATE TABLE IF NOT EXISTS bel_atendimento_servico (
	id	INTEGER,
	atendimento	INTEGER NOT NULL,
	servico	INTEGER NOT NULL,
	PRIMARY KEY(id AUTOINCREMENT),
	FOREIGN KEY(atendimento) REFERENCES bel_atendimento(id),
	FOREIGN KEY(servico) REFERENCES bel_servico(id)
);

-- bel_tipo_atendimento
CREATE TABLE IF NOT EXISTS bel_tipo_atendimento (
	id	INTEGER,
	unidade	INTEGER NOT NULL,
	des_tipo_atendimento	TEXT NOT NULL,
	ativo	TEXT NOT NULL DEFAULT 'S',
	PRIMARY KEY(id AUTOINCREMENT),
	FOREIGN KEY(unidade) REFERENCES cad_unidade(id_unidade)
);

-- ============================================
-- INDICES
-- ============================================

CREATE INDEX IF NOT EXISTS idx_bel_atendimento_atendimento ON bel_atendimento (
	atendimento
);;
CREATE INDEX IF NOT EXISTS idx_bel_atendimento_dta ON bel_atendimento (
	dta_atendimento
);;
CREATE INDEX IF NOT EXISTS idx_bel_atendimento_profissional ON bel_atendimento (
	profissional
);;
CREATE INDEX IF NOT EXISTS idx_bel_atendimento_servico_atendimento ON bel_atendimento_servico (
	atendimento
);;
CREATE INDEX IF NOT EXISTS idx_bel_profissional_unidade ON bel_profissional (
	unidade
);;
CREATE INDEX IF NOT EXISTS idx_bel_servico_unidade ON bel_servico (
	unidade
);;
CREATE INDEX IF NOT EXISTS idx_bel_tipo_atendimento_unidade ON bel_tipo_atendimento (
	unidade
);;
CREATE INDEX IF NOT EXISTS idx_cad_atendimento_cliente ON cad_atendimento (
	cliente
);;
CREATE INDEX IF NOT EXISTS idx_cad_atendimento_dta_criacao ON cad_atendimento (
	dta_criacao
);;
CREATE INDEX IF NOT EXISTS idx_cad_atendimento_situacao ON cad_atendimento (
	situacao
);;
CREATE INDEX IF NOT EXISTS idx_cad_atendimento_unidade ON cad_atendimento (
	unidade
);;
CREATE INDEX IF NOT EXISTS idx_cad_unidade_cliente ON cad_unidade (
	cliente
);;


