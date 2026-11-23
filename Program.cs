using System.Diagnostics.CodeAnalysis;
using DialcronWinforms.Forms;

namespace DialcronWinforms;

[ExcludeFromCodeCoverage]
internal static class Program
{
    [STAThread]
    private static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        Application.SetHighDpiMode(HighDpiMode.DpiUnaware);
        Application.Run(new MainForm());
    }
}
