using SQLite;

namespace DialcronWinforms.Models;

public class Usuario
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }

    public string? Login { get; set; }

    public string? Senha { get; set; }

    public string? Nome { get; set; }

    public string? Perfil { get; set; }

    public string? Email { get; set; }

    public int? Grupo { get; set; }

    public string? Ativo { get; set; }

    public string? DtaCriacao { get; set; }

    public string? DtaInativacao { get; set; }
}
