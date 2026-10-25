using SQLite;

namespace DialcronWinforms.Models;

[Table("bel_atendimento_servico")]
public class AtendimentoServico
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    public int Atendimento { get; set; }

    public int Servico { get; set; }
}
