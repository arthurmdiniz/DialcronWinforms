# Como criar testes unitários

Este guia descreve a abordagem atual do projeto para testes automatizados no `DialcronWinforms`. Os testes ficam no projeto `DialcronWinforms.Tests` e exercitam principalmente a camada de acesso a dados (`Data/DAO/`).

## 1. Estrutura do projeto de testes

```text
DialcronWinforms.Tests/
├── DialcronWinforms.Tests.csproj
├── Support/
│   └── SqliteTestDatabase.cs
└── Data/
    └── UnidadeDAOTests.cs
```

### Convenções

| Item | Padrão | Exemplo |
|------|--------|---------|
| Arquivo | `{Nome}DAOTests.cs` | `UnidadeDAOTests.cs` |
| Namespace | `DialcronWinforms.Tests.Data` | `namespace DialcronWinforms.Tests.Data;` |
| Classe | `{Nome}DAOTests` | `UnidadeDAOTests` |
| Método | `{Metodo}_{Cenario}_{ResultadoEsperado}` | `GetByIdAsync_ComIdInexistente_RetornaNull` |

## 2. O que testar

| Alvo | Status | Motivo |
|------|--------|--------|
| `Data/DAO` | Sim | São os pontos de lógica de persistência e mapeamento |
| `FuncoesGerais` | Sim, quando existir | Funções puras e sem dependência de UI |
| `Database` | Não | O singleton pode depender do caminho e do ambiente local |
| `Controls`/`Forms` | Não em unit tests | A validação visual e de integração é manual |

## 3. Helper de banco de testes

O projeto já inclui `SqliteTestDatabase`, que cria um arquivo SQLite temporário em `%TEMP%` para cada execução. Isso permite o isolamento entre testes sem mexer no banco real da aplicação.

```csharp
var db = await SqliteTestDatabase.CreateAsync();
await db.Connection.CreateTableAsync<Unidade>();
```

> Nunca use `DialcronSBDB.db` ou `DialcronSB_PADRAO.db` diretamente em testes automatizados.

## 4. Padrão para testes de DAO

A classe de teste implementa `IAsyncLifetime` para preparar o banco antes e limpar após cada execução.

```csharp
public class UnidadeDAOTests : IAsyncLifetime
{
    private SqliteTestDatabase _db = null!;
    private UnidadeDAO _dao = null!;

    public async Task InitializeAsync()
    {
        _db = await SqliteTestDatabase.CreateAsync();
        await _db.Connection.CreateTableAsync<Unidade>();
        _dao = new UnidadeDAO(_db.Connection);
    }

    public async Task DisposeAsync()
    {
        await _db.DisposeAsync();
    }
}
```

### Estrutura de um teste

Cada teste segue a lógica Arrange / Act / Assert.

```csharp
[Fact]
public async Task InsertAsync_ComDadosValidos_GeraIdEPersiste()
{
    var unidade = CriarUnidade("Unidade Centro");

    var linhas = await _dao.InsertAsync(unidade);

    Assert.Equal(1, linhas);
    Assert.True(unidade.IdUnidade > 0);

    var salva = await _dao.GetByIdAsync(unidade.IdUnidade);
    Assert.NotNull(salva);
    Assert.Equal("Unidade Centro", salva.NomeFantasia);
}
```

### Casos mínimos a cobrir

Para cada DAO, é recomendável testar:

- `GetAllAsync` com lista vazia e preenchida
- `InsertAsync` com dados válidos
- `GetByIdAsync` para registro existente e inexistente
- `UpdateAsync` persistindo alteração
- `DeleteAsync` removendo o registro

## 5. Exemplo de mapeamento

No projeto, o mapeamento de tabela foi validado com o nome real do schema SQLite:

```csharp
[Fact]
public async Task Mapeamento_UsaTabelaCadUnidade()
{
    var count = await _db.Connection.ExecuteScalarAsync<int>(
        "SELECT COUNT(*) FROM sqlite_master WHERE type = 'table' AND name = 'cad_unidade'");

    Assert.Equal(1, count);
}
```

## 6. Como rodar os testes

Na raiz do projeto:

```bash
dotnet test --nologo
```

Ou diretamente no projeto de testes:

```bash
dotnet test DialcronWinforms.Tests/DialcronWinforms.Tests.csproj --nologo
```

## 7. Checklist antes de entregar

- [ ] Arquivo de teste criado em `DialcronWinforms.Tests/Data/`
- [ ] Uso do helper `SqliteTestDatabase`
- [ ] `IAsyncLifetime` implementado corretamente
- [ ] Nomes de método no padrão esperado
- [ ] Cobertura de CRUD mínima
- [ ] `dotnet test` concluído sem falhas
- [ ] `dotnet build` concluído sem falhas

## 8. Erros comuns

| Erro | Causa | Solução |
|------|-------|---------|
| `no such table: cad_unidade` | tabela não criada no `InitializeAsync` | chamar `CreateTableAsync<T>()` antes dos testes |
| Testes interferem entre si | uso do banco da aplicação em vez do temporário | usar `SqliteTestDatabase.CreateAsync()` |
| `Database` não isolado | referência ao singleton | testar diretamente o DAO com conexão isolada |
| Falha em `DisposeAsync` | arquivo ainda aberto | garantir que a conexão foi liberada antes da exclusão |

## 9. Observação sobre o projeto atual

Atualmente, o repositório possui um projeto de testes funcional e validado com a suíte existente. Consulte também o documento [../Relatório_de_Testes.md](../Relatório_de_Testes.md) para manter o histórico de execução e evidências.
