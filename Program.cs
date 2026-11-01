using System.Diagnostics.CodeAnalysis;
using DialcronWinforms.Forms;

namespace DialcronWinforms;

[ExcludeFromCodeCoverage]
internal static class Program
{
    [STAThread]
    private static void Main()
    {
        ApplicationConfiguration.Initialize();
        Application.Run(new MainForm());
    }
}
