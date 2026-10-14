using DialcronWinforms.Data.DAO;
using DialcronWinforms.Models;
using DialcronWinforms.Tests.Support;

namespace DialcronWinforms.Tests.Data;

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

    [Fact]
    public async Task Mapeamento_UsaTabelaCadUnidade()
    {
        var count = await _db.Connection.ExecuteScalarAsync<int>(
            "SELECT COUNT(*) FROM sqlite_master WHERE type = 'table' AND name = 'cad_unidade'");

        Assert.Equal(1, count);
    }

    [Fact]
    public async Task GetAllAsync_QuandoVazio_RetornaListaVazia()
    {
        var unidades = await _dao.GetAllAsync();

        Assert.Empty(unidades);
    }

    [Fact]
    public async Task GetAllAsync_ComRegistros_RetornaTodos()
    {
        await _dao.InsertAsync(CriarUnidade("Unidade A"));
        await _dao.InsertAsync(CriarUnidade("Unidade B"));

        var unidades = await _dao.GetAllAsync();

        Assert.Equal(2, unidades.Count);
    }

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

    [Fact]
    public async Task GetByIdAsync_ComIdExistente_RetornaUnidade()
    {
        var unidade = CriarUnidade("Unidade Norte");
        await _dao.InsertAsync(unidade);

        var encontrada = await _dao.GetByIdAsync(unidade.IdUnidade);

        Assert.NotNull(encontrada);
        Assert.Equal(unidade.IdUnidade, encontrada.IdUnidade);
        Assert.Equal("Unidade Norte", encontrada.NomeFantasia);
    }

    [Fact]
    public async Task GetByIdAsync_ComIdInexistente_RetornaNull()
    {
        var encontrada = await _dao.GetByIdAsync(999);

        Assert.Null(encontrada);
    }

    [Fact]
    public async Task UpdateAsync_ComDadosAlterados_PersisteAlteracao()
    {
        var unidade = CriarUnidade("Unidade Sul");
        await _dao.InsertAsync(unidade);

        unidade.NomeFantasia = "Unidade Sul Atualizada";
        var linhas = await _dao.UpdateAsync(unidade);

        Assert.Equal(1, linhas);

        var atualizada = await _dao.GetByIdAsync(unidade.IdUnidade);
        Assert.NotNull(atualizada);
        Assert.Equal("Unidade Sul Atualizada", atualizada.NomeFantasia);
    }

    [Fact]
    public async Task DeleteAsync_ComIdExistente_RemoveRegistro()
    {
        var unidade = CriarUnidade("Unidade Leste");
        await _dao.InsertAsync(unidade);

        var linhas = await _dao.DeleteAsync(unidade.IdUnidade);

        Assert.Equal(1, linhas);
        Assert.Null(await _dao.GetByIdAsync(unidade.IdUnidade));
    }

    private static Unidade CriarUnidade(string nomeFantasia)
    {
        return new Unidade
        {
            NomeFantasia = nomeFantasia,
            RazaoSocial = $"{nomeFantasia} LTDA",
            Cnpj = "12.345.678/0001-90",
            Uf = "SP",
        };
    }
}
