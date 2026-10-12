# DialcronWinforms

Sistema de agendamentos para salao de beleza, desenvolvido em C# Windows Forms (.NET 10). Mapeado a partir do banco Dialcron3 (MySQL).

## Sobre o projeto

Aplicativo desktop para gerenciamento de agendamentos de salao de beleza, com cadastro de clientes, servicos, profissionais, unidades e agenda com calendario visual.

## Stack tecnológica

| Componente | Tecnologia |
|------------|------------|
| Framework | Windows Forms (.NET 10) |
| Arquitetura | Code-behind + DAO (2 camadas) |
| ORM | sqlite-net-pcl |
| Banco | SQLite |
| Linguagem | C# |

## Como iniciar

1. **Configuracao do ambiente**: veja [SETUP.md](SETUP.md)
2. **Criacao de telas**: veja [Documentacao/CriacaoDeTelas.md](Documentacao/CriacaoDeTelas.md)
3. **Documentacao**: veja [Documentacao/](Documentacao/)

## Estrutura do projeto

```
Models/          # Classes de dominio (9 entidades)
Data/
  ├── Database.cs     # Conexao SQLite (singleton)
  └── DAO/            # Data Access Objects
Forms/           # MainForm (janela principal com menu lateral)
Controls/        # Telas (UserControls) carregadas no painel principal
Navigation/      # NavigationHelper: troca de telas no painel
Resources/
  ├── Icones/    # Icones do projeto (favicon usado no exe e na janela)
  └── Logos/     # Logos usados na interface
Documentacao/    # Documentos e referencias
Cores.cs         # Paleta de cores
```

## Funcionalidades

- Cadastro de clientes (CRUD + busca)
- Cadastro de servicos (nome, preco, duracao)
- Cadastro de profissionais
- Cadastro de unidades
- Atendimento com calendario visual
- Backup e restore do banco de dados

## Paleta de cores

A identidade visual utiliza a paleta definida em `Cores.cs`:

| Chave | Cor (HEX) | Finalidade |
|-------|-----------|------------|
| Primary | `#8E3B52` | Cor principal |
| Secondary | `#F5E8E5` | Cor secundaria |
| Tertiary | `#C77C8A` | Destaques |
| Creme | `#FFF8F5` | Fundo claro |
| Sucesso | `#72A68A` | Estados positivos |
| Atencao | `#D6A84F` | Alertas |
| Erro | `#C95C62` | Erros |

## Banco de Dados

- SQLite com 9 tabelas (`cad_*` e `bel_*`)
- Seed original: `Documentacao/DialcronSB_PADRAO.db`
- Banco de trabalho: criado automaticamente no primeiro uso
- Backup: botao na tela principal (VACUUM INTO)

## Licenca

Veja [LICENSE](LICENSE)
