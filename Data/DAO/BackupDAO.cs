using System.Globalization;
using SQLite;

namespace DialcronWinforms.Data.DAO;

public class BackupDAO
{
    private readonly SQLiteAsyncConnection _connection;

    public BackupDAO(SQLiteAsyncConnection connection)
    {
        _connection = connection;
    }

    public static string BuildBackupFileName()
    {
        return $"DialcronSB_Backup_{DateTime.Now.ToString("yyyyMMddHHmm", CultureInfo.InvariantCulture)}.db";
    }

    public async Task CreateBackupAsync(string destinationPath)
    {
        var folder = Path.GetDirectoryName(destinationPath);

        if (!string.IsNullOrEmpty(folder))
            Directory.CreateDirectory(folder);

        if (File.Exists(destinationPath))
            File.Delete(destinationPath);

        var escapedPath = destinationPath.Replace("'", "''");

        await _connection.ExecuteAsync($"VACUUM INTO '{escapedPath}'");
    }
}
