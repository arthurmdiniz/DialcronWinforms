using SQLite;

namespace DialcronWinforms.Models;

public class TipoAtendimento
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    public int Unidade { get; set; }

    public string? DesTipoAtendimento { get; set; }

    public string? Ativo { get; set; }
}
