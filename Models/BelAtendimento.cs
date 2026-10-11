using SQLite;

namespace DialcronWinforms.Models;

public class BelAtendimento
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    public int Atendimento { get; set; }

    public int Profissional { get; set; }

    public string? DtaAtendimento { get; set; }

    public string? DtaCriacao { get; set; }

    public string? DtaEncerramento { get; set; }

    public string? Situacao { get; set; }

    public double Valor { get; set; }

    public int Pago { get; set; }

    public string? Observacao { get; set; }
}
