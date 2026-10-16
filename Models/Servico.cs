using SQLite;

namespace DialcronWinforms.Models;

public class Servico
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    public int Unidade { get; set; }

    public string? Nome { get; set; }

    public double Preco { get; set; }

    public int DuracaoMinutos { get; set; }

    public string? Ativo { get; set; }
    public object Tempo { get; internal set; }
}
