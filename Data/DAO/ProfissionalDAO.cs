using SQLite;
using DialcronWinforms.Models;

namespace DialcronWinforms.Data.DAO;

public class ProfissionalDAO
{
    private readonly SQLiteAsyncConnection _connection;

    public ProfissionalDAO(SQLiteAsyncConnection connection)
    {
        _connection = connection;
    }

    public async Task<List<Profissional>> GetAllAsync()
    {
        return await _connection.Table<Profissional>().ToListAsync();
    }

    public async Task<Profissional?> GetByIdAsync(int id)
    {
        return await _connection.Table<Profissional>()
            .Where(p => p.Id == id)
            .FirstOrDefaultAsync();
    }

    public async Task<int> InsertAsync(Profissional profissional)
    {
        return await _connection.InsertAsync(profissional);
    }

    public async Task<int> UpdateAsync(Profissional profissional)
    {
        return await _connection.UpdateAsync(profissional);
    }

    public async Task<int> DeleteAsync(int id)
    {
        return await _connection.DeleteAsync<Profissional>(id);
    }
}
