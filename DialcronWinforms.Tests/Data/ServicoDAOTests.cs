using DialcronWinforms.Data.DAO;
using DialcronWinforms.Models;
using DialcronWinforms.Tests.Support;

namespace DialcronWinforms.Tests.Data;

public class ServicoDAOTests : IAsyncLifetime
{
    private SqliteTestDatabase _db = null!;
    private ServicoDAO _dao = null!;

    public async Task InitializeAsync()
    {
        _db = await SqliteTestDatabase.CreateAsync();
        await _db.Connection.CreateTableAsync<Servico>();
        _dao = new ServicoDAO(_db.Connection);
    }

    public async Task DisposeAsync()
    {
        await _db.DisposeAsync();
    }

    [Fact]
    public async Task GetAllAsync_QuandoVazio_RetornaListaVazia()
    {
        var servicos = await _dao.GetAllAsync();

        Assert.Empty(servicos);
    }

    [Fact]
    public async Task GetAllAsync_ComRegistros_RetornaTodos()
    {
        await _dao.InsertAsync(CriarServico("Corte"));
        await _dao.InsertAsync(CriarServico("Barba"));

        var servicos = await _dao.GetAllAsync();

        Assert.Equal(2, servicos.Count);
    }

    [Fact]
    public async Task GetByIdAsync_ComIdExistente_RetornaServico()
    {
        var servico = CriarServico("Corte Masculino");
        await _dao.InsertAsync(servico);

        var encontrado = await _dao.GetByIdAsync(servico.Id);

        Assert.NotNull(encontrado);
        Assert.Equal(servico.Id, encontrado.Id);
        Assert.Equal("Corte Masculino", encontrado.Nome);
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
        var servico = CriarServico("Escova");

        var linhas = await _dao.InsertAsync(servico);

        Assert.Equal(1, linhas);
        Assert.True(servico.Id > 0);

        var salvo = await _dao.GetByIdAsync(servico.Id);
        Assert.NotNull(salvo);
        Assert.Equal("Escova", salvo.Nome);
    }

    [Fact]
    public async Task UpdateAsync_ComDadosAlterados_PersisteAlteracao()
    {
        var servico = CriarServico("Hidratação");
        await _dao.InsertAsync(servico);

        servico.Nome = "Hidratação Premium";
        servico.Preco = 99.9;
        var linhas = await _dao.UpdateAsync(servico);

        Assert.Equal(1, linhas);

        var atualizado = await _dao.GetByIdAsync(servico.Id);
        Assert.NotNull(atualizado);
        Assert.Equal("Hidratação Premium", atualizado.Nome);
        Assert.Equal(99.9, atualizado.Preco);
    }

    [Fact]
    public async Task DeleteAsync_ComIdExistente_RemoveRegistro()
    {
        var servico = CriarServico("Coloração");
        await _dao.InsertAsync(servico);

        var linhas = await _dao.DeleteAsync(servico.Id);

        Assert.Equal(1, linhas);
        Assert.Null(await _dao.GetByIdAsync(servico.Id));
    }

    private static Servico CriarServico(string nome)
    {
        return new Servico
        {
            Unidade = 1,
            Nome = nome,
            Preco = 50.0,
            DuracaoMinutos = 30,
            Ativo = "S",
        };
    }
}
