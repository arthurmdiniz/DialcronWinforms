using System.Diagnostics.CodeAnalysis;

namespace DialcronWinforms.Controls;

[ExcludeFromCodeCoverage]
public partial class CadastrosUC : UserControl
{
    public event EventHandler? ClientesClicked;
    public event EventHandler? ServicosClicked;
    public event EventHandler? ProfissionaisClicked;
    public event EventHandler? UnidadesClicked;

    public CadastrosUC()
    {
        InitializeComponent();

        btnClientes.Click += (s, e) => ClientesClicked?.Invoke(this, e);
        btnServicos.Click += (s, e) => ServicosClicked?.Invoke(this, e);
        btnProfissionais.Click += (s, e) => ProfissionaisClicked?.Invoke(this, e);
        btnUnidades.Click += (s, e) => UnidadesClicked?.Invoke(this, e);
    }
}
