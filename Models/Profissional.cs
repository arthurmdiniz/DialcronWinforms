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

    public int? DddTelefone { get; set; }

    public int? Telefone { get; set; }

    public int? DddCelular { get; set; }

    public int? Celular { get; set; }

    public int? DddOutros { get; set; }

    public int? TelefoneOutros { get; set; }

    public string? Ativo { get; set; }
}
