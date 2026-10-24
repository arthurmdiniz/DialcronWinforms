using SQLite;
using DialcronWinforms.Models;

namespace DialcronWinforms.Data.DAO;

public class ClienteDAO
{
    private readonly SQLiteAsyncConnection _connection;

    public ClienteDAO(SQLiteAsyncConnection connection)
    {
        _connection = connection;
    }

    public async Task<List<Cliente>> GetAllAsync()
    {
        return await _connection.Table<Cliente>().ToListAsync();
    }

    public async Task<Cliente?> GetByIdAsync(int id)
    {
        return await _connection.Table<Cliente>()
            .Where(c => c.ClienteId == id)
            .FirstOrDefaultAsync();
    }

    public async Task<int> InsertAsync(Cliente cliente)
    {
        return await _connection.InsertAsync(cliente);
    }

    public async Task<int> UpdateAsync(Cliente cliente)
    {
        return await _connection.UpdateAsync(cliente);
    }

    public async Task<int> DeleteAsync(int id)
    {
        return await _connection.DeleteAsync<Cliente>(id);
    }
}
