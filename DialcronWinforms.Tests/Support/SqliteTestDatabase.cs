using SQLite;

namespace DialcronWinforms.Tests.Support;

public sealed class SqliteTestDatabase : IAsyncDisposable
{
    private readonly string _path;

    private SqliteTestDatabase(string path, SQLiteAsyncConnection connection)
    {
        _path = path;
        Connection = connection;
    }

    public SQLiteAsyncConnection Connection { get; }

    public static async Task<SqliteTestDatabase> CreateAsync()
    {
        var path = Path.Combine(Path.GetTempPath(), $"dialcron-test-{Guid.NewGuid():N}.db");
        var connection = new SQLiteAsyncConnection(path);
        await connection.ExecuteAsync("PRAGMA foreign_keys = ON;");
        return new SqliteTestDatabase(path, connection);
    }

    public async ValueTask DisposeAsync()
    {
        Connection.GetConnection().Dispose();
        await Task.Yield();

        if (File.Exists(_path))
            File.Delete(_path);
    }
}
