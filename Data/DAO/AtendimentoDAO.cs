using SQLite;
using DialcronWinforms.Models;

namespace DialcronWinforms.Data.DAO;

public class AtendimentoDAO
{
    private readonly SQLiteAsyncConnection _connection;

    public AtendimentoDAO(SQLiteAsyncConnection connection)
    {
        _connection = connection;
    }

    public async Task<List<Atendimento>> GetAllAsync()
    {
        return await _connection.Table<Atendimento>().ToListAsync();
    }

    public async Task<Atendimento?> GetByIdAsync(int id)
    {
        return await _connection.Table<Atendimento>()
            .Where(a => a.Id == id)
            .FirstOrDefaultAsync();
    }

    public async Task<int> InsertAsync(Atendimento atendimento)
    {
        return await _connection.InsertAsync(atendimento);
    }

    public async Task<int> UpdateAsync(Atendimento atendimento)
    {
        return await _connection.UpdateAsync(atendimento);
    }

    public async Task<int> DeleteAsync(int id)
    {
        return await _connection.DeleteAsync<Atendimento>(id);
    }
}
