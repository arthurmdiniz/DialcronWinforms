using SQLite;

namespace DialcronWinforms.Data;

public class Database
{
    public const string SeedFileName = "DialcronSB_PADRAO.db";
    public const string DbFileName = "DialcronSBDB.db";

    private static Database? _instance;
    private static readonly object _lock = new();

    private SQLiteAsyncConnection? _connection;

    private Database() { }

    public static Database Instance
    {
        get
        {
            if (_instance is null)
            {
                lock (_lock)
                {
                    _instance ??= new Database();
                }
            }
            return _instance;
        }
    }

    public static string DbPath { get; } = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, DbFileName);

    public bool DatabaseExists() => File.Exists(DbPath);

    public async Task<SQLiteAsyncConnection> InitializeAsync()
    {
        if (_connection is not null)
            return _connection;

        _connection = DatabaseExists()
            ? await OpenConnectionAsync()
            : await CreateDatabaseAsync();

        return _connection;
    }

    public async Task<SQLiteAsyncConnection> CreateDatabaseAsync()
    {
        var folder = Path.GetDirectoryName(DbPath);

        if (!string.IsNullOrEmpty(folder))
            Directory.CreateDirectory(folder);

        var seedPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, SeedFileName);

        if (File.Exists(seedPath))
            File.Copy(seedPath, DbPath, overwrite: true);

        return await OpenConnectionAsync();
    }

    public async Task<SQLiteAsyncConnection> OpenConnectionAsync()
    {
        var connection = new SQLiteAsyncConnection(DbPath);
        await connection.ExecuteAsync("PRAGMA foreign_keys = ON;");
        return connection;
    }
}
