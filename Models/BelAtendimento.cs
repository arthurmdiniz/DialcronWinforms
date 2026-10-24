using SQLite;

namespace DialcronWinforms.Models;

[Table("bel_atendimento")]
public class BelAtendimento
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    public int Atendimento { get; set; }

    public int Profissional { get; set; }

    [Column("dta_atendimento")]
    public string? DtaAtendimento { get; set; }

    [Column("dta_criacao")]
    public string? DtaCriacao { get; set; }

    [Column("dta_encerramento")]
    public string? DtaEncerramento { get; set; }

    public string? Situacao { get; set; }

    public double Valor { get; set; }

    public int Pago { get; set; }

    public string? Observacao { get; set; }
}
