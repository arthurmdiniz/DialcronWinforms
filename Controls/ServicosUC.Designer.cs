namespace DialcronWinforms.Controls;

partial class ServicoUC
{
    private System.ComponentModel.IContainer components = null;

    private Label lblTitulo;
    private GroupBox grpLista;
    private DataGridView dgvServicos;
    private DataGridViewTextBoxColumn colId;
    private DataGridViewTextBoxColumn colNome;
    private GroupBox grpDados;
    private Label lblUnidade;
    private ComboBox cbxUnidade;
    private Label lblNome;
    private TextBox txtNome;
    private Label lblPreco;
    private TextBox txtPreco;
    private Label lblTempo;
    private TextBox txtTempo;
    private CheckBox chkAtivo;
    private Button btnNovo;
    private Button btnSalvar;

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
        lblTitulo = new Label();
        grpLista = new GroupBox();
        dgvServicos = new DataGridView();
        grpDados = new GroupBox();
        lblUnidade = new Label();
        cbxUnidade = new ComboBox();
        lblNome = new Label();
        txtNome = new TextBox();
        lblPreco = new Label();
        txtPreco = new TextBox();
        lblTempo = new Label();
        txtTempo = new TextBox();
        chkAtivo = new CheckBox();
        btnNovo = new Button();
        btnSalvar = new Button();
        grpLista.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvServicos).BeginInit();
        grpDados.SuspendLayout();
        SuspendLayout();
        // 
        // lblTitulo
        // 
        lblTitulo.AutoSize = true;
        lblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
        lblTitulo.ForeColor = Color.FromArgb(59, 48, 50);
        lblTitulo.Location = new Point(15, 10);
        lblTitulo.Name = "lblTitulo";
        lblTitulo.Size = new Size(230, 30);
        lblTitulo.TabIndex = 0;
        lblTitulo.Text = "Cadastro de Serviços";
        // 
        // grpLista
        // 
        grpLista.BackColor = Color.FromArgb(255, 255, 255);
        grpLista.Controls.Add(dgvServicos);
        grpLista.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        grpLista.ForeColor = Color.FromArgb(92, 75, 78);
        grpLista.Location = new Point(15, 50);
        grpLista.Name = "grpLista";
        grpLista.Size = new Size(624, 206);
        grpLista.TabIndex = 1;
        grpLista.TabStop = false;
        grpLista.Text = "Lista";
        // 
        // dgvServicos
        // 
        dgvServicos.AllowUserToAddRows = false;
        dgvServicos.AllowUserToDeleteRows = false;
        dgvServicos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvServicos.BackgroundColor = Color.FromArgb(255, 255, 255);
        dgvServicos.BorderStyle = BorderStyle.None;
        dgvServicos.Font = new Font("Segoe UI", 9F);
        dgvServicos.Location = new Point(12, 25);
        dgvServicos.MultiSelect = false;
        dgvServicos.Name = "dgvServicos";
        dgvServicos.ReadOnly = true;
        dgvServicos.RowHeadersVisible = false;
        dgvServicos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvServicos.Size = new Size(600, 175);
        dgvServicos.TabIndex = 0;
        // 
        // grpDados
        // 
        grpDados.BackColor = Color.FromArgb(255, 255, 255);
        grpDados.Controls.Add(lblUnidade);
        grpDados.Controls.Add(cbxUnidade);
        grpDados.Controls.Add(lblNome);
        grpDados.Controls.Add(txtNome);
        grpDados.Controls.Add(lblPreco);
        grpDados.Controls.Add(txtPreco);
        grpDados.Controls.Add(lblTempo);
        grpDados.Controls.Add(txtTempo);
        grpDados.Controls.Add(chkAtivo);
        grpDados.Controls.Add(btnNovo);
        grpDados.Controls.Add(btnSalvar);
        grpDados.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        grpDados.ForeColor = Color.FromArgb(92, 75, 78);
        grpDados.Location = new Point(15, 262);
        grpDados.Name = "grpDados";
        grpDados.Size = new Size(624, 258);
        grpDados.TabIndex = 2;
        grpDados.TabStop = false;
        grpDados.Text = "Dados";
        // 
        // lblUnidade
        // 
        lblUnidade.AutoSize = true;
        lblUnidade.Font = new Font("Segoe UI", 9F);
        lblUnidade.ForeColor = Color.FromArgb(59, 48, 50);
        lblUnidade.Location = new Point(12, 28);
        lblUnidade.Name = "lblUnidade";
        lblUnidade.Size = new Size(51, 15);
        lblUnidade.TabIndex = 0;
        lblUnidade.Text = "Unidade";
        // 
        // cbxUnidade
        // 
        cbxUnidade.DropDownStyle = ComboBoxStyle.DropDownList;
        cbxUnidade.Font = new Font("Segoe UI", 9F);
        cbxUnidade.FormattingEnabled = true;
        cbxUnidade.Location = new Point(12, 46);
        cbxUnidade.Name = "cbxUnidade";
        cbxUnidade.Size = new Size(130, 23);
        cbxUnidade.TabIndex = 1;
        // 
        // lblNome
        // 
        lblNome.AutoSize = true;
        lblNome.Font = new Font("Segoe UI", 9F);
        lblNome.ForeColor = Color.FromArgb(59, 48, 50);
        lblNome.Location = new Point(156, 28);
        lblNome.Name = "lblNome";
        lblNome.Size = new Size(40, 15);
        lblNome.TabIndex = 2;
        lblNome.Text = "Nome";
        // 
        // txtNome
        // 
        txtNome.Font = new Font("Segoe UI", 9F);
        txtNome.Location = new Point(156, 46);
        txtNome.Name = "txtNome";
        txtNome.Size = new Size(181, 23);
        txtNome.TabIndex = 3;
        // 
        // lblPreco
        // 
        lblPreco.AutoSize = true;
        lblPreco.Font = new Font("Segoe UI", 9F);
        lblPreco.ForeColor = Color.FromArgb(59, 48, 50);
        lblPreco.Location = new Point(343, 28);
        lblPreco.Name = "lblPreco";
        lblPreco.Size = new Size(37, 15);
        lblPreco.TabIndex = 4;
        lblPreco.Text = "Preço";
        // 
        // txtPreco
        // 
        txtPreco.Font = new Font("Segoe UI", 9F);
        txtPreco.Location = new Point(343, 46);
        txtPreco.Name = "txtPreco";
        txtPreco.Size = new Size(115, 23);
        txtPreco.TabIndex = 5;
        // 
        // lblTempo
        // 
        lblTempo.AutoSize = true;
        lblTempo.Font = new Font("Segoe UI", 9F);
        lblTempo.ForeColor = Color.FromArgb(59, 48, 50);
        lblTempo.Location = new Point(472, 28);
        lblTempo.Name = "lblTempo";
        lblTempo.Size = new Size(43, 15);
        lblTempo.TabIndex = 12;
        lblTempo.Text = "Tempo";
        // 
        // txtTempo
        // 
        txtTempo.Font = new Font("Segoe UI", 9F);
        txtTempo.Location = new Point(472, 46);
        txtTempo.Name = "txtTempo";
        txtTempo.Size = new Size(88, 23);
        txtTempo.TabIndex = 13;
        // 
        // chkAtivo
        // 
        chkAtivo.AutoSize = true;
        chkAtivo.Checked = true;
        chkAtivo.CheckState = CheckState.Checked;
        chkAtivo.Font = new Font("Segoe UI", 9F);
        chkAtivo.ForeColor = Color.FromArgb(59, 48, 50);
        chkAtivo.Location = new Point(566, 46);
        chkAtivo.Name = "chkAtivo";
        chkAtivo.Size = new Size(54, 19);
        chkAtivo.TabIndex = 18;
        chkAtivo.Text = "Ativo";
        chkAtivo.UseVisualStyleBackColor = true;
        // 
        // btnNovo
        // 
        btnNovo.BackColor = Color.FromArgb(245, 232, 229);
        btnNovo.FlatStyle = FlatStyle.Flat;
        btnNovo.Font = new Font("Segoe UI", 9F);
        btnNovo.ForeColor = Color.FromArgb(59, 48, 50);
        btnNovo.Location = new Point(12, 210);
        btnNovo.Name = "btnNovo";
        btnNovo.Size = new Size(130, 32);
        btnNovo.TabIndex = 19;
        btnNovo.Text = "Novo";
        btnNovo.UseVisualStyleBackColor = false;
        btnNovo.Click += BtnNovo_Click;
        // 
        // btnSalvar
        // 
        btnSalvar.BackColor = Color.FromArgb(142, 59, 82);
        btnSalvar.FlatStyle = FlatStyle.Flat;
        btnSalvar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnSalvar.ForeColor = Color.FromArgb(255, 255, 255);
        btnSalvar.Location = new Point(152, 210);
        btnSalvar.Name = "btnSalvar";
        btnSalvar.Size = new Size(130, 32);
        btnSalvar.TabIndex = 20;
        btnSalvar.Text = "Salvar";
        btnSalvar.UseVisualStyleBackColor = false;
        btnSalvar.Click += BtnSalvar_Click;
        // 
        // ServicoUC
        // 
        BackColor = Color.FromArgb(255, 248, 245);
        Controls.Add(lblTitulo);
        Controls.Add(grpLista);
        Controls.Add(grpDados);
        ForeColor = Color.FromArgb(59, 48, 50);
        Name = "ServicoUC";
        Size = new Size(654, 540);
        grpLista.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvServicos).EndInit();
        grpDados.ResumeLayout(false);
        grpDados.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }
}
