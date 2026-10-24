using DialcronWinforms.Data.DAO;
using DialcronWinforms.Models;
using DialcronWinforms.Tests.Support;

namespace DialcronWinforms.Tests.Data;

public class AtendimentoDAOTests : IAsyncLifetime
{
    private SqliteTestDatabase _db = null!;
    private AtendimentoDAO _dao = null!;

    public async Task InitializeAsync()
    {
        _db = await SqliteTestDatabase.CreateAsync();
        await _db.Connection.CreateTableAsync<Atendimento>();
        await _db.Connection.CreateTableAsync<BelAtendimento>();
        await _db.Connection.CreateTableAsync<AtendimentoServico>();
        _dao = new AtendimentoDAO(_db.Connection);
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
        await _dao.InsertAsync(CriarAtendimento("Corte"));
        await _dao.InsertAsync(CriarAtendimento("Barba"));

        var atendimentos = await _dao.GetAllAsync();

        Assert.Equal(2, atendimentos.Count);
    }

    [Fact]
    public async Task GetByIdAsync_ComIdExistente_RetornaAtendimento()
    {
        var atendimento = CriarAtendimento("Coloração");
        await _dao.InsertAsync(atendimento);

        var encontrado = await _dao.GetByIdAsync(atendimento.Id);

        Assert.NotNull(encontrado);
        Assert.Equal(atendimento.Id, encontrado.Id);
        Assert.Equal("Coloração", encontrado.Descricao);
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
        var atendimento = CriarAtendimento("Escova");

        var linhas = await _dao.InsertAsync(atendimento);

        Assert.Equal(1, linhas);
        Assert.True(atendimento.Id > 0);

        var salvo = await _dao.GetByIdAsync(atendimento.Id);
        Assert.NotNull(salvo);
        Assert.Equal("Escova", salvo.Descricao);
    }

    [Fact]
    public async Task UpdateAsync_ComDadosAlterados_PersisteAlteracao()
    {
        var atendimento = CriarAtendimento("Hidratação");
        await _dao.InsertAsync(atendimento);

        atendimento.Descricao = "Hidratação Premium";
        atendimento.Situacao = "f";
        var linhas = await _dao.UpdateAsync(atendimento);

        Assert.Equal(1, linhas);

        var atualizado = await _dao.GetByIdAsync(atendimento.Id);
        Assert.NotNull(atualizado);
        Assert.Equal("Hidratação Premium", atualizado.Descricao);
        Assert.Equal("f", atualizado.Situacao);
    }

    [Fact]
    public async Task DeleteAsync_ComIdExistente_RemoveRegistro()
    {
        var atendimento = CriarAtendimento("Manicure");
        await _dao.InsertAsync(atendimento);

        var linhas = await _dao.DeleteAsync(atendimento.Id);

        Assert.Equal(1, linhas);
        Assert.Null(await _dao.GetByIdAsync(atendimento.Id));
    }

    [Fact]
    public async Task Relacao_AtendimentoServico_VinculaServicosAoBelAtendimento()
    {
        var atendimento = CriarAtendimento("Pacote completo");
        await _dao.InsertAsync(atendimento);

        var bel = new BelAtendimento
        {
            Atendimento = atendimento.Id,
            Profissional = 1,
            DtaAtendimento = "2026-10-24 10:00",
            Situacao = "a",
        };
        await _db.Connection.InsertAsync(bel);

        await _db.Connection.InsertAsync(new AtendimentoServico { Atendimento = bel.Id, Servico = 1 });
        await _db.Connection.InsertAsync(new AtendimentoServico { Atendimento = bel.Id, Servico = 2 });

        var vinculados = await _db.Connection.Table<AtendimentoServico>()
            .Where(s => s.Atendimento == bel.Id)
            .ToListAsync();

        Assert.Equal(2, vinculados.Count);
        Assert.Contains(vinculados, s => s.Servico == 1);
        Assert.Contains(vinculados, s => s.Servico == 2);
    }

    private static Atendimento CriarAtendimento(string descricao)
    {
        return new Atendimento
        {
            Unidade = 1,
            Cliente = 1,
            Descricao = descricao,
            Situacao = "a",
            DtaCriacao = "2026-10-24 09:00:00",
        };
    }
}
