using SQLite;

namespace DialcronWinforms.Models;

public class AtendimentoServico
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    public int Atendimento { get; set; }

    public int Servico { get; set; }
}
