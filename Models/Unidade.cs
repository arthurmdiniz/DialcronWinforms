using SQLite;

namespace DialcronWinforms.Models;

public class Unidade
{
    [PrimaryKey, AutoIncrement]
    public int IdUnidade { get; set; }

    public string? NomeFantasia { get; set; }

    public string? RazaoSocial { get; set; }

    public string? Cnpj { get; set; }

    public string? InscEstadual { get; set; }

    public string? InscMunicipal { get; set; }

    public int? Cep { get; set; }

    public string? Logradouro { get; set; }

    public int? Numero { get; set; }

    public string? Bairro { get; set; }

    public string? Complemento { get; set; }

    public string? Municipio { get; set; }

    public string? Uf { get; set; }

    public string? Pais { get; set; }

    public string? Email { get; set; }

    public int? Ddd { get; set; }

    public int? Telefone { get; set; }

    public int? Cliente { get; set; }
}
