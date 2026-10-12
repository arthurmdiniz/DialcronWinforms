using DialcronWinforms.Controls;
using DialcronWinforms.Data;
using DialcronWinforms.Data.DAO;
using DialcronWinforms.Navigation;

namespace DialcronWinforms.Forms;

public partial class MainForm : Form
{
    private AgendaUC? _agendaUC;
    private CadastrosUC? _cadastrosUC;
    private ClienteUC? _clienteUC;
    private ServicoUC? _servicoUC;
    private ProfissionalUC? _profissionalUC;
    private UnidadeUC? _unidadeUC;

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

        _cadastrosUC = new CadastrosUC();
        _cadastrosUC.ClientesClicked += (s, e) => NavigateToCliente();
        _cadastrosUC.ServicosClicked += (s, e) => NavigateToServico();
        _cadastrosUC.ProfissionaisClicked += (s, e) => NavigateToProfissional();
        _cadastrosUC.UnidadesClicked += (s, e) => NavigateToUnidade();

        btnAgenda.Click += BtnAgenda_Click;
        btnCadastros.Click += BtnCadastros_Click;
        btnBackup.Click += BtnBackup_Click;
    }

    private void BtnAgenda_Click(object? sender, EventArgs e)
    {
        _agendaUC ??= new AgendaUC();
        NavigationHelper.NavigateTo(_agendaUC);
    }

    private void BtnCadastros_Click(object? sender, EventArgs e)
    {
        NavigationHelper.NavigateTo(_cadastrosUC!);
    }

    private void NavigateToCliente()
    {
        _clienteUC ??= new ClienteUC();
        NavigationHelper.NavigateTo(_clienteUC);
    }

    private void NavigateToServico()
    {
        _servicoUC ??= new ServicoUC();
        NavigationHelper.NavigateTo(_servicoUC);
    }

    private void NavigateToProfissional()
    {
        _profissionalUC ??= new ProfissionalUC();
        NavigationHelper.NavigateTo(_profissionalUC);
    }

    private void NavigateToUnidade()
    {
        _unidadeUC ??= new UnidadeUC();
        NavigationHelper.NavigateTo(_unidadeUC);
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
