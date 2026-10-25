using SQLite;

namespace DialcronWinforms.Models;

[Table("bel_profissional")]
public class Profissional
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    public int Unidade { get; set; }

    public string? Nome { get; set; }

    public string? Especialidade { get; set; }

    [Column("ddd_telefone")]
    public int? DddTelefone { get; set; }

    public int? Telefone { get; set; }

    [Column("ddd_celular")]
    public int? DddCelular { get; set; }

    public int? Celular { get; set; }

    [Column("ddd_outros")]
    public int? DddOutros { get; set; }

    [Column("telefone_outros")]
    public int? TelefoneOutros { get; set; }

    public string? Ativo { get; set; }
}
