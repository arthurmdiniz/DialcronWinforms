namespace DialcronWinforms.Controls;

partial class ClienteUC
{
    private System.ComponentModel.IContainer components = null;

    private Label lblTitulo;
    private GroupBox grpLista;
    private DataGridView dgvClientes;
    private DataGridViewTextBoxColumn colId;
    private DataGridViewTextBoxColumn colNome;
    private DataGridViewTextBoxColumn colDdd;
    private DataGridViewTextBoxColumn colTelefone;
    private GroupBox grpDados;
    private Label lblNome;
    private TextBox txtNome;
    private Label lblDdd;
    private TextBox txtDdd;
    private Label lblTelefone;
    private TextBox txtTelefone;
    private Label lblEmail;
    private TextBox txtEmail;
    private Label lblDtaNascimento;
    private TextBox txtDtaNascimento;
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
        dgvClientes = new DataGridView();
        colId = new DataGridViewTextBoxColumn();
        colNome = new DataGridViewTextBoxColumn();
        colDdd = new DataGridViewTextBoxColumn();
        colTelefone = new DataGridViewTextBoxColumn();
        grpDados = new GroupBox();
        lblNome = new Label();
        txtNome = new TextBox();
        lblDdd = new Label();
        txtDdd = new TextBox();
        lblTelefone = new Label();
        txtTelefone = new TextBox();
        lblEmail = new Label();
        txtEmail = new TextBox();
        lblDtaNascimento = new Label();
        txtDtaNascimento = new TextBox();
        btnNovo = new Button();
        btnSalvar = new Button();
        grpLista.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvClientes).BeginInit();
        grpDados.SuspendLayout();
        SuspendLayout();
        // 
        // lblTitulo
        // 
        lblTitulo.AutoSize = true;
        lblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
        lblTitulo.ForeColor = Cores.PrimaryDarkText;
        lblTitulo.Location = new Point(15, 10);
        lblTitulo.Name = "lblTitulo";
        lblTitulo.Size = new Size(227, 30);
        lblTitulo.TabIndex = 0;
        lblTitulo.Text = "Cadastro de Clientes";
        // 
        // grpLista
        // 
        grpLista.BackColor = Cores.White;
        grpLista.Controls.Add(dgvClientes);
        grpLista.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        grpLista.ForeColor = Cores.Gray600;
        grpLista.Location = new Point(15, 50);
        grpLista.Name = "grpLista";
        grpLista.Size = new Size(624, 206);
        grpLista.TabIndex = 1;
        grpLista.TabStop = false;
        grpLista.Text = "Lista";
        // 
        // dgvClientes
        // 
        dgvClientes.AllowUserToAddRows = false;
        dgvClientes.AllowUserToDeleteRows = false;
        dgvClientes.AutoGenerateColumns = false;
        dgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvClientes.BackgroundColor = Cores.White;
        dgvClientes.BorderStyle = BorderStyle.None;
        dgvClientes.Columns.AddRange(new DataGridViewColumn[] { colId, colNome, colDdd, colTelefone });
        dgvClientes.Font = new Font("Segoe UI", 9F);
        dgvClientes.Location = new Point(12, 25);
        dgvClientes.MultiSelect = false;
        dgvClientes.Name = "dgvClientes";
        dgvClientes.ReadOnly = true;
        dgvClientes.RowHeadersVisible = false;
        dgvClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvClientes.Size = new Size(600, 175);
        dgvClientes.TabIndex = 0;
        // 
        // colId
        // 
        colId.DataPropertyName = "ClienteId";
        colId.FillWeight = 15F;
        colId.HeaderText = "ID";
        colId.Name = "colId";
        colId.ReadOnly = true;
        // 
        // colNome
        // 
        colNome.DataPropertyName = "Nome";
        colNome.FillWeight = 55F;
        colNome.HeaderText = "Nome";
        colNome.Name = "colNome";
        colNome.ReadOnly = true;
        // 
        // colDdd
        // 
        colDdd.DataPropertyName = "DddTelefone";
        colDdd.FillWeight = 10F;
        colDdd.HeaderText = "DDD";
        colDdd.Name = "colDdd";
        colDdd.ReadOnly = true;
        // 
        // colTelefone
        // 
        colTelefone.DataPropertyName = "Telefone";
        colTelefone.FillWeight = 20F;
        colTelefone.HeaderText = "Telefone";
        colTelefone.Name = "colTelefone";
        colTelefone.ReadOnly = true;
        // 
        // grpDados
        // 
        grpDados.BackColor = Cores.White;
        grpDados.Controls.Add(lblNome);
        grpDados.Controls.Add(txtNome);
        grpDados.Controls.Add(lblDdd);
        grpDados.Controls.Add(txtDdd);
        grpDados.Controls.Add(lblTelefone);
        grpDados.Controls.Add(txtTelefone);
        grpDados.Controls.Add(lblEmail);
        grpDados.Controls.Add(txtEmail);
        grpDados.Controls.Add(lblDtaNascimento);
        grpDados.Controls.Add(txtDtaNascimento);
        grpDados.Controls.Add(btnNovo);
        grpDados.Controls.Add(btnSalvar);
        grpDados.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        grpDados.ForeColor = Cores.Gray600;
        grpDados.Location = new Point(15, 262);
        grpDados.Name = "grpDados";
        grpDados.Size = new Size(624, 250);
        grpDados.TabIndex = 2;
        grpDados.TabStop = false;
        grpDados.Text = "Dados";
        // 
        // lblNome
        // 
        lblNome.AutoSize = true;
        lblNome.Font = new Font("Segoe UI", 9F);
        lblNome.ForeColor = Cores.PrimaryDarkText;
        lblNome.Location = new Point(12, 28);
        lblNome.Name = "lblNome";
        lblNome.Size = new Size(40, 15);
        lblNome.TabIndex = 0;
        lblNome.Text = "Nome";
        // 
        // txtNome
        // 
        txtNome.Font = new Font("Segoe UI", 9F);
        txtNome.Location = new Point(12, 46);
        txtNome.Name = "txtNome";
        txtNome.Size = new Size(600, 23);
        txtNome.TabIndex = 1;
        // 
        // lblDdd
        // 
        lblDdd.AutoSize = true;
        lblDdd.Font = new Font("Segoe UI", 9F);
        lblDdd.ForeColor = Cores.PrimaryDarkText;
        lblDdd.Location = new Point(12, 90);
        lblDdd.Name = "lblDdd";
        lblDdd.Size = new Size(28, 15);
        lblDdd.TabIndex = 2;
        lblDdd.Text = "DDD";
        // 
        // txtDdd
        // 
        txtDdd.Font = new Font("Segoe UI", 9F);
        txtDdd.Location = new Point(12, 108);
        txtDdd.MaxLength = 2;
        txtDdd.Name = "txtDdd";
        txtDdd.Size = new Size(60, 23);
        txtDdd.TabIndex = 3;
        // 
        // lblTelefone
        // 
        lblTelefone.AutoSize = true;
        lblTelefone.Font = new Font("Segoe UI", 9F);
        lblTelefone.ForeColor = Cores.PrimaryDarkText;
        lblTelefone.Location = new Point(90, 90);
        lblTelefone.Name = "lblTelefone";
        lblTelefone.Size = new Size(52, 15);
        lblTelefone.TabIndex = 4;
        lblTelefone.Text = "Telefone";
        // 
        // txtTelefone
        // 
        txtTelefone.Font = new Font("Segoe UI", 9F);
        txtTelefone.Location = new Point(90, 108);
        txtTelefone.Name = "txtTelefone";
        txtTelefone.Size = new Size(150, 23);
        txtTelefone.TabIndex = 5;
        // 
        // lblEmail
        // 
        lblEmail.AutoSize = true;
        lblEmail.Font = new Font("Segoe UI", 9F);
        lblEmail.ForeColor = Cores.PrimaryDarkText;
        lblEmail.Location = new Point(260, 90);
        lblEmail.Name = "lblEmail";
        lblEmail.Size = new Size(36, 15);
        lblEmail.TabIndex = 6;
        lblEmail.Text = "E-mail";
        // 
        // txtEmail
        // 
        txtEmail.Font = new Font("Segoe UI", 9F);
        txtEmail.Location = new Point(260, 108);
        txtEmail.Name = "txtEmail";
        txtEmail.Size = new Size(352, 23);
        txtEmail.TabIndex = 7;
        // 
        // lblDtaNascimento
        // 
        lblDtaNascimento.AutoSize = true;
        lblDtaNascimento.Font = new Font("Segoe UI", 9F);
        lblDtaNascimento.ForeColor = Cores.PrimaryDarkText;
        lblDtaNascimento.Location = new Point(12, 150);
        lblDtaNascimento.Name = "lblDtaNascimento";
        lblDtaNascimento.Size = new Size(118, 15);
        lblDtaNascimento.TabIndex = 8;
        lblDtaNascimento.Text = "Data de nascimento";
        // 
        // txtDtaNascimento
        // 
        txtDtaNascimento.Font = new Font("Segoe UI", 9F);
        txtDtaNascimento.Location = new Point(12, 168);
        txtDtaNascimento.MaxLength = 10;
        txtDtaNascimento.Name = "txtDtaNascimento";
        txtDtaNascimento.PlaceholderText = "dd/mm/aaaa";
        txtDtaNascimento.Size = new Size(150, 23);
        txtDtaNascimento.TabIndex = 9;
        // 
        // btnNovo
        // 
        btnNovo.BackColor = Cores.Secondary;
        btnNovo.FlatStyle = FlatStyle.Flat;
        btnNovo.Font = new Font("Segoe UI", 9F);
        btnNovo.ForeColor = Cores.PrimaryDarkText;
        btnNovo.Location = new Point(12, 205);
        btnNovo.Name = "btnNovo";
        btnNovo.Size = new Size(130, 32);
        btnNovo.TabIndex = 10;
        btnNovo.Text = "Novo";
        btnNovo.UseVisualStyleBackColor = false;
        btnNovo.Click += BtnNovo_Click;
        // 
        // btnSalvar
        // 
        btnSalvar.BackColor = Cores.Primary;
        btnSalvar.FlatStyle = FlatStyle.Flat;
        btnSalvar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnSalvar.ForeColor = Cores.White;
        btnSalvar.Location = new Point(152, 205);
        btnSalvar.Name = "btnSalvar";
        btnSalvar.Size = new Size(130, 32);
        btnSalvar.TabIndex = 11;
        btnSalvar.Text = "Salvar";
        btnSalvar.UseVisualStyleBackColor = false;
        btnSalvar.Click += BtnSalvar_Click;
        // 
        // ClienteUC
        // 
        BackColor = Cores.Creme;
        Controls.Add(lblTitulo);
        Controls.Add(grpLista);
        Controls.Add(grpDados);
        ForeColor = Cores.Gray900;
        Name = "ClienteUC";
        Size = new Size(654, 540);
        grpLista.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvClientes).EndInit();
        grpDados.ResumeLayout(false);
        grpDados.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }
}
