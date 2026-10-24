using SQLite;
using DialcronWinforms.Models;

namespace DialcronWinforms.Data.DAO;

public class BelAtendimentoDAO
{
    private readonly SQLiteAsyncConnection _connection;

    public BelAtendimentoDAO(SQLiteAsyncConnection connection)
    {
        _connection = connection;
    }

    public async Task<List<BelAtendimento>> GetByDataAsync(DateTime data)
    {
        var prefixo = data.ToString("yyyy-MM-dd");

        return await _connection.Table<BelAtendimento>()
            .Where(b => b.DtaAtendimento != null && b.DtaAtendimento.StartsWith(prefixo))
            .ToListAsync();
    }

    public async Task<BelAtendimento?> GetByAtendimentoAsync(int atendimento)
    {
        return await _connection.Table<BelAtendimento>()
            .Where(b => b.Atendimento == atendimento)
            .FirstOrDefaultAsync();
    }

    public async Task<int> InsertAsync(BelAtendimento belAtendimento)
    {
        return await _connection.InsertAsync(belAtendimento);
    }

    public async Task<int> UpdateAsync(BelAtendimento belAtendimento)
    {
        return await _connection.UpdateAsync(belAtendimento);
    }

    public async Task<int> DeleteAsync(int id)
    {
        return await _connection.DeleteAsync<BelAtendimento>(id);
    }
}
