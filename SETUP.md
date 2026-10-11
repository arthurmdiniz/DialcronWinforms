# DialcronWinforms - Guia de Configuracao

## Pre-requisitos

- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) (recomendado) ou [VS Code](https://code.visualstudio.com/)
- Git

## Como configurar o ambiente

### 1. Clonar o repositorio

```bash
git clone <url-do-repositorio>
cd DialcronWinforms
```

### 2. Abrir o projeto

#### Visual Studio (recomendado)
- Abrir `DialcronWinforms.sln`

#### VS Code
- Abrir a pasta do projeto
- Instalar extensao **C# Dev Kit**
- F5 para compilar e debugar

### 3. Restaurar pacotes NuGet

```bash
dotnet restore
```

### 4. Compilar

```bash
dotnet build
```

### 5. Executar

```bash
dotnet run
```

## Estrutura do projeto

```
Models/          # Classes de dominio (9 entidades)
Data/
  ├── Database.cs     # Conexao SQLite (singleton)
  └── DAO/            # Data Access Objects
Forms/           # Telas do Windows Forms
Resources/       # Seed do banco + logo
Cores.cs         # Paleta de cores
```

## convencoes de codigo

- Indentacao: tabs (`.cs`)
- Models: substantivos no singular (`Cliente`, `Servico`)
- DAOs: `{NomeModel}DAO` (`ClienteDAO`, `ServicoDAO`)
- Metodos CRUD: `GetAllAsync`, `GetByIdAsync`, `InsertAsync`, `UpdateAsync`, `DeleteAsync`
- Propriedades: PascalCase
- Variaveis locais: camelCase
- Privados: `_camelCase` com underscore

## Banco de Dados

- SQLite com 9 tabelas (`cad_*` e `bel_*`)
- Seed original: `Documentacao/DialcronSB_PADRAO.db` (versionado, imutavel)
- Banco de trabalho: criado automaticamente no primeiro uso ao lado do .exe
- Para resetar: apague o banco de trabalho e reinicie o app
- Backup: botao na tela principal (VACUUM INTO)

## Como contribuir

### Padrão de branches

Formato: `DWF-[numero-da-issue]`

Exemplos:
- `DWF-1` - Issue 1
- `DWF-2` - Issue 2

### Passos

1. Crie uma branch a partir da issue: `git checkout -b DWF-1`
2. Desenvolva e teste
3. Abra um Pull Request usando o template do repositório
4. Após aprovado, faça merge usando o template de merge
