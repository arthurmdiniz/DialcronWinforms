# Como Criar Testes Unitários

Guia para escrever testes unitários no DialcronWinforms. Os testes ficam no projeto `DialcronWinforms.Tests` e cobrem a camada de dados (`Data/DAO/`) e as funções de apoio.

> Este guia depende do PR #34 (`DWF-28`), que cria o projeto de testes. Antes de ele ser mergeado, os arquivos de exemplo só existem na branch `DWF-28`.

---

## 1. O que testar

| Alvo | Testar? | Motivo |
|------|---------|--------|
| DAOs (`Data/DAO/`) | Sim | Recebem `SQLiteAsyncConnection` no construtor, então usam um banco temporário |
| `FuncoesGerais` | Sim | Funções puras, sem banco nem UI |
| `Database` | Não | Singleton com caminho fixo; não dá para isolar |
| Telas (`Controls/`, `Forms/`) | Não | Testadas manualmente; a integração com o DAO é validada na issue de integração |

---

## 2. Estrutura do projeto de testes

```
DialcronWinforms.Tests/
├── DialcronWinforms.Tests.csproj
├── Support/
│   └── SqliteTestDatabase.cs     # helper: banco SQLite temporário
└── Data/
    └── UnidadeDAOTests.cs        # um arquivo por DAO
```

Padrões de nomenclatura:

| Item | Padrão | Exemplo |
|------|--------|---------|
| Arquivo | `{Nome}DAOTests.cs` | `ClienteDAOTests.cs` |
| Namespace | `DialcronWinforms.Tests.Data` | `namespace DialcronWinforms.Tests.Data;` |
| Classe | `{Nome}DAOTests` | `ClienteDAOTests` |
| Método de teste | `{Metodo}_{Cenario}_{ResultadoEsperado}` | `GetByIdAsync_ComIdInexistente_RetornaNull` |

---

## 3. O helper `SqliteTestDatabase`

Cria um arquivo SQLite em `%TEMP%`, com nome único, e o remove ao final do teste. Cada teste recebe um banco novo, então um teste não interfere no outro.

```csharp
var db = await SqliteTestDatabase.CreateAsync();
await db.Connection.CreateTableAsync<Unidade>();
```

> Não use o `DialcronSBDB.db` nem o `DialcronSB_PADRAO.db` nos testes. Eles são o banco de trabalho e o seed.

---

## 4. Passo a passo para criar os testes de um DAO

### Passo 1 - Criar o arquivo

Crie `DialcronWinforms.Tests/Data/{Nome}DAOTests.cs`.

### Passo 2 - Preparar o banco em `InitializeAsync` e `DisposeAsync`

A classe implementa `IAsyncLifetime`. O xUnit chama `InitializeAsync` antes de cada teste e `DisposeAsync` depois.

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

> Para um DAO com relação (como `AtendimentoDAO`), crie também as tabelas relacionadas no `InitializeAsync`.

### Passo 3 - Escrever os testes

Cada teste segue três etapas: **Arrange** (preparar), **Act** (executar) e **Assert** (verificar).

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

Use um método auxiliar privado para montar a entidade, para não repetir dados em cada teste:

```csharp
private static Unidade CriarUnidade(string nomeFantasia)
{
    return new Unidade
    {
        NomeFantasia = nomeFantasia,
        RazaoSocial = $"{nomeFantasia} LTDA",
        Uf = "SP",
    };
}
```

### Passo 4 - Cobrir os casos do DAO

Para cada método CRUD, teste pelo menos:

- **GetAllAsync:** lista vazia e lista com registros
- **InsertAsync:** gera Id e persiste
- **GetByIdAsync:** Id existente e Id inexistente (deve retornar `null`)
- **UpdateAsync:** a alteração é persistida
- **DeleteAsync:** o registro some

### Passo 5 - Rodar

```bash
dotnet test DialcronWinforms.Tests
```

A saída mostra quantos testes passaram. Um teste que falha mostra qual `Assert` quebrou.

---

## 5. Exemplo de teste de mapeamento

Vale testar se a entidade aponta para a tabela certa do schema. Foi o caso da `Unidade`, que precisou de `[Table("cad_unidade")]`:

```csharp
[Fact]
public async Task Mapeamento_UsaTabelaCadUnidade()
{
    var count = await _db.Connection.ExecuteScalarAsync<int>(
        "SELECT COUNT(*) FROM sqlite_master WHERE type = 'table' AND name = 'cad_unidade'");

    Assert.Equal(1, count);
}
```

---

## 6. Compilação do app

A pasta `DialcronWinforms.Tests/` é excluída da compilação do app no `DialcronWinforms.csproj`:

```xml
<Compile Remove="DialcronWinforms.Tests\**" />
```

Se criar novos arquivos de teste, eles ficam automaticamente fora do executável. Não é preciso mexer nessa linha.

---

## 7. Checklist antes de commitar

```
[ ] Arquivo em DialcronWinforms.Tests/Data/{Nome}DAOTests.cs
[ ] Usa SqliteTestDatabase (não o banco de trabalho)
[ ] Implementa IAsyncLifetime (InitializeAsync / DisposeAsync)
[ ] Nomes de método no padrão {Metodo}_{Cenario}_{ResultadoEsperado}
[ ] Cobre GetAll, Insert, GetById (existente e inexistente), Update e Delete
[ ] dotnet test sem erro
[ ] dotnet build sem erro
```

---

## 8. Erros comuns

| Erro | Causa | Solução |
|------|-------|---------|
| `no such table: cad_unidade` | `CreateTableAsync<T>()` não foi chamado | Chame no `InitializeAsync` |
| Testes passam sozinhos e falham juntos | Banco compartilhado entre testes | Use `SqliteTestDatabase.CreateAsync()` no `InitializeAsync` |
| Arquivo de teste entra no executável | Pasta de testes fora da exclusão | Confira o `<Compile Remove>` no `DialcronWinforms.csproj` |
| `Database` não isolado | Teste chama o singleton | Teste o DAO diretamente, com a conexão do helper |
| Falha só no `DisposeAsync` | Arquivo ainda aberto | Feche a conexão com `GetConnection().Dispose()` (já feito no helper) |
