using System.Text.RegularExpressions;
using DialcronWinforms.Data.DAO;
using DialcronWinforms.Models;
using DialcronWinforms.Tests.Support;
using SQLite;

namespace DialcronWinforms.Tests.Data;

public class BackupDAOTests : IAsyncLifetime
{
    private SqliteTestDatabase _db = null!;
    private BackupDAO _dao = null!;
    private readonly string _pasta = Path.Combine(Path.GetTempPath(), $"dialcron-backup-test-{Guid.NewGuid():N}");

    public async Task InitializeAsync()
    {
        _db = await SqliteTestDatabase.CreateAsync();
        await _db.Connection.CreateTableAsync<Cliente>();
        _dao = new BackupDAO(_db.Connection);
    }

    public async Task DisposeAsync()
    {
        await _db.DisposeAsync();

        if (Directory.Exists(_pasta))
            Directory.Delete(_pasta, recursive: true);
    }

    [Fact]
    public void BuildBackupFileName_SegueOPadrao()
    {
        var nome = BackupDAO.BuildBackupFileName();

        Assert.Matches(new Regex(@"^DialcronSB_Backup_\d{12}\.db$"), nome);
    }

    [Fact]
    public async Task CreateBackupAsync_CopiaOsDadosParaODestino()
    {
        await _db.Connection.InsertAsync(new Cliente { Nome = "Cliente Backup" });
        var destino = Path.Combine(_pasta, "backup.db");

        await _dao.CreateBackupAsync(destino);

        Assert.True(File.Exists(destino));
        Assert.Equal(1, await ContarClientesAsync(destino));
    }

    [Fact]
    public async Task CreateBackupAsync_SobrescreveArquivoExistente()
    {
        Directory.CreateDirectory(_pasta);
        var destino = Path.Combine(_pasta, "backup.db");
        await File.WriteAllTextAsync(destino, "conteudo antigo");
        await _db.Connection.InsertAsync(new Cliente { Nome = "Cliente Novo" });

        await _dao.CreateBackupAsync(destino);

        Assert.Equal(1, await ContarClientesAsync(destino));
    }

    [Fact]
    public async Task CreateBackupAsync_CriaPastaInexistente()
    {
        var destino = Path.Combine(_pasta, "sub", "pasta", "backup.db");

        await _dao.CreateBackupAsync(destino);

        Assert.True(File.Exists(destino));
    }

    [Fact]
    public async Task CreateBackupAsync_CaminhoComApostrofo_Funciona()
    {
        var destino = Path.Combine(_pasta, "dialcron's", "backup.db");

        await _dao.CreateBackupAsync(destino);

        Assert.True(File.Exists(destino));
    }

    private static async Task<int> ContarClientesAsync(string caminho)
    {
        var conexao = new SQLiteAsyncConnection(caminho);
        try
        {
            return await conexao.Table<Cliente>().CountAsync();
        }
        finally
        {
            conexao.GetConnection().Dispose();
        }
    }
}
