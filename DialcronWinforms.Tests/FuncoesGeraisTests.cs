namespace DialcronWinforms.Tests;

public class FuncoesGeraisTests
{
    [Theory]
    [InlineData("123", 123)]
    [InlineData(" 12.345 ", 12345)]
    [InlineData("abc123def", 123)]
    [InlineData("0", 0)]
    [InlineData("", null)]
    [InlineData("abc", null)]
    [InlineData(null, null)]
    [InlineData("999999999999999999999", null)]
    public void LerInteiro_ConverteSomenteDigitos(string? texto, int? esperado)
    {
        Assert.Equal(esperado, FuncoesGerais.LerInteiro(texto!));
    }

    [Theory]
    [InlineData("123,45", "123.45")]
    [InlineData("123.45", "123.45")]
    [InlineData("R$ 1.234,56", "1.23456")]
    [InlineData("1.234.56", "1.23456")]
    [InlineData("0", "0")]
    [InlineData("", null)]
    [InlineData("   ", null)]
    [InlineData("abc", null)]
    [InlineData(null, null)]
    [InlineData("1,2,3", "1.23")]
    public void LerDecimal_ConverteTextoNumerico(string? texto, string? esperadoTexto)
    {
        decimal? esperado = esperadoTexto is null
            ? null
            : decimal.Parse(esperadoTexto, System.Globalization.CultureInfo.InvariantCulture);

        Assert.Equal(esperado, FuncoesGerais.LerDecimal(texto!));
    }

    [Theory]
    [InlineData("12.3-45/6", "123456")]
    [InlineData("abc", "")]
    [InlineData("", "")]
    [InlineData(null, "")]
    [InlineData("00123", "00123")]
    public void OnlyDigits_RetornaSomenteDigitos(string? texto, string esperado)
    {
        Assert.Equal(esperado, FuncoesGerais.OnlyDigits(texto!));
    }

    [Theory]
    [InlineData("12.34-56", 0, 0)]
    [InlineData("12.34-56", 1, 1)]
    [InlineData("12.34-56", 2, 2)]
    [InlineData("12.34-56", 3, 4)]
    [InlineData("12.34-56", 4, 5)]
    [InlineData("12.34-56", 6, 8)]
    [InlineData("12.34-56", 99, 8)]
    [InlineData("12.34-56", -1, 0)]
    [InlineData("", 3, 0)]
    public void MapDigitsToPosition_MapeiaQuantidadeDeDigitos(string formatted, int digitsBefore, int esperado)
    {
        Assert.Equal(esperado, FuncoesGerais.MapDigitsToPosition(formatted, digitsBefore));
    }

    [Theory]
    [InlineData(null, "")]
    [InlineData("", "")]
    [InlineData("abc", "")]
    [InlineData("1", "1")]
    [InlineData("12", "12")]
    [InlineData("123", "12.3")]
    [InlineData("12345", "12.345")]
    [InlineData("123456", "12.345.6")]
    [InlineData("12345678", "12.345.678")]
    [InlineData("123456789", "12.345.678/9")]
    [InlineData("123456789012", "12.345.678/9012")]
    [InlineData("1234567890123", "12.345.678/9012-3")]
    [InlineData("12345678901234", "12.345.678/9012-34")]
    [InlineData("123456789012345", "12.345.678/9012-34")]
    [InlineData("12.345.678/9012-34", "12.345.678/9012-34")]
    public void FormatCnpj_FormataAteQuatorzeDigitos(string? texto, string esperado)
    {
        Assert.Equal(esperado, FuncoesGerais.FormatCnpj(texto!));
    }

    [Theory]
    [InlineData(null, "")]
    [InlineData("", "")]
    [InlineData("abc", "")]
    [InlineData("1", "1")]
    [InlineData("12", "12")]
    [InlineData("123", "12.3")]
    [InlineData("12345", "12.345")]
    [InlineData("123456", "12.345-6")]
    [InlineData("1234567", "12.345-67")]
    [InlineData("12345678", "12.345-678")]
    [InlineData("123456789", "12.345-678")]
    [InlineData("12.345-678", "12.345-678")]
    public void FormatCep_FormataAteOitoDigitos(string? texto, string esperado)
    {
        Assert.Equal(esperado, FuncoesGerais.FormatCep(texto!));
    }

    [Theory]
    [InlineData(null, "")]
    [InlineData("", "")]
    [InlineData("abc", "")]
    [InlineData("1", "1")]
    [InlineData("1234", "1234")]
    [InlineData("12345", "1234-5")]
    [InlineData("12345678", "1234-5678")]
    [InlineData("123456789", "1.2345-6789")]
    [InlineData("1234567890", "123456-7890")]
    [InlineData("12345678901", "1234567-8901")]
    [InlineData("123456789012", "1234567-8901")]
    [InlineData("(11) 98765-4321", "1198765-4321")]
    public void FormatTelefone_FormataELimitaAOnzeDigitos(string? texto, string esperado)
    {
        Assert.Equal(esperado, FuncoesGerais.FormatTelefone(texto!));
    }
}
