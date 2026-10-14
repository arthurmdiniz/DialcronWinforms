using SQLite;

namespace DialcronWinforms.Models;

[Table("cad_unidade")]
public class Unidade
{
    [PrimaryKey, AutoIncrement, Column("id_unidade")]
    public int IdUnidade { get; set; }

    [Column("nome_fantasia")]
    public string? NomeFantasia { get; set; }

    [Column("razao_social")]
    public string? RazaoSocial { get; set; }

    [Column("cnpj")]
    public string? Cnpj { get; set; }

    [Column("insc_estadual")]
    public string? InscEstadual { get; set; }

    [Column("insc_municipal")]
    public string? InscMunicipal { get; set; }

    [Column("cep")]
    public int? Cep { get; set; }

    [Column("logradouro")]
    public string? Logradouro { get; set; }

    [Column("numero")]
    public int? Numero { get; set; }

    [Column("bairro")]
    public string? Bairro { get; set; }

    [Column("complemento")]
    public string? Complemento { get; set; }

    [Column("municipio")]
    public string? Municipio { get; set; }

    [Column("uf")]
    public string? Uf { get; set; }

    [Column("pais")]
    public string? Pais { get; set; }

    [Column("email")]
    public string? Email { get; set; }

    [Column("ddd")]
    public int? Ddd { get; set; }

    [Column("telefone")]
    public int? Telefone { get; set; }

    [Column("cliente")]
    public int? Cliente { get; set; }
}
