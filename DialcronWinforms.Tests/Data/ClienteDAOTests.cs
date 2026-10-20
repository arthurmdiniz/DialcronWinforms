using DialcronWinforms.Data.DAO;
using DialcronWinforms.Models;
using DialcronWinforms.Tests.Support;

namespace DialcronWinforms.Tests.Data;

public class ClienteDAOTests : IAsyncLifetime
{
    private SqliteTestDatabase _db = null!;
    private ClienteDAO _dao = null!;

    public async Task InitializeAsync()
    {
        _db = await SqliteTestDatabase.CreateAsync();
        await _db.Connection.CreateTableAsync<Cliente>();
        _dao = new ClienteDAO(_db.Connection);
    }

    public async Task DisposeAsync()
    {
        await _db.DisposeAsync();
    }

    [Fact]
    public async Task Mapeamento_UsaTabelaCadCliente()
    {
        var count = await _db.Connection.ExecuteScalarAsync<int>(
            "SELECT COUNT(*) FROM sqlite_master WHERE type = 'table' AND name = 'cad_cliente'");

        Assert.Equal(1, count);
    }

    [Fact]
    public async Task GetAllAsync_QuandoVazio_RetornaListaVazia()
    {
        var clientes = await _dao.GetAllAsync();

        Assert.Empty(clientes);
    }

    [Fact]
    public async Task GetAllAsync_ComRegistros_RetornaTodos()
    {
        await _dao.InsertAsync(CriarCliente("Cliente A"));
        await _dao.InsertAsync(CriarCliente("Cliente B"));

        var clientes = await _dao.GetAllAsync();

        Assert.Equal(2, clientes.Count);
    }

    [Fact]
    public async Task GetByIdAsync_ComIdExistente_RetornaCliente()
    {
        var cliente = CriarCliente("Cliente Centro");
        await _dao.InsertAsync(cliente);

        var encontrado = await _dao.GetByIdAsync(cliente.ClienteId);

        Assert.NotNull(encontrado);
        Assert.Equal(cliente.ClienteId, encontrado.ClienteId);
        Assert.Equal("Cliente Centro", encontrado.Nome);
    }

    [Fact]
    public async Task GetByIdAsync_ComIdInexistente_RetornaNull()
    {
        var encontrado = await _dao.GetByIdAsync(999);

        Assert.Null(encontrado);
    }

    [Fact]
    public async Task InsertAsync_ComDadosValidos_GeraIdEPersiste()
    {
        var cliente = CriarCliente("Cliente Norte");

        var linhas = await _dao.InsertAsync(cliente);

        Assert.Equal(1, linhas);
        Assert.True(cliente.ClienteId > 0);

        var salvo = await _dao.GetByIdAsync(cliente.ClienteId);
        Assert.NotNull(salvo);
        Assert.Equal("Cliente Norte", salvo.Nome);
    }

    [Fact]
    public async Task UpdateAsync_ComDadosAlterados_PersisteAlteracao()
    {
        var cliente = CriarCliente("Cliente Sul");
        await _dao.InsertAsync(cliente);

        cliente.Nome = "Cliente Sul Atualizado";
        var linhas = await _dao.UpdateAsync(cliente);

        Assert.Equal(1, linhas);

        var atualizado = await _dao.GetByIdAsync(cliente.ClienteId);
        Assert.NotNull(atualizado);
        Assert.Equal("Cliente Sul Atualizado", atualizado.Nome);
    }

    [Fact]
    public async Task DeleteAsync_ComIdExistente_RemoveRegistro()
    {
        var cliente = CriarCliente("Cliente Leste");
        await _dao.InsertAsync(cliente);

        var linhas = await _dao.DeleteAsync(cliente.ClienteId);

        Assert.Equal(1, linhas);
        Assert.Null(await _dao.GetByIdAsync(cliente.ClienteId));
    }

    private static Cliente CriarCliente(string nome)
    {
        return new Cliente
        {
            Nome = nome,
            Logradouro = "Rua das Flores",
            Numero = 100,
            CpfCnpj = "123.456.789-00",
            Email = "cliente@exemplo.com",
            Sexo = "M",
        };
    }
}
