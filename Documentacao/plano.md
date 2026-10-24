# Plano de Ambiente para Desenvolvimento - DialcronWinforms

Este documento reúne o passo a passo para preparar um ambiente Windows para desenvolver, compilar e executar o projeto DialcronWinforms.

## 1. Requisitos mínimos

- Windows 10/11
- Git
- .NET SDK 10
- Visual Studio 2022 ou VS Code com extensão C#

## 2. Instalar ferramentas

### Git

```powershell
winget install Git.Git
```

### .NET SDK 10

```powershell
winget install Microsoft.DotNet.SDK.10
```

### Visual Studio 2022 (opcional, mas recomendado)

Instale o Visual Studio Community com carga de trabalho:

- Desenvolvimento para Desktop com .NET
- .NET desktop development

## 3. Clonar o repositório

```bash
git clone https://github.com/arthurmdiniz/DialcronWinforms.git
cd DialcronWinforms
```

## 4. Restaurar dependências

```bash
dotnet restore
```

## 5. Compilar

```bash
dotnet build
```

## 6. Executar a aplicação

### Via CLI

```bash
dotnet run --project DialcronWinforms.csproj
```

### Via Visual Studio

- Abra `DialcronWinforms.sln`
- Selecione a solução principal
- Pressione `F5`

## 7. Estrutura e comportamento do projeto

- O projeto usa Windows Forms (`net10.0-windows`)
- A navegação é feita por `UserControl` dentro do painel principal
- A camada de acesso a dados fica em `Data/DAO/`
- A base local é SQLite
- O seed padrão fica em `Documentacao/DialcronSB_PADRAO.db`

## 8. Banco de dados

Ao iniciar a aplicação, o sistema cria o banco de trabalho automaticamente caso ainda não exista. O arquivo de seed é copiado para o diretório de execução quando necessário.

### Observações

- Não edite o arquivo seed diretamente em produção
- Para resetar o ambiente local, apague o arquivo `DialcronSBDB.db` gerado e reinicie a aplicação
- O backup/restore pode ser feito pela interface do sistema

## 9. Validação do ambiente

Use os comandos abaixo para verificar se o setup está funcionando:

```bash
dotnet --info
dotnet restore
dotnet build
dotnet test --nologo
```

## 10. Checklist final

- [ ] Git instalado
- [ ] .NET 10 SDK instalado
- [ ] Repositório clonado
- [ ] `dotnet restore` concluído
- [ ] `dotnet build` concluído
- [ ] `dotnet test --nologo` concluído
- [ ] Aplicação executando localmente

## 11. Documentação relacionada

- [README.md](../README.md)
- [SETUP.md](../SETUP.md)
- [CriacaoDeTelas.md](CriacaoDeTelas.md)
- [TestesUnitarios.md](TestesUnitarios.md)
