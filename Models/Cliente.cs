using SQLite;

namespace DialcronWinforms.Models;

public class Cliente
{
    [PrimaryKey, AutoIncrement]
    public int ClienteId { get; set; }

    public string? Nome { get; set; }

    public string? Logradouro { get; set; }

    public int? Numero { get; set; }

    public string? CpfCnpj { get; set; }

    public string? DtaNascimento { get; set; }

    public string? DtaCriacao { get; set; }

    public int? DddTelefone { get; set; }

    public int? Telefone { get; set; }

    public int? DddCelular { get; set; }

    public int? Celular { get; set; }

    public string? Email { get; set; }

    public string? Sexo { get; set; }
}
