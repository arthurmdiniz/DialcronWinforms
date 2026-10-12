namespace DialcronWinforms.Forms;

partial class CadastrosForm
{
    private System.ComponentModel.IContainer components = null;

    private Label lblTitulo;
    private Button btnClientes;
    private Button btnServicos;
    private Button btnProfissionais;
    private Button btnUnidades;
    private Button btnVoltar;

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
        this.btnClientes = new Button();
        this.btnServicos = new Button();
        this.btnProfissionais = new Button();
        this.btnUnidades = new Button();
        this.btnVoltar = new Button();
        this.SuspendLayout();

        // lblTitulo
        this.lblTitulo.Text = "Cadastros";
        this.lblTitulo.Font = new Font("Segoe UI", 20, FontStyle.Bold);
        this.lblTitulo.ForeColor = Cores.Primary;
        this.lblTitulo.AutoSize = true;
        this.lblTitulo.Location = new Point(140, 30);

        // btnClientes
        this.btnClientes.Text = "Clientes";
        this.btnClientes.Size = new Size(200, 40);
        this.btnClientes.Location = new Point(100, 90);
        this.btnClientes.BackColor = Cores.Primary;
        this.btnClientes.ForeColor = Cores.White;
        this.btnClientes.FlatStyle = FlatStyle.Flat;
        this.btnClientes.Font = new Font("Segoe UI", 11);
        this.btnClientes.FlatAppearance.BorderSize = 0;
        this.btnClientes.Name = "btnClientes";

        // btnServicos
        this.btnServicos.Text = "Servicos";
        this.btnServicos.Size = new Size(200, 40);
        this.btnServicos.Location = new Point(100, 145);
        this.btnServicos.BackColor = Cores.Primary;
        this.btnServicos.ForeColor = Cores.White;
        this.btnServicos.FlatStyle = FlatStyle.Flat;
        this.btnServicos.Font = new Font("Segoe UI", 11);
        this.btnServicos.FlatAppearance.BorderSize = 0;
        this.btnServicos.Name = "btnServicos";

        // btnProfissionais
        this.btnProfissionais.Text = "Profissionais";
        this.btnProfissionais.Size = new Size(200, 40);
        this.btnProfissionais.Location = new Point(100, 200);
        this.btnProfissionais.BackColor = Cores.Primary;
        this.btnProfissionais.ForeColor = Cores.White;
        this.btnProfissionais.FlatStyle = FlatStyle.Flat;
        this.btnProfissionais.Font = new Font("Segoe UI", 11);
        this.btnProfissionais.FlatAppearance.BorderSize = 0;
        this.btnProfissionais.Name = "btnProfissionais";

        // btnUnidades
        this.btnUnidades.Text = "Unidades";
        this.btnUnidades.Size = new Size(200, 40);
        this.btnUnidades.Location = new Point(100, 255);
        this.btnUnidades.BackColor = Cores.Primary;
        this.btnUnidades.ForeColor = Cores.White;
        this.btnUnidades.FlatStyle = FlatStyle.Flat;
        this.btnUnidades.Font = new Font("Segoe UI", 11);
        this.btnUnidades.FlatAppearance.BorderSize = 0;
        this.btnUnidades.Name = "btnUnidades";

        // btnVoltar
        this.btnVoltar.Text = "Voltar";
        this.btnVoltar.Size = new Size(100, 35);
        this.btnVoltar.Location = new Point(150, 310);
        this.btnVoltar.BackColor = Cores.Gray200;
        this.btnVoltar.ForeColor = Cores.Gray900;
        this.btnVoltar.FlatStyle = FlatStyle.Flat;
        this.btnVoltar.Font = new Font("Segoe UI", 10);
        this.btnVoltar.FlatAppearance.BorderSize = 0;
        this.btnVoltar.Name = "btnVoltar";

        // CadastrosForm
        this.Text = "Cadastros";
        this.ClientSize = new Size(400, 400);
        this.StartPosition = FormStartPosition.CenterScreen;
        this.BackColor = Cores.Creme;

        this.Controls.Add(this.lblTitulo);
        this.Controls.Add(this.btnClientes);
        this.Controls.Add(this.btnServicos);
        this.Controls.Add(this.btnProfissionais);
        this.Controls.Add(this.btnUnidades);
        this.Controls.Add(this.btnVoltar);
        this.ResumeLayout(false);
        this.PerformLayout();
    }
}
