using System.Diagnostics.CodeAnalysis;
using DialcronWinforms.Controls;
using DialcronWinforms.Data;
using DialcronWinforms.Data.DAO;
using DialcronWinforms.Navigation;

namespace DialcronWinforms.Forms;

[ExcludeFromCodeCoverage]
public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();

        using (var stream = GetType().Assembly.GetManifestResourceStream("favicon.ico"))
        {
            if (stream is not null)
                Icon = new Icon(stream);
        }

        using (var stream = GetType().Assembly.GetManifestResourceStream("LogoTransparente.png"))
        {
            if (stream is not null)
            {
                var buffer = new MemoryStream();
                stream.CopyTo(buffer);
                buffer.Position = 0;
                picLogo.Image = Image.FromStream(buffer);
            }
        }

        NavigationHelper.Initialize(pnlConteudo);

        btnAgenda.Click += BtnAgenda_Click;
        btnCadastros.Click += BtnCadastros_Click;
        btnBackup.Click += BtnBackup_Click;
    }

    private void BtnAgenda_Click(object? sender, EventArgs e)
    {
        NavigationHelper.NavigateTo(new AgendaUC());
    }

    private void BtnCadastros_Click(object? sender, EventArgs e)
    {
        var cadastros = new CadastrosUC();
        cadastros.ClientesClicked += (s, args) => NavigateToCliente();
        cadastros.ServicosClicked += (s, args) => NavigateToServico();
        cadastros.ProfissionaisClicked += (s, args) => NavigateToProfissional();
        cadastros.UnidadesClicked += (s, args) => NavigateToUnidade();
        NavigationHelper.NavigateTo(cadastros);
    }

    private static void NavigateToCliente()
    {
        NavigationHelper.NavigateTo(new ClienteUC());
    }

    private static void NavigateToServico()
    {
        NavigationHelper.NavigateTo(new ServicoUC());
    }

    private static void NavigateToProfissional()
    {
        NavigationHelper.NavigateTo(new ProfissionalUC());
    }

    private static void NavigateToUnidade()
    {
        NavigationHelper.NavigateTo(new UnidadeUC());
    }

    private async void BtnBackup_Click(object? sender, EventArgs e)
    {
        var connection = await Database.Instance.InitializeAsync();
        var backupDao = new BackupDAO(connection);

        var fileName = BackupDAO.BuildBackupFileName();

        using var dialog = new SaveFileDialog
        {
            Title = "Salvar Backup",
            Filter = "SQLite Database (*.db)|*.db",
            FileName = fileName,
            InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
        };

        if (dialog.ShowDialog(this) != DialogResult.OK)
            return;

        try
        {
            await backupDao.CreateBackupAsync(dialog.FileName);
            MessageBox.Show($"Backup salvo com sucesso!\n\n{dialog.FileName}", "Backup",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Erro ao criar backup:\n\n{ex.Message}", "Erro",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
