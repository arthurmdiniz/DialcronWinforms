using SQLite;

namespace DialcronWinforms.Models;

[Table("cad_atendimento")]
public class Atendimento
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    public int Unidade { get; set; }

    public int? Cliente { get; set; }

    public string? Descricao { get; set; }

    public string? Situacao { get; set; }

    [Column("dta_criacao")]
    public string? DtaCriacao { get; set; }

    [Column("dta_encerramento")]
    public string? DtaEncerramento { get; set; }

    [Column("usuario_criacao")]
    public int? UsuarioCriacao { get; set; }

    [Column("usuario_encerramento")]
    public int? UsuarioEncerramento { get; set; }
}
