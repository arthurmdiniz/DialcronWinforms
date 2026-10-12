namespace DialcronWinforms.Forms;

partial class MainForm
{
    private System.ComponentModel.IContainer components = null;

    private TableLayoutPanel tlpLayout;
    private Panel pnlBotoes;
    private Panel pnlConteudo;
    private PictureBox picLogo;
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

    private void ConfigurarBotao(Button btn)
    {
        btn.BackColor = Cores.Primary;
        btn.ForeColor = Cores.White;
        btn.FlatStyle = FlatStyle.Flat;
        btn.FlatAppearance.BorderSize = 0;
        btn.FlatAppearance.MouseOverBackColor = Cores.Tertiary;
        btn.FlatAppearance.MouseDownBackColor = Cores.Primary;
        btn.Font = new Font("Segoe UI", 12);
    }

    private void InitializeComponent()
    {
        tlpLayout = new TableLayoutPanel();
        pnlBotoes = new Panel();
        picLogo = new PictureBox();
        lblSubtitulo = new Label();
        btnAgenda = new Button();
        btnCadastros = new Button();
        btnBackup = new Button();
        pnlConteudo = new Panel();
        tlpLayout.SuspendLayout();
        pnlBotoes.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)picLogo).BeginInit();
        SuspendLayout();
        //
        // tlpLayout
        //
        tlpLayout.ColumnCount = 2;
        tlpLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 240F));
        tlpLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
        tlpLayout.Controls.Add(pnlBotoes, 0, 0);
        tlpLayout.Controls.Add(pnlConteudo, 1, 0);
        tlpLayout.Dock = DockStyle.Fill;
        tlpLayout.Location = new Point(0, 0);
        tlpLayout.Name = "tlpLayout";
        tlpLayout.RowCount = 1;
        tlpLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
        tlpLayout.Size = new Size(900, 650);
        tlpLayout.TabIndex = 0;
        //
        // pnlBotoes
        //
        pnlBotoes.AutoScroll = true;
        pnlBotoes.BackColor = Cores.Creme;
        pnlBotoes.Controls.Add(picLogo);
        pnlBotoes.Controls.Add(lblSubtitulo);
        pnlBotoes.Controls.Add(btnAgenda);
        pnlBotoes.Controls.Add(btnCadastros);
        pnlBotoes.Controls.Add(btnBackup);
        pnlBotoes.Dock = DockStyle.Fill;
        pnlBotoes.Location = new Point(3, 3);
        pnlBotoes.Name = "pnlBotoes";
        pnlBotoes.Padding = new Padding(20);
        pnlBotoes.Size = new Size(234, 644);
        pnlBotoes.TabIndex = 0;
        //
        // picLogo
        //
        picLogo.BackColor = Cores.Creme;
        picLogo.Location = new Point(20, 20);
        picLogo.Name = "picLogo";
        picLogo.Size = new Size(120, 120);
        picLogo.SizeMode = PictureBoxSizeMode.Zoom;
        picLogo.TabIndex = 0;
        picLogo.TabStop = false;
        //
        // lblSubtitulo
        //
        lblSubtitulo.AutoSize = true;
        lblSubtitulo.Font = new Font("Segoe UI", 12F);
        lblSubtitulo.ForeColor = Cores.Gray600;
        lblSubtitulo.Location = new Point(20, 150);
        lblSubtitulo.Name = "lblSubtitulo";
        lblSubtitulo.Size = new Size(193, 21);
        lblSubtitulo.TabIndex = 1;
        lblSubtitulo.Text = "Sistema de agendamentos";
        //
        // btnAgenda
        //
        btnAgenda.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        btnAgenda.Location = new Point(20, 185);
        btnAgenda.Name = "btnAgenda";
        btnAgenda.Size = new Size(190, 42);
        btnAgenda.TabIndex = 2;
        btnAgenda.Text = "Agenda";
        ConfigurarBotao(btnAgenda);
        //
        // btnCadastros
        //
        btnCadastros.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        btnCadastros.Location = new Point(20, 237);
        btnCadastros.Name = "btnCadastros";
        btnCadastros.Size = new Size(190, 42);
        btnCadastros.TabIndex = 3;
        btnCadastros.Text = "Cadastros";
        ConfigurarBotao(btnCadastros);
        //
        // btnBackup
        //
        btnBackup.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        btnBackup.Location = new Point(20, 289);
        btnBackup.Name = "btnBackup";
        btnBackup.Size = new Size(190, 42);
        btnBackup.TabIndex = 4;
        btnBackup.Text = "Backup";
        ConfigurarBotao(btnBackup);
        //
        // pnlConteudo
        //
        pnlConteudo.BackColor = Cores.Creme;
        pnlConteudo.BorderStyle = BorderStyle.FixedSingle;
        pnlConteudo.Dock = DockStyle.Fill;
        pnlConteudo.Location = new Point(243, 3);
        pnlConteudo.Name = "pnlConteudo";
        pnlConteudo.Size = new Size(654, 644);
        pnlConteudo.TabIndex = 1;
        //
        // MainForm
        //
        BackColor = Cores.Creme;
        ClientSize = new Size(900, 650);
        Controls.Add(tlpLayout);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        ForeColor = Cores.Gray900;
        MaximizeBox = false;
        MinimumSize = new Size(900, 650);
        Name = "MainForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "Dialcron";
        ((System.ComponentModel.ISupportInitialize)picLogo).EndInit();
        tlpLayout.ResumeLayout(false);
        pnlBotoes.ResumeLayout(false);
        pnlBotoes.PerformLayout();
        ResumeLayout(false);
    }
}
