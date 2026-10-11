-- --------------------------------------------------------
-- Servidor:                     127.0.0.1
-- Versão do servidor:           8.0.42 - MySQL Community Server - GPL
-- OS do Servidor:               Win64
-- HeidiSQL Versão:              12.13.0.7147
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- Copiando estrutura do banco de dados para dialcron3
CREATE DATABASE IF NOT EXISTS `dialcron3` /*!40100 DEFAULT CHARACTER SET utf8mb3 */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `dialcron3`;

-- Copiando estrutura para tabela dialcron3.cad_atendimento
CREATE TABLE IF NOT EXISTS `cad_atendimento` (
  `matriz` int NOT NULL,
  `unidade` int NOT NULL,
  `atendimento` int NOT NULL,
  `dta_criacao` datetime DEFAULT NULL,
  `dta_encerramento` datetime DEFAULT NULL,
  `situacao` char(1) DEFAULT NULL,
  `cliente` int DEFAULT NULL,
  `descricao` varchar(45) DEFAULT NULL,
  `usuario_criacao` int DEFAULT NULL,
  `usuario_encerramento` int DEFAULT NULL,
  PRIMARY KEY (`matriz`,`unidade`,`atendimento`),
  KEY `cad_atendimento_cad_cliente_fk` (`cliente`),
  KEY `cad_atendimento_cad_usuario_criacao_FK` (`usuario_criacao`),
  KEY `cad_atendimento_cad_usuario_encerramento_FK` (`usuario_encerramento`),
  CONSTRAINT `cad_atendimento_cad_unidade_FK` FOREIGN KEY (`matriz`, `unidade`) REFERENCES `cad_unidade` (`matriz`, `unidade`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;

-- Copiando dados para a tabela dialcron3.cad_atendimento: ~0 rows (aproximadamente)

-- Copiando estrutura para tabela dialcron3.cad_cliente
CREATE TABLE IF NOT EXISTS `cad_cliente` (
  `cliente` int NOT NULL,
  `nome` varchar(60) DEFAULT NULL,
  `logradouro` varchar(60) DEFAULT NULL,
  `numero` int DEFAULT NULL,
  `cpf_cnpj` varchar(14) DEFAULT NULL,
  `dta_nascimento` date DEFAULT NULL,
  `dta_criacao` date DEFAULT NULL,
  `ddd_telefone` tinyint DEFAULT NULL,
  `telefone` int DEFAULT NULL,
  `ddd_celular` tinyint DEFAULT NULL,
  `email` varchar(100) DEFAULT NULL,
  `sexo` char(1) DEFAULT NULL,
  PRIMARY KEY (`cliente`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;

-- Copiando dados para a tabela dialcron3.cad_cliente: ~0 rows (aproximadamente)

-- Copiando estrutura para tabela dialcron3.cad_matriz
CREATE TABLE IF NOT EXISTS `cad_matriz` (
  `matriz` int NOT NULL AUTO_INCREMENT,
  `nome` varchar(60) NOT NULL,
  `segmento` char(3) DEFAULT NULL,
  `ativo` char(1) NOT NULL DEFAULT 'S',
  `dta_criacao` date DEFAULT (curdate()),
  PRIMARY KEY (`matriz`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Copiando dados para a tabela dialcron3.cad_matriz: ~0 rows (aproximadamente)

-- Copiando estrutura para tabela dialcron3.cad_unidade
CREATE TABLE IF NOT EXISTS `cad_unidade` (
  `matriz` int NOT NULL,
  `unidade` int NOT NULL,
  `nome_fantasia` varchar(45) DEFAULT NULL,
  `razao_social` varchar(80) DEFAULT NULL,
  `cnpj` varchar(14) DEFAULT NULL,
  `insc_estadual` varchar(45) DEFAULT NULL,
  `insc_municipal` varchar(45) DEFAULT NULL,
  `cep` int DEFAULT NULL,
  `logradouro` varchar(60) DEFAULT NULL,
  `numero` int DEFAULT NULL,
  `bairro` varchar(45) DEFAULT NULL,
  `complemento` varchar(45) DEFAULT NULL,
  `municipio` varchar(45) DEFAULT NULL,
  `uf` varchar(2) DEFAULT NULL,
  `pais` varchar(45) DEFAULT NULL,
  `email` varchar(45) DEFAULT NULL,
  `ddd` int DEFAULT NULL,
  `telefone` int DEFAULT NULL,
  `cliente` int DEFAULT NULL,
  PRIMARY KEY (`matriz`,`unidade`),
  KEY `cad_unidade_cad_cliente_fk` (`cliente`),
  CONSTRAINT `cad_unidade_cad_matriz_FK` FOREIGN KEY (`matriz`) REFERENCES `cad_matriz` (`matriz`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;

-- Copiando dados para a tabela dialcron3.cad_unidade: ~0 rows (aproximadamente)

-- Copiando estrutura para tabela dialcron3.cad_usuario
CREATE TABLE IF NOT EXISTS `cad_usuario` (
  `id` int NOT NULL,
  `login` varchar(30) DEFAULT NULL,
  `senha` varchar(100) DEFAULT NULL,
  `nome` varchar(100) DEFAULT NULL,
  `perfil` varchar(100) DEFAULT NULL,
  `email` varchar(100) DEFAULT NULL,
  `grupo` tinyint DEFAULT NULL,
  `ativo` char(1) DEFAULT NULL,
  `dta_criacao` date DEFAULT NULL,
  `dta_inativacao` date DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;

-- Copiando dados para a tabela dialcron3.cad_usuario: ~0 rows (aproximadamente)

-- Copiando estrutura para tabela dialcron3.med_agenda
CREATE TABLE IF NOT EXISTS `med_agenda` (
  `matriz` int NOT NULL,
  `unidade` int NOT NULL,
  `nro_atendimento` int NOT NULL,
  `medico` int DEFAULT NULL,
  `cliente` int DEFAULT NULL,
  `tipo_atendimento` int DEFAULT NULL,
  `convenio` int DEFAULT NULL,
  `especialidade` int DEFAULT NULL,
  `dta_agendamento` datetime DEFAULT NULL,
  `situacao` char(1) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL COMMENT 'a - agendado\r\nc - cancelado\r\nv - confirmado\r\nf - concluído\r\nn - não compareceu',
  `observacao` text,
  `usuario_criacao` int DEFAULT NULL,
  PRIMARY KEY (`matriz`,`unidade`,`nro_atendimento`),
  KEY `med_agenda_cad_unidade_fk` (`unidade`),
  KEY `med_agenda_cad_cliente_fk` (`cliente`),
  KEY `med_agenda_med_medico_fk` (`medico`),
  KEY `med_agenda_med_especialidade_fk` (`especialidade`),
  KEY `med_agenda_cad_usuario_fk` (`usuario_criacao`),
  KEY `med_agenda_medico_FK` (`matriz`,`medico`),
  KEY `med_agenda_med_tipo_atendimento_FK` (`matriz`,`tipo_atendimento`),
  KEY `med_agenda_especialidade_FK` (`matriz`,`especialidade`),
  CONSTRAINT `med_agenda_cad_atendimento_FK` FOREIGN KEY (`matriz`, `unidade`, `nro_atendimento`) REFERENCES `cad_atendimento` (`matriz`, `unidade`, `atendimento`),
  CONSTRAINT `med_agenda_especialidade_FK` FOREIGN KEY (`matriz`, `especialidade`) REFERENCES `med_especialidade` (`matriz`, `id`),
  CONSTRAINT `med_agenda_med_tipo_atendimento_FK` FOREIGN KEY (`matriz`, `tipo_atendimento`) REFERENCES `med_tipo_atendimento` (`matriz`, `id`),
  CONSTRAINT `med_agenda_medico_FK` FOREIGN KEY (`matriz`, `medico`) REFERENCES `med_medico` (`matriz`, `id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Copiando dados para a tabela dialcron3.med_agenda: ~0 rows (aproximadamente)

-- Copiando estrutura para tabela dialcron3.med_consulta
CREATE TABLE IF NOT EXISTS `med_consulta` (
  `matriz` int NOT NULL,
  `unidade` int NOT NULL,
  `nro_atendimento` int NOT NULL,
  `nro_consulta` int NOT NULL,
  `dta_consulta` date DEFAULT NULL,
  `dta_fim_consulta` date DEFAULT NULL,
  `situacao` char(1) DEFAULT NULL,
  `valor` double DEFAULT NULL,
  PRIMARY KEY (`matriz`,`unidade`,`nro_atendimento`,`nro_consulta`),
  CONSTRAINT `med_consulta_cad_atendimento_FK` FOREIGN KEY (`matriz`, `unidade`, `nro_atendimento`) REFERENCES `cad_atendimento` (`matriz`, `unidade`, `atendimento`),
  CONSTRAINT `med_consulta_med_agenda_FK` FOREIGN KEY (`matriz`, `unidade`, `nro_atendimento`) REFERENCES `med_agenda` (`matriz`, `unidade`, `nro_atendimento`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;

-- Copiando dados para a tabela dialcron3.med_consulta: ~0 rows (aproximadamente)

-- Copiando estrutura para tabela dialcron3.med_especial_medico
CREATE TABLE IF NOT EXISTS `med_especial_medico` (
  `matriz` int NOT NULL,
  `campo` int NOT NULL,
  `id_medico` int NOT NULL,
  `id_especialidade` int NOT NULL,
  PRIMARY KEY (`matriz`,`campo`),
  KEY `med_especial_medico_medico_fk` (`id_medico`),
  KEY `med_especial_medico_especialidade_fk` (`id_especialidade`),
  KEY `med_especial_medico_med_especialidade_FK` (`matriz`,`id_especialidade`),
  KEY `med_especial_medico_med_medico_FK` (`matriz`,`id_medico`),
  CONSTRAINT `med_especial_medico_med_especialidade_FK` FOREIGN KEY (`matriz`, `id_especialidade`) REFERENCES `med_especialidade` (`matriz`, `id`),
  CONSTRAINT `med_especial_medico_med_medico_FK` FOREIGN KEY (`matriz`, `id_medico`) REFERENCES `med_medico` (`matriz`, `id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Copiando dados para a tabela dialcron3.med_especial_medico: ~0 rows (aproximadamente)

-- Copiando estrutura para tabela dialcron3.med_especialidade
CREATE TABLE IF NOT EXISTS `med_especialidade` (
  `matriz` int NOT NULL,
  `id` int NOT NULL,
  `des_especialidade` varchar(30) NOT NULL,
  `ativo` char(1) NOT NULL,
  PRIMARY KEY (`matriz`,`id`),
  CONSTRAINT `med_especialidade_cad_matriz_FK` FOREIGN KEY (`matriz`) REFERENCES `cad_matriz` (`matriz`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;

-- Copiando dados para a tabela dialcron3.med_especialidade: ~0 rows (aproximadamente)

-- Copiando estrutura para tabela dialcron3.med_medico
CREATE TABLE IF NOT EXISTS `med_medico` (
  `matriz` int NOT NULL,
  `id` int NOT NULL,
  `nro_crm` int NOT NULL,
  `uf_crm` char(2) NOT NULL,
  `cliente` int NOT NULL,
  `nome` varchar(40) NOT NULL,
  `ddd_telefone` int NOT NULL DEFAULT (0),
  `telefone` int NOT NULL DEFAULT (0),
  `ddd_celular` int NOT NULL DEFAULT '0',
  `celular` int NOT NULL DEFAULT (0),
  `ddd_outros` int DEFAULT '0',
  `telefone_outros` int DEFAULT '0',
  `ativo` char(1) NOT NULL,
  PRIMARY KEY (`matriz`,`id`),
  UNIQUE KEY `med_medico_unique` (`nro_crm`,`uf_crm`),
  KEY `med_medico_cad_cliente_fk` (`cliente`),
  KEY `med_medico_matriz_idx` (`matriz`),
  CONSTRAINT `med_medico_cad_matriz_FK` FOREIGN KEY (`matriz`) REFERENCES `cad_matriz` (`matriz`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;

-- Copiando dados para a tabela dialcron3.med_medico: ~0 rows (aproximadamente)

-- Copiando estrutura para tabela dialcron3.med_tipo_atendimento
CREATE TABLE IF NOT EXISTS `med_tipo_atendimento` (
  `matriz` int NOT NULL,
  `id` int NOT NULL,
  `des_atendimento` varchar(100) NOT NULL,
  `ativo` char(1) DEFAULT NULL,
  PRIMARY KEY (`matriz`,`id`),
  CONSTRAINT `med_tipo_atendimento_cad_matriz_FK` FOREIGN KEY (`matriz`) REFERENCES `cad_matriz` (`matriz`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb3;

-- Copiando dados para a tabela dialcron3.med_tipo_atendimento: ~0 rows (aproximadamente)

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
