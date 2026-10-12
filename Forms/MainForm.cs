namespace DialcronWinforms.Forms;

public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();

        btnAgenda.Click += BtnAgenda_Click;
        btnCadastros.Click += BtnCadastros_Click;
        btnBackup.Click += BtnBackup_Click;
    }

    private void BtnAgenda_Click(object? sender, EventArgs e)
    {
        var form = new AgendaForm();
        form.ShowDialog(this);
    }

    private void BtnCadastros_Click(object? sender, EventArgs e)
    {
        var form = new CadastrosForm();
        form.ShowDialog(this);
    }

    private void BtnBackup_Click(object? sender, EventArgs e)
    {
        // TODO: Implementar lógica de backup
        MessageBox.Show("Funcionalidade de backup em desenvolvimento.", "Backup",
            MessageBoxButtons.OK, MessageBoxIcon.Information);
    }
}
