using SQLite;

namespace DialcronWinforms.Models;

[Table("bel_servico")]
public class Servico
{
    [PrimaryKey, AutoIncrement, Column("id")]
    public int Id { get; set; }

    [Column("unidade")]
    public int Unidade { get; set; }

    [Column("nome")]
    public string? Nome { get; set; }

    [Column("preco")]
    public double Preco { get; set; }

    [Column("duracao_minutos")]
    public int DuracaoMinutos { get; set; }

    [Column("ativo")]
    public string? Ativo { get; set; }
}
