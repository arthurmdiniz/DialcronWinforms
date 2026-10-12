using System;
using System.Linq;

namespace DialcronWinforms;

public static class FuncoesGerais
{
    public static int? LerInteiro(string texto)
    {
        var digits = OnlyDigits(texto);
        return int.TryParse(digits, out var valor) ? valor : null;
    }

    public static string OnlyDigits(string s) => new string(s?.Where(char.IsDigit).ToArray() ?? Array.Empty<char>());

    public static int MapDigitsToPosition(string formatted, int digitsBefore)
    {
        var pos = 0;
        var digits = 0;
        while (pos < formatted.Length && digits < digitsBefore)
        {
            if (char.IsDigit(formatted[pos])) digits++;
            pos++;
        }
        return pos;
    }

    public static string FormatCnpj(string text)
    {
        var d = OnlyDigits(text);
        if (d.Length > 14) d = d.Substring(0, 14);
        var len = d.Length;
        if (len == 0) return string.Empty;
        var sb = new System.Text.StringBuilder();
        if (len <= 2)
        {
            sb.Append(d);
            return sb.ToString();
        }
        sb.Append(d.Substring(0, 2));
        if (len <= 5)
        {
            sb.Append('.').Append(d.Substring(2));
            return sb.ToString();
        }
        sb.Append('.').Append(d.Substring(2, 3));
        if (len <= 8)
        {
            sb.Append('.').Append(d.Substring(5));
            return sb.ToString();
        }
        sb.Append('.').Append(d.Substring(5, 3));
        if (len <= 12)
        {
            sb.Append('/').Append(d.Substring(8));
            return sb.ToString();
        }
        sb.Append('/').Append(d.Substring(8, 4));
        if (len <= 12) return sb.ToString();
        sb.Append('-').Append(d.Substring(12));
        return sb.ToString();
    }

    public static string FormatCep(string text)
    {
        var d = OnlyDigits(text);
        if (d.Length > 8) d = d.Substring(0, 8);
        var len = d.Length;
        if (len <= 2) return d;
        if (len <= 5) return d.Substring(0, 2) + "." + d.Substring(2);
        return d.Substring(0, 2) + "." + d.Substring(2, 3) + "-" + d.Substring(5);
    }

    private static string FormatTelephoneGeneric(string d)
    {
        if (d.Length <= 4) return d;
        if (d.Length == 9)
        {
            return d.Insert(1, ".").Insert(6, "-");
        }
        if (d.Length <= 8) return d.Insert(4, "-");
        return d.Insert(d.Length - 4, "-");
    }

    public static string FormatTelefone(string text)
    {
        var d = OnlyDigits(text);
        if (d.Length > 11) d = d.Substring(0, 11);
        return FormatTelephoneGeneric(d);
    }
}
