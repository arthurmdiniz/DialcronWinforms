namespace DialcronWinforms.Controls;

partial class CadastrosUC
{
    private System.ComponentModel.IContainer components = null;

    private Label lblTitulo;
    private Button btnClientes;
    private Button btnServicos;
    private Button btnProfissionais;
    private Button btnUnidades;

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
        btn.Font = new Font("Segoe UI", 11);
    }

    private void InitializeComponent()
    {
        this.lblTitulo = new Label();
        this.btnClientes = new Button();
        this.btnServicos = new Button();
        this.btnProfissionais = new Button();
        this.btnUnidades = new Button();
        this.SuspendLayout();

        // lblTitulo
        this.lblTitulo.Text = "Cadastros";
        this.lblTitulo.Font = new Font("Segoe UI", 20, FontStyle.Bold);
        this.lblTitulo.ForeColor = Cores.Primary;
        this.lblTitulo.AutoSize = true;
        this.lblTitulo.Location = new Point(140, 30);
        this.lblTitulo.Anchor = AnchorStyles.Top | AnchorStyles.Left;

        // btnClientes
        this.btnClientes.Text = "Clientes";
        this.btnClientes.Size = new Size(200, 40);
        this.btnClientes.Location = new Point(100, 90);
        this.btnClientes.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        this.btnClientes.Name = "btnClientes";
        this.ConfigurarBotao(this.btnClientes);

        // btnServicos
        this.btnServicos.Text = "Servicos";
        this.btnServicos.Size = new Size(200, 40);
        this.btnServicos.Location = new Point(100, 145);
        this.btnServicos.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        this.btnServicos.Name = "btnServicos";
        this.ConfigurarBotao(this.btnServicos);

        // btnProfissionais
        this.btnProfissionais.Text = "Profissionais";
        this.btnProfissionais.Size = new Size(200, 40);
        this.btnProfissionais.Location = new Point(100, 200);
        this.btnProfissionais.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        this.btnProfissionais.Name = "btnProfissionais";
        this.ConfigurarBotao(this.btnProfissionais);

        // btnUnidades
        this.btnUnidades.Text = "Unidades";
        this.btnUnidades.Size = new Size(200, 40);
        this.btnUnidades.Location = new Point(100, 255);
        this.btnUnidades.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        this.btnUnidades.Name = "btnUnidades";
        this.ConfigurarBotao(this.btnUnidades);

        // CadastrosUC
        this.Name = "CadastrosUC";
        this.ClientSize = new Size(400, 400);
        this.Dock = DockStyle.Fill;
        this.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        this.Padding = new Padding(20);
        this.AutoScroll = true;
        this.BackColor = Cores.Creme;

        this.Controls.Add(this.lblTitulo);
        this.Controls.Add(this.btnClientes);
        this.Controls.Add(this.btnServicos);
        this.Controls.Add(this.btnProfissionais);
        this.Controls.Add(this.btnUnidades);
        this.ResumeLayout(false);
        this.PerformLayout();
    }
}
