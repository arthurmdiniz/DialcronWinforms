# DialcronWinforms - Guia de Configuração

## Pré-requisitos

- Windows 10/11
- [.NET 10 SDK](https://dotnet.microsoft.com/download)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) ou [VS Code](https://code.visualstudio.com/)
- Git

> Este projeto é um aplicativo Windows Forms; ele depende do .NET para Windows e não é executado nativamente em Linux/macOS.

## 1. Clonar o repositório

```bash
git clone https://github.com/arthurmdiniz/DialcronWinforms.git
cd DialcronWinforms
```

## 2. Abrir o projeto

### Visual Studio (recomendado)

- Abra o arquivo `DialcronWinforms.sln`
- Restaure os pacotes ao abrir a solução
- Pressione `F5` para rodar

### VS Code

- Abra a pasta do projeto
- Instale a extensão **C# Dev Kit**
- Selecione a solução e use o debug do .NET

## 3. Restaurar dependências

```bash
dotnet restore
```

## 4. Compilar

```bash
dotnet build
```

## 5. Executar

```bash
dotnet run --project DialcronWinforms.csproj
```

Ou, no Visual Studio, execute a solução diretamente.

## Convenções de código

- Indentação: tabs em arquivos `.cs`
- Models: substantivos no singular (`Cliente`, `Servico`)
- DAOs: `{NomeModel}DAO` (`ClienteDAO`, `ServicoDAO`)
- Métodos CRUD: `GetAllAsync`, `GetByIdAsync`, `InsertAsync`, `UpdateAsync`, `DeleteAsync`
- Propriedades: `PascalCase`
- Variáveis locais: `camelCase`
- Campos privados: `_camelCase`

## Banco de dados

- Banco: SQLite
- Seed oficial: `Documentacao/DialcronSB_PADRAO.db`
- Banco de trabalho: criado automaticamente no primeiro uso na pasta de execução
- Para resetar, apague o arquivo do banco e reinicie a aplicação
- Backup e restore: disponíveis pela tela principal do sistema

## Testes

```bash
dotnet test --nologo
```

## Fluxo de contribuição

### Padrão de branches

Use nomes no formato:

- `DWF-1`
- `DWF-42`

### Recomendação de fluxo

1. Crie uma branch para a issue ou tarefa
2. Desenvolva e teste localmente
3. Abra um Pull Request usando o template do repositório
4. Solicite revisão e faça merge com a branch principal conforme o padrão do projeto

## Documentação adicional

- [README.md](README.md)
- [Documentacao/CriacaoDeTelas.md](Documentacao/CriacaoDeTelas.md)
- [Documentacao/TestesUnitarios.md](Documentacao/TestesUnitarios.md)
- [Documentacao/GitFlow.md](Documentacao/GitFlow.md)
