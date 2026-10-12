namespace DialcronWinforms.Forms;

partial class MainForm
{
    private System.ComponentModel.IContainer components = null;

    private Label lblTitulo;
    private Label lblSubtitulo;
    private Button btnAgenda;
    private Button btnCadastros;
    private Button btnBackup;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        this.lblTitulo = new Label();
        this.lblSubtitulo = new Label();
        this.btnAgenda = new Button();
        this.btnCadastros = new Button();
        this.btnBackup = new Button();
        this.SuspendLayout();

        // lblTitulo
        this.lblTitulo.Text = "Dialcron";
        this.lblTitulo.Font = new Font("Segoe UI", 24, FontStyle.Bold);
        this.lblTitulo.ForeColor = Cores.Primary;
        this.lblTitulo.AutoSize = true;
        this.lblTitulo.Location = new Point(160, 40);

        // lblSubtitulo
        this.lblSubtitulo.Text = "Sistema de agendamentos";
        this.lblSubtitulo.Font = new Font("Segoe UI", 12);
        this.lblSubtitulo.ForeColor = Cores.Gray600;
        this.lblSubtitulo.AutoSize = true;
        this.lblSubtitulo.Location = new Point(150, 85);

        // btnAgenda
        this.btnAgenda.Text = "Agenda";
        this.btnAgenda.Size = new Size(200, 45);
        this.btnAgenda.Location = new Point(125, 140);
        this.btnAgenda.BackColor = Cores.Primary;
        this.btnAgenda.ForeColor = Cores.White;
        this.btnAgenda.FlatStyle = FlatStyle.Flat;
        this.btnAgenda.Font = new Font("Segoe UI", 12);
        this.btnAgenda.FlatAppearance.BorderSize = 0;
        this.btnAgenda.Name = "btnAgenda";

        // btnCadastros
        this.btnCadastros.Text = "Cadastros";
        this.btnCadastros.Size = new Size(200, 45);
        this.btnCadastros.Location = new Point(125, 200);
        this.btnCadastros.BackColor = Cores.Primary;
        this.btnCadastros.ForeColor = Cores.White;
        this.btnCadastros.FlatStyle = FlatStyle.Flat;
        this.btnCadastros.Font = new Font("Segoe UI", 12);
        this.btnCadastros.FlatAppearance.BorderSize = 0;
        this.btnCadastros.Name = "btnCadastros";

        // btnBackup
        this.btnBackup.Text = "Backup";
        this.btnBackup.Size = new Size(200, 45);
        this.btnBackup.Location = new Point(125, 260);
        this.btnBackup.BackColor = Cores.Primary;
        this.btnBackup.ForeColor = Cores.White;
        this.btnBackup.FlatStyle = FlatStyle.Flat;
        this.btnBackup.Font = new Font("Segoe UI", 12);
        this.btnBackup.FlatAppearance.BorderSize = 0;
        this.btnBackup.Name = "btnBackup";

        // MainForm
        this.Text = "Dialcron";
        this.Size = new Size(450, 400);
        this.StartPosition = FormStartPosition.CenterScreen;
        this.ClientSize = new Size(450, 400);
        this.BackColor = Cores.Creme;

        this.Controls.Add(this.lblTitulo);
        this.Controls.Add(this.lblSubtitulo);
        this.Controls.Add(this.btnAgenda);
        this.Controls.Add(this.btnCadastros);
        this.Controls.Add(this.btnBackup);
        this.ResumeLayout(false);
        this.PerformLayout();
    }
}
