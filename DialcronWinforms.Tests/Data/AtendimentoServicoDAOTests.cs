using DialcronWinforms.Data.DAO;
using DialcronWinforms.Models;
using DialcronWinforms.Tests.Support;

namespace DialcronWinforms.Tests.Data;

public class AtendimentoServicoDAOTests : IAsyncLifetime
{
    private SqliteTestDatabase _db = null!;
    private AtendimentoServicoDAO _dao = null!;

    public async Task InitializeAsync()
    {
        _db = await SqliteTestDatabase.CreateAsync();
        await _db.Connection.CreateTableAsync<AtendimentoServico>();
        _dao = new AtendimentoServicoDAO(_db.Connection);
    }

    public async Task DisposeAsync()
    {
        await _db.DisposeAsync();
    }

    [Fact]
    public async Task GetByAtendimentoAsync_QuandoVazio_RetornaListaVazia()
    {
        var registros = await _dao.GetByAtendimentoAsync(1);

        Assert.Empty(registros);
    }

    [Fact]
    public async Task GetByAtendimentoAsync_ComRegistrosDoAtendimento_RetornaTodos()
    {
        await _dao.InsertAsync(CriarAtendimentoServico(1, 10));
        await _dao.InsertAsync(CriarAtendimentoServico(1, 20));

        var registros = await _dao.GetByAtendimentoAsync(1);

        Assert.Equal(2, registros.Count);
        Assert.All(registros, registro => Assert.Equal(1, registro.Atendimento));
        Assert.Contains(registros, registro => registro.Servico == 10);
        Assert.Contains(registros, registro => registro.Servico == 20);
    }

    [Fact]
    public async Task GetByAtendimentoAsync_ComRegistrosDeOutrosAtendimentos_NaoRetornaRegistrosAlheios()
    {
        await _dao.InsertAsync(CriarAtendimentoServico(1, 10));
        await _dao.InsertAsync(CriarAtendimentoServico(2, 20));

        var registros = await _dao.GetByAtendimentoAsync(1);

        var registro = Assert.Single(registros);
        Assert.Equal(1, registro.Atendimento);
        Assert.Equal(10, registro.Servico);
    }

    [Fact]
    public async Task InsertAsync_ComDadosValidos_GeraIdEPersiste()
    {
        var atendimentoServico = CriarAtendimentoServico(1, 10);

        var linhas = await _dao.InsertAsync(atendimentoServico);

        Assert.Equal(1, linhas);
        Assert.True(atendimentoServico.Id > 0);

        var salvos = await _dao.GetByAtendimentoAsync(1);
        var salvo = Assert.Single(salvos);

        Assert.Equal(atendimentoServico.Id, salvo.Id);
        Assert.Equal(1, salvo.Atendimento);
        Assert.Equal(10, salvo.Servico);
    }

    [Fact]
    public async Task DeleteByAtendimentoAsync_ComRegistrosExistentes_RemoveTodosDoAtendimento()
    {
        await _dao.InsertAsync(CriarAtendimentoServico(1, 10));
        await _dao.InsertAsync(CriarAtendimentoServico(1, 20));
        await _dao.InsertAsync(CriarAtendimentoServico(2, 30));

        var linhas = await _dao.DeleteByAtendimentoAsync(1);

        Assert.Equal(2, linhas);
        Assert.Empty(await _dao.GetByAtendimentoAsync(1));

        var registrosRestantes = await _dao.GetByAtendimentoAsync(2);
        var registroRestante = Assert.Single(registrosRestantes);
        Assert.Equal(30, registroRestante.Servico);
    }

    [Fact]
    public async Task DeleteByAtendimentoAsync_QuandoNaoExistemRegistros_RetornaZero()
    {
        var linhas = await _dao.DeleteByAtendimentoAsync(999);

        Assert.Equal(0, linhas);
    }

    private static AtendimentoServico CriarAtendimentoServico(int atendimento, int servico)
    {
        return new AtendimentoServico
        {
            Atendimento = atendimento,
            Servico = servico
        };
    }
}
