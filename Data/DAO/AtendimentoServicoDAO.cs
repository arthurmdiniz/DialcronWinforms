using SQLite;
using DialcronWinforms.Models;

namespace DialcronWinforms.Data.DAO;

public class AtendimentoServicoDAO
{
    private readonly SQLiteAsyncConnection _connection;

    public AtendimentoServicoDAO(SQLiteAsyncConnection connection)
    {
        _connection = connection;
    }

    public async Task<List<AtendimentoServico>> GetByAtendimentoAsync(int atendimento)
    {
        return await _connection.Table<AtendimentoServico>()
            .Where(s => s.Atendimento == atendimento)
            .ToListAsync();
    }

    public async Task<int> InsertAsync(AtendimentoServico atendimentoServico)
    {
        return await _connection.InsertAsync(atendimentoServico);
    }

    public async Task<int> DeleteByAtendimentoAsync(int atendimento)
    {
        return await _connection.Table<AtendimentoServico>()
            .Where(s => s.Atendimento == atendimento)
            .DeleteAsync();
    }
}
