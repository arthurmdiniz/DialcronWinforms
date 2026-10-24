using DialcronWinforms.Data.DAO;
using DialcronWinforms.Models;
using DialcronWinforms.Tests.Support;

namespace DialcronWinforms.Tests.Data;

public class ProfissionalDAOTests : IAsyncLifetime
{
    private SqliteTestDatabase _db = null!;
    private ProfissionalDAO _dao = null!;

    public async Task InitializeAsync()
    {
        _db = await SqliteTestDatabase.CreateAsync();
        await _db.Connection.CreateTableAsync<Profissional>();
        _dao = new ProfissionalDAO(_db.Connection);
    }

    public async Task DisposeAsync()
    {
        await _db.DisposeAsync();
    }

    [Fact]
    public async Task GetAllAsync_QuandoVazio_RetornaListaVazia()
    {
        var profissionais = await _dao.GetAllAsync();

        Assert.Empty(profissionais);
    }

    [Fact]
    public async Task GetAllAsync_ComRegistros_RetornaTodos()
    {
        await _dao.InsertAsync(CriarProfissional("Ana"));
        await _dao.InsertAsync(CriarProfissional("Bruno"));

        var profissionais = await _dao.GetAllAsync();

        Assert.Equal(2, profissionais.Count);
    }

    [Fact]
    public async Task GetByIdAsync_ComIdExistente_RetornaProfissional()
    {
        var profissional = CriarProfissional("Carla");
        await _dao.InsertAsync(profissional);

        var encontrado = await _dao.GetByIdAsync(profissional.Id);

        Assert.NotNull(encontrado);
        Assert.Equal(profissional.Id, encontrado.Id);
        Assert.Equal("Carla", encontrado.Nome);
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
        var profissional = CriarProfissional("Diego");

        var linhas = await _dao.InsertAsync(profissional);

        Assert.Equal(1, linhas);
        Assert.True(profissional.Id > 0);

        var salvo = await _dao.GetByIdAsync(profissional.Id);
        Assert.NotNull(salvo);
        Assert.Equal("Diego", salvo.Nome);
    }

    [Fact]
    public async Task UpdateAsync_ComDadosAlterados_PersisteAlteracao()
    {
        var profissional = CriarProfissional("Elisa");
        await _dao.InsertAsync(profissional);

        profissional.Nome = "Elisa Souza";
        profissional.Especialidade = "Colorista";
        var linhas = await _dao.UpdateAsync(profissional);

        Assert.Equal(1, linhas);

        var atualizado = await _dao.GetByIdAsync(profissional.Id);
        Assert.NotNull(atualizado);
        Assert.Equal("Elisa Souza", atualizado.Nome);
        Assert.Equal("Colorista", atualizado.Especialidade);
    }

    [Fact]
    public async Task DeleteAsync_ComIdExistente_RemoveRegistro()
    {
        var profissional = CriarProfissional("Felipe");
        await _dao.InsertAsync(profissional);

        var linhas = await _dao.DeleteAsync(profissional.Id);

        Assert.Equal(1, linhas);
        Assert.Null(await _dao.GetByIdAsync(profissional.Id));
    }

    private static Profissional CriarProfissional(string nome)
    {
        return new Profissional
        {
            Unidade = 1,
            Nome = nome,
            Especialidade = "Cabeleireiro",
            DddTelefone = 11,
            Telefone = 999999999,
            Ativo = "S",
        };
    }
}
