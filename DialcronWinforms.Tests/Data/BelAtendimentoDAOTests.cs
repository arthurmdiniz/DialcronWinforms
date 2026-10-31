using DialcronWinforms.Data.DAO;
using DialcronWinforms.Models;
using DialcronWinforms.Tests.Support;

namespace DialcronWinforms.Tests.Data;

public class BelAtendimentoDAOTests : IAsyncLifetime
{
    private SqliteTestDatabase _db = null!;
    private BelAtendimentoDAO _dao = null!;

    public async Task InitializeAsync()
    {
        _db = await SqliteTestDatabase.CreateAsync();
        await _db.Connection.CreateTableAsync<BelAtendimento>();
        _dao = new BelAtendimentoDAO(_db.Connection);
    }

    public async Task DisposeAsync()
    {
        await _db.DisposeAsync();
    }

    [Fact]
    public async Task GetAllAsync_QuandoVazio_RetornaListaVazia()
    {
        var atendimentos = await _dao.GetAllAsync();

        Assert.Empty(atendimentos);
    }

    [Fact]
    public async Task GetAllAsync_ComRegistros_RetornaTodos()
    {
        await _dao.InsertAsync(CriarBelAtendimento(1, "2026-10-31 09:00:00"));
        await _dao.InsertAsync(CriarBelAtendimento(2, "2026-10-31 10:00:00"));

        var atendimentos = await _dao.GetAllAsync();

        Assert.Equal(2, atendimentos.Count);
        Assert.Contains(atendimentos, a => a.Atendimento == 1);
        Assert.Contains(atendimentos, a => a.Atendimento == 2);
    }

    [Fact]
    public async Task GetByDataAsync_ComDataCorrespondente_RetornaAtendimentosDaData()
    {
        await _dao.InsertAsync(CriarBelAtendimento(1, "2026-10-31 09:00:00"));
        await _dao.InsertAsync(CriarBelAtendimento(2, "2026-10-31 14:30:00"));
        await _dao.InsertAsync(CriarBelAtendimento(3, "2026-11-01 09:00:00"));

        var encontrados = await _dao.GetByDataAsync(new DateTime(2026, 10, 31));

        Assert.Equal(2, encontrados.Count);
        Assert.All(encontrados, a => Assert.StartsWith("2026-10-31", a.DtaAtendimento));
    }

    [Fact]
    public async Task GetByDataAsync_ComAtendimentoCancelado_NaoRetornaSituacaoE()
    {
        await _dao.InsertAsync(CriarBelAtendimento(1, "2026-10-31 09:00:00", situacao: "A"));
        await _dao.InsertAsync(CriarBelAtendimento(2, "2026-10-31 10:00:00", situacao: "E"));

        var encontrados = await _dao.GetByDataAsync(new DateTime(2026, 10, 31));

        var atendimento = Assert.Single(encontrados);
        Assert.Equal(1, atendimento.Atendimento);
        Assert.NotEqual("E", atendimento.Situacao);
    }

    [Fact]
    public async Task GetByDataAsync_SemRegistrosNaData_RetornaListaVazia()
    {
        await _dao.InsertAsync(CriarBelAtendimento(1, "2026-10-30 09:00:00"));

        var encontrados = await _dao.GetByDataAsync(new DateTime(2026, 10, 31));

        Assert.Empty(encontrados);
    }

    [Fact]
    public async Task InsertAsync_ComDadosValidos_GeraIdEPersiste()
    {
        var belAtendimento = CriarBelAtendimento(42, "2026-10-31 11:00:00");

        var linhas = await _dao.InsertAsync(belAtendimento);

        Assert.Equal(1, linhas);
        Assert.True(belAtendimento.Id > 0);

        var salvo = await _dao.GetByIdAsync(belAtendimento.Id);
        Assert.NotNull(salvo);
        Assert.Equal(42, salvo.Atendimento);
        Assert.Equal("2026-10-31 11:00:00", salvo.DtaAtendimento);
    }

    [Fact]
    public async Task UpdateAsync_ComDadosAlterados_PersisteAlteracoes()
    {
        var belAtendimento = CriarBelAtendimento(42, "2026-10-31 11:00:00");
        await _dao.InsertAsync(belAtendimento);

        belAtendimento.Situacao = "F";
        belAtendimento.Valor = 125.50;
        belAtendimento.Pago = 1;
        belAtendimento.Observacao = "Atendimento finalizado";

        var linhas = await _dao.UpdateAsync(belAtendimento);

        Assert.Equal(1, linhas);

        var atualizado = await _dao.GetByIdAsync(belAtendimento.Id);
        Assert.NotNull(atualizado);
        Assert.Equal("F", atualizado.Situacao);
        Assert.Equal(125.50, atualizado.Valor);
        Assert.Equal(1, atualizado.Pago);
        Assert.Equal("Atendimento finalizado", atualizado.Observacao);
    }

    [Fact]
    public async Task DeleteAsync_ComIdExistente_RemoveRegistro()
    {
        var belAtendimento = CriarBelAtendimento(42, "2026-10-31 11:00:00");
        await _dao.InsertAsync(belAtendimento);

        var linhas = await _dao.DeleteAsync(belAtendimento.Id);

        Assert.Equal(1, linhas);
        Assert.Null(await _dao.GetByIdAsync(belAtendimento.Id));
    }

    private static BelAtendimento CriarBelAtendimento(
        int atendimento,
        string dataAtendimento,
        string situacao = "A")
    {
        return new BelAtendimento
        {
            Atendimento = atendimento,
            Profissional = 1,
            DtaAtendimento = dataAtendimento,
            DtaCriacao = "2026-10-30 08:00:00",
            Situacao = situacao,
            Valor = 75.00,
            Pago = 0,
            Observacao = "Registro de teste"
        };
    }
}
