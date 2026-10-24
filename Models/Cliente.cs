using SQLite;

namespace DialcronWinforms.Models;

[Table("cad_cliente")]
public class Cliente
{
    [PrimaryKey, AutoIncrement, Column("cliente")]
    public int ClienteId { get; set; }

    public string? Nome { get; set; }

    public string? Logradouro { get; set; }

    public int? Numero { get; set; }

    [Column("cpf_cnpj")]
    public string? CpfCnpj { get; set; }

    [Column("dta_nascimento")]
    public string? DtaNascimento { get; set; }

    [Column("dta_criacao")]
    public string? DtaCriacao { get; set; }

    [Column("ddd_telefone")]
    public int? DddTelefone { get; set; }

    public int? Telefone { get; set; }

    [Column("ddd_celular")]
    public int? DddCelular { get; set; }

    public int? Celular { get; set; }

    public string? Email { get; set; }

    public string? Sexo { get; set; }
}
