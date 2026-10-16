using SQLite;
using DialcronWinforms.Models;

namespace DialcronWinforms.Data.DAO;

public class ServicoDAO
{
    private readonly SQLiteAsyncConnection _connection;

    public ServicoDAO(SQLiteAsyncConnection connection)
    {
        _connection = connection;
    }

    public async Task<List<Servico>> GetAllAsync()
    {
        return await _connection.Table<Servico>().ToListAsync();
    }

    public async Task<Servico?> GetByIdAsync(int id)
    {
        return await _connection.Table<Servico>()
            .Where(s => s.Id == id)
            .FirstOrDefaultAsync();
    }

    public async Task<int> InsertAsync(Servico servico)
    {
        return await _connection.InsertAsync(servico);
    }

    public async Task<int> UpdateAsync(Servico servico)
    {
        return await _connection.UpdateAsync(servico);
    }

    public async Task<int> DeleteAsync(int id)
    {
        return await _connection.DeleteAsync<Servico>(id);
    }
}
