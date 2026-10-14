using SQLite;
using DialcronWinforms.Models;

namespace DialcronWinforms.Data.DAO;

public class UnidadeDAO
{
    private readonly SQLiteAsyncConnection _connection;

    public UnidadeDAO(SQLiteAsyncConnection connection)
    {
        _connection = connection;
    }

    public async Task<List<Unidade>> GetAllAsync()
    {
        return await _connection.Table<Unidade>().ToListAsync();
    }

    public async Task<Unidade?> GetByIdAsync(int id)
    {
        return await _connection.Table<Unidade>()
            .Where(u => u.IdUnidade == id)
            .FirstOrDefaultAsync();
    }

    public async Task<int> InsertAsync(Unidade unidade)
    {
        return await _connection.InsertAsync(unidade);
    }

    public async Task<int> UpdateAsync(Unidade unidade)
    {
        return await _connection.UpdateAsync(unidade);
    }

    public async Task<int> DeleteAsync(int id)
    {
        return await _connection.DeleteAsync<Unidade>(id);
    }
}
