using DialcronWinforms.Data;
using DialcronWinforms.Tests.Support;
using SQLite;

namespace DialcronWinforms.Tests.Data;

public class DatabaseTests : IAsyncLifetime
{
    private readonly string _directory = Path.Combine(Path.GetTempPath(), $"dialcron-database-test-{Guid.NewGuid():N}");
    private string DbPath => Path.Combine(_directory, Database.DbFileName);
    private string SeedPath => Path.Combine(_directory, Database.SeedFileName);

    public Task InitializeAsync()
    {
        Directory.CreateDirectory(_directory);
        return Task.CompletedTask;
    }

    public Task DisposeAsync()
    {
        if (Directory.Exists(_directory))
            Directory.Delete(_directory, recursive: true);

        return Task.CompletedTask;
    }

    [Fact]
    public void DatabaseExists_QuandoBancoNaoExiste_RetornaFalse()
    {
        var database = CreateDatabase();

        Assert.False(database.DatabaseExists());
    }

    [Fact]
    public async Task DatabaseExists_QuandoBancoExiste_RetornaTrue()
    {
        await File.WriteAllBytesAsync(DbPath, []);
        var database = CreateDatabase();

        Assert.True(database.DatabaseExists());
    }

    [Fact]
    public async Task InitializeAsync_QuandoBancoJaExiste_AbreBancoExistente()
    {
        var testDb = await SqliteTestDatabase.CreateAsync();
        await testDb.Connection.ExecuteAsync("CREATE TABLE teste (id INTEGER PRIMARY KEY)");
        await testDb.Connection.ExecuteAsync("INSERT INTO teste DEFAULT VALUES");
        var database = new Database(testDb.FilePath, SeedPath);
        var connection = await database.InitializeAsync();

        try
        {
            Assert.Equal(1, await connection.ExecuteScalarAsync<int>("SELECT COUNT(*) FROM teste"));
        }
        finally
        {
            Close(connection);
            await testDb.DisposeAsync();
        }
    }

    [Fact]
    public async Task InitializeAsync_QuandoBancoNaoExisteECopiaSemente_DisponibilizaDadosDaSemente()
    {
        await CreateSeedAsync();
        var database = CreateDatabase();

        var connection = await database.InitializeAsync();

        Assert.True(File.Exists(DbPath));
        Assert.Equal(1, await connection.ExecuteScalarAsync<int>("SELECT COUNT(*) FROM tabela_semente"));
        Close(connection);
    }

    [Fact]
    public async Task InitializeAsync_QuandoBancoESementeNaoExistem_CriaBancoVazio()
    {
        var database = CreateDatabase();

        var connection = await database.InitializeAsync();

        Assert.True(File.Exists(DbPath));
        Assert.Equal(0, await connection.ExecuteScalarAsync<int>(
            "SELECT COUNT(*) FROM sqlite_master WHERE type = 'table'"));
        Close(connection);
    }

    [Fact]
    public async Task InitializeAsync_QuandoChamadoMaisDeUmaVez_ReutilizaConexao()
    {
        var database = CreateDatabase();

        var primeira = await database.InitializeAsync();
        var segunda = await database.InitializeAsync();

        Assert.Same(primeira, segunda);
        Close(primeira);
    }

    [Fact]
    public async Task CreateDatabaseAsync_QuandoSementeExiste_CopiaSementeParaOBanco()
    {
        await CreateSeedAsync();
        var database = CreateDatabase();

        var connection = await database.CreateDatabaseAsync();

        Assert.True(File.Exists(DbPath));
        Assert.Equal(1, await connection.ExecuteScalarAsync<int>("SELECT COUNT(*) FROM tabela_semente"));
        Close(connection);
    }

    [Fact]
    public async Task CreateDatabaseAsync_QuandoSementeNaoExiste_CriaBancoVazio()
    {
        var database = CreateDatabase();

        var connection = await database.CreateDatabaseAsync();

        Assert.True(File.Exists(DbPath));
        Assert.Equal(0, await connection.ExecuteScalarAsync<int>(
            "SELECT COUNT(*) FROM sqlite_master WHERE type = 'table'"));
        Close(connection);
    }

    [Fact]
    public async Task OpenConnectionAsync_HabilitaChavesEstrangeiras()
    {
        var database = CreateDatabase();

        var connection = await database.OpenConnectionAsync();

        Assert.Equal(1, await connection.ExecuteScalarAsync<int>("PRAGMA foreign_keys;"));
        Close(connection);
    }

    private Database CreateDatabase() => new(DbPath, SeedPath);

    private async Task CreateSeedAsync()
    {
        var seed = new SQLiteAsyncConnection(SeedPath);
        await seed.ExecuteAsync("CREATE TABLE tabela_semente (id INTEGER PRIMARY KEY)");
        await seed.ExecuteAsync("INSERT INTO tabela_semente DEFAULT VALUES");
        seed.GetConnection().Dispose();
    }

    private static void Close(SQLiteAsyncConnection connection) => connection.GetConnection().Dispose();
}
