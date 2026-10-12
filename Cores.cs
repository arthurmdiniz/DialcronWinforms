using System.Drawing;

namespace DialcronWinforms;

public static class Cores
{
    // IDENTIDADE VISUAL E NAVEGAÇÃO
    // Botões principais, menu lateral e ações de destaque.
    public static Color Primary = ColorTranslator.FromHtml("#8E3B52");

    // Realces, estados de interação e elementos secundários.
    public static Color PrimaryDark = ColorTranslator.FromHtml("#DFA6AF");

    // Elementos selecionados, ícones e links.
    public static Color Tertiary = ColorTranslator.FromHtml("#C77C8A");


    // FUNDOS E SUPERFÍCIES
    // Fundo principal das janelas.
    public static Color Creme = ColorTranslator.FromHtml("#FFF8F5");

    // Fundo de cards, campos e caixas de diálogo.
    public static Color White = ColorTranslator.FromHtml("#FFFFFF");

    // Fundos de painéis, seções e áreas secundárias.
    public static Color Secondary = ColorTranslator.FromHtml("#F5E8E5");

    // Bordas e separadores discretos.
    public static Color Gray200 = ColorTranslator.FromHtml("#E7D3D1");

    // Contornos de campos e componentes.
    public static Color Gray300 = ColorTranslator.FromHtml("#D2B9B7");

    // Bordas e separadores com maior destaque.
    public static Color Gray400 = ColorTranslator.FromHtml("#B99FA0");


    // TEXTOS E ÍCONES
    // Títulos, textos principais e informações importantes.
    public static Color PrimaryDarkText = ColorTranslator.FromHtml("#3B3032");

    // Textos secundários, legendas e descrições.
    public static Color Gray500 = ColorTranslator.FromHtml("#75696B");

    // Textos de apoio e ícones.
    public static Color Gray600 = ColorTranslator.FromHtml("#5C4B4E");

    // Textos e elementos escuros de alto contraste.
    public static Color Black = ColorTranslator.FromHtml("#3B3032");

    // Destaques e ícones em contextos com contraste adequado.
    public static Color Magenta = ColorTranslator.FromHtml("#C77C8A");

    // Elementos escuros e textos de alto contraste.
    public static Color MidnightBlue = ColorTranslator.FromHtml("#3B3032");


    // ESCALA DE TONS PARA FUNDOS E ELEMENTOS
    // Fundos claros e áreas de conteúdo secundárias.
    public static Color Gray100 = ColorTranslator.FromHtml("#F5E8E5");

    // Fundos e elementos intermediários.
    public static Color Gray900 = ColorTranslator.FromHtml("#3B3032");

    // Fundos profundos e elementos escuros.
    public static Color Gray950 = ColorTranslator.FromHtml("#2F1D23");

    // Fundos escuros e áreas de alto contraste.
    public static Color OffBlack = ColorTranslator.FromHtml("#2F1D23");


    // TEMA ESCURO - Será implementado futuramente para suportar o modo escuro no aplicativo.
    // Fundo principal das janelas no tema escuro.
    public static Color DarkBackground = ColorTranslator.FromHtml("#2F1D23");

    // Fundo de cards, painéis e campos no tema escuro.
    public static Color DarkSurface = ColorTranslator.FromHtml("#3B262C");

    // Textos principais sobre fundos escuros.
    public static Color DarkText = ColorTranslator.FromHtml("#F5E8E5");

    // Textos secundários e informações complementares no tema escuro.
    public static Color DarkTextSecondary = ColorTranslator.FromHtml("#DFA6AF");

    // Texto secundário em contextos específicos com contraste adequado.
    public static Color SecondaryDarkText = ColorTranslator.FromHtml("#DFA6AF");


    // STATUS DOS AGENDAMENTOS E OPERAÇÕES
    // Agendamentos confirmados e operações concluídas.
    public static Color Sucesso = ColorTranslator.FromHtml("#72A68A");

    // Agendamentos pendentes e avisos.
    public static Color Atencao = ColorTranslator.FromHtml("#D6A84F");

    // Agendamentos cancelados, erros e alertas críticos.
    public static Color Erro = ColorTranslator.FromHtml("#C95C62");
}
