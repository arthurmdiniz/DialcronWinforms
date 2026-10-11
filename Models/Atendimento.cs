using SQLite;

namespace DialcronWinforms.Models;

public class Atendimento
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    public int Unidade { get; set; }

    public int? Cliente { get; set; }

    public string? Descricao { get; set; }

    public string? Situacao { get; set; }

    public string? DtaCriacao { get; set; }

    public string? DtaEncerramento { get; set; }

    public int? UsuarioCriacao { get; set; }

    public int? UsuarioEncerramento { get; set; }
}
