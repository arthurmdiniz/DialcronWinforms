namespace DialcronWinforms.Forms;

public partial class CadastrosForm : Form
{
    public CadastrosForm()
    {
        InitializeComponent();

        btnClientes.Click += BtnClientes_Click;
        btnServicos.Click += BtnServicos_Click;
        btnProfissionais.Click += BtnProfissionais_Click;
        btnUnidades.Click += BtnUnidades_Click;
        btnVoltar.Click += BtnVoltar_Click;
    }

    private void BtnClientes_Click(object? sender, EventArgs e)
    {
        var form = new ClienteForm();
        form.ShowDialog(this);
    }

    private void BtnServicos_Click(object? sender, EventArgs e)
    {
        var form = new ServicoForm();
        form.ShowDialog(this);
    }

    private void BtnProfissionais_Click(object? sender, EventArgs e)
    {
        var form = new ProfissionalForm();
        form.ShowDialog(this);
    }

    private void BtnUnidades_Click(object? sender, EventArgs e)
    {
        var form = new UnidadeForm();
        form.ShowDialog(this);
    }

    private void BtnVoltar_Click(object? sender, EventArgs e)
    {
        this.Close();
    }
}
