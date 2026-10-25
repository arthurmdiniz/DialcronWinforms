namespace DialcronWinforms.Controls;

partial class UnidadeUC
{
    private System.ComponentModel.IContainer components = null;

    private Label lblTitulo;
    private GroupBox grpLista;
    private DataGridView dgvUnidades;
    private DataGridViewTextBoxColumn colNomeFantasia;
    private DataGridViewTextBoxColumn colRazaoSocial;
    private GroupBox grpDados;
    private Label lblNomeFantasia;
    private TextBox txtNomeFantasia;
    private Label lblRazaoSocial;
    private TextBox txtRazaoSocial;
    private Label lblCnpj;
    private TextBox txtCnpj;
    private Label lblInscEstadual;
    private TextBox txtInscEstadual;
    private Label lblInscMunicipal;
    private TextBox txtInscMunicipal;
    private Label lblCep;
    private TextBox txtCep;
    private Label lblLogradouro;
    private TextBox txtLogradouro;
    private Label lblNumero;
    private TextBox txtNumero;
    private Label lblBairro;
    private TextBox txtBairro;
    private Label lblComplemento;
    private TextBox txtComplemento;
    private Label lblMunicipio;
    private TextBox txtMunicipio;
    private Label lblUf;
    private Label lblEmail;
    private TextBox txtEmail;
    private Label lblDdd;
    private TextBox txtDdd;
    private Label lblTelefone;
    private TextBox txtTelefone;
    private Label lblCliente;
    private TextBox txtCliente;
    private Button btnIncluir;
    private Button btnSalvar;
    private Button btnCancelar;

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
        dgvUnidades = new DataGridView();
        colID = new DataGridViewTextBoxColumn();
        colRazaoSocial = new DataGridViewTextBoxColumn();
        colNomeFantasia = new DataGridViewTextBoxColumn();
        colCNPJ = new DataGridViewTextBoxColumn();
        grpDados = new GroupBox();
        cbxUF = new ComboBox();
        lblNomeFantasia = new Label();
        txtNomeFantasia = new TextBox();
        lblRazaoSocial = new Label();
        txtRazaoSocial = new TextBox();
        lblCnpj = new Label();
        txtCnpj = new TextBox();
        lblInscEstadual = new Label();
        txtInscEstadual = new TextBox();
        lblInscMunicipal = new Label();
        txtInscMunicipal = new TextBox();
        lblCep = new Label();
        txtCep = new TextBox();
        lblLogradouro = new Label();
        txtLogradouro = new TextBox();
        lblNumero = new Label();
        txtNumero = new TextBox();
        lblBairro = new Label();
        txtBairro = new TextBox();
        lblComplemento = new Label();
        txtComplemento = new TextBox();
        lblMunicipio = new Label();
        txtMunicipio = new TextBox();
        lblUf = new Label();
        lblEmail = new Label();
        txtEmail = new TextBox();
        lblDdd = new Label();
        txtDdd = new TextBox();
        lblTelefone = new Label();
        txtTelefone = new TextBox();
        lblCliente = new Label();
        txtCliente = new TextBox();
        btnIncluir = new Button();
        btnSalvar = new Button();
        btnCancelar = new Button();
        grpLista.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvUnidades).BeginInit();
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
        lblTitulo.Size = new Size(241, 30);
        lblTitulo.TabIndex = 0;
        lblTitulo.Text = "Cadastro de Unidades";
        // 
        // grpLista
        // 
        grpLista.BackColor = Color.FromArgb(255, 255, 255);
        grpLista.Controls.Add(dgvUnidades);
        grpLista.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        grpLista.ForeColor = Color.FromArgb(92, 75, 78);
        grpLista.Location = new Point(15, 50);
        grpLista.Name = "grpLista";
        grpLista.Size = new Size(624, 206);
        grpLista.TabIndex = 1;
        grpLista.TabStop = false;
        grpLista.Text = "Lista";
        // 
        // dgvUnidades
        // 
        dgvUnidades.AllowUserToAddRows = false;
        dgvUnidades.AllowUserToDeleteRows = false;
        dgvUnidades.AutoGenerateColumns = false;
        dgvUnidades.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvUnidades.BackgroundColor = Color.FromArgb(255, 255, 255);
        dgvUnidades.CellBorderStyle = DataGridViewCellBorderStyle.Raised;
        dgvUnidades.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
        dgvUnidades.Columns.AddRange(new DataGridViewColumn[] { colID, colRazaoSocial, colNomeFantasia, colCNPJ });
        dgvUnidades.Font = new Font("Segoe UI", 9F);
        dgvUnidades.Location = new Point(12, 25);
        dgvUnidades.MultiSelect = false;
        dgvUnidades.Name = "dgvUnidades";
        dgvUnidades.ReadOnly = true;
        dgvUnidades.RowHeadersVisible = false;
        dgvUnidades.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvUnidades.Size = new Size(600, 175);
        dgvUnidades.TabIndex = 0;
        dgvUnidades.StandardTab = true;
        // 
        // colID
        // 
        colID.DataPropertyName = "IdUnidade";
        colID.HeaderText = "ID";
        colID.Name = "colID";
        colID.ReadOnly = true;
        // 
        // colRazaoSocial
        // 
        colRazaoSocial.DataPropertyName = "RazaoSocial";
        colRazaoSocial.HeaderText = "Razão Social";
        colRazaoSocial.Name = "colRazaoSocial";
        colRazaoSocial.ReadOnly = true;
        // 
        // colNomeFantasia
        // 
        colNomeFantasia.DataPropertyName = "NomeFantasia";
        colNomeFantasia.HeaderText = "Nome Fantasia";
        colNomeFantasia.Name = "colNomeFantasia";
        colNomeFantasia.ReadOnly = true;
        // 
        // colCNPJ
        // 
        colCNPJ.DataPropertyName = "Cnpj";
        colCNPJ.HeaderText = "CNPJ";
        colCNPJ.Name = "colCNPJ";
        colCNPJ.ReadOnly = true;
        // 
        // grpDados
        // 
        grpDados.BackColor = Color.FromArgb(255, 255, 255);
        grpDados.Controls.Add(cbxUF);
        grpDados.Controls.Add(lblNomeFantasia);
        grpDados.Controls.Add(txtNomeFantasia);
        grpDados.Controls.Add(lblRazaoSocial);
        grpDados.Controls.Add(txtRazaoSocial);
        grpDados.Controls.Add(lblCnpj);
        grpDados.Controls.Add(txtCnpj);
        grpDados.Controls.Add(lblInscEstadual);
        grpDados.Controls.Add(txtInscEstadual);
        grpDados.Controls.Add(lblInscMunicipal);
        grpDados.Controls.Add(txtInscMunicipal);
        grpDados.Controls.Add(lblCep);
        grpDados.Controls.Add(txtCep);
        grpDados.Controls.Add(lblLogradouro);
        grpDados.Controls.Add(txtLogradouro);
        grpDados.Controls.Add(lblNumero);
        grpDados.Controls.Add(txtNumero);
        grpDados.Controls.Add(lblBairro);
        grpDados.Controls.Add(txtBairro);
        grpDados.Controls.Add(lblComplemento);
        grpDados.Controls.Add(txtComplemento);
        grpDados.Controls.Add(lblMunicipio);
        grpDados.Controls.Add(txtMunicipio);
        grpDados.Controls.Add(lblUf);
        grpDados.Controls.Add(lblEmail);
        grpDados.Controls.Add(txtEmail);
        grpDados.Controls.Add(lblDdd);
        grpDados.Controls.Add(txtDdd);
        grpDados.Controls.Add(lblTelefone);
        grpDados.Controls.Add(txtTelefone);
        grpDados.Controls.Add(lblCliente);
        grpDados.Controls.Add(txtCliente);
        grpDados.Controls.Add(btnIncluir);
        grpDados.Controls.Add(btnSalvar);
        grpDados.Controls.Add(btnCancelar);
        grpDados.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        grpDados.ForeColor = Color.FromArgb(92, 75, 78);
        grpDados.Location = new Point(15, 262);
        grpDados.Name = "grpDados";
        grpDados.Size = new Size(624, 308);
        grpDados.TabIndex = 2;
        grpDados.TabStop = false;
        grpDados.Text = "Dados da unidade";
        // 
        // cbxUF
        // 
        cbxUF.FormattingEnabled = true;
        cbxUF.Location = new Point(444, 226);
        cbxUF.Name = "cbxUF";
        cbxUF.Size = new Size(51, 25);
        cbxUF.TabIndex = 35;
        // 
        // lblNomeFantasia
        // 
        lblNomeFantasia.AutoSize = true;
        lblNomeFantasia.Font = new Font("Segoe UI", 9F);
        lblNomeFantasia.Location = new Point(12, 28);
        lblNomeFantasia.Name = "lblNomeFantasia";
        lblNomeFantasia.Size = new Size(86, 15);
        lblNomeFantasia.TabIndex = 0;
        lblNomeFantasia.Text = "Nome Fantasia";
        // 
        // txtNomeFantasia
        // 
        txtNomeFantasia.Font = new Font("Segoe UI", 9F);
        txtNomeFantasia.Location = new Point(12, 46);
        txtNomeFantasia.Name = "txtNomeFantasia";
        txtNomeFantasia.Size = new Size(200, 23);
        txtNomeFantasia.TabIndex = 1;
        // 
        // lblRazaoSocial
        // 
        lblRazaoSocial.AutoSize = true;
        lblRazaoSocial.Font = new Font("Segoe UI", 9F);
        lblRazaoSocial.Location = new Point(224, 28);
        lblRazaoSocial.Name = "lblRazaoSocial";
        lblRazaoSocial.Size = new Size(72, 15);
        lblRazaoSocial.TabIndex = 2;
        lblRazaoSocial.Text = "Razão Social";
        // 
        // txtRazaoSocial
        // 
        txtRazaoSocial.Font = new Font("Segoe UI", 9F);
        txtRazaoSocial.Location = new Point(224, 46);
        txtRazaoSocial.Name = "txtRazaoSocial";
        txtRazaoSocial.Size = new Size(200, 23);
        txtRazaoSocial.TabIndex = 3;
        // 
        // lblCnpj
        // 
        lblCnpj.AutoSize = true;
        lblCnpj.Font = new Font("Segoe UI", 9F);
        lblCnpj.Location = new Point(436, 28);
        lblCnpj.Name = "lblCnpj";
        lblCnpj.Size = new Size(34, 15);
        lblCnpj.TabIndex = 4;
        lblCnpj.Text = "CNPJ";
        // 
        // txtCnpj
        // 
        txtCnpj.Font = new Font("Segoe UI", 9F);
        txtCnpj.Location = new Point(436, 46);
        txtCnpj.Name = "txtCnpj";
        txtCnpj.Size = new Size(125, 23);
        txtCnpj.TabIndex = 5;
        txtCnpj.TextChanged += TxtCnpj_TextChanged;
        // 
        // lblInscEstadual
        // 
        lblInscEstadual.AutoSize = true;
        lblInscEstadual.Font = new Font("Segoe UI", 9F);
        lblInscEstadual.Location = new Point(12, 88);
        lblInscEstadual.Name = "lblInscEstadual";
        lblInscEstadual.Size = new Size(78, 15);
        lblInscEstadual.TabIndex = 6;
        lblInscEstadual.Text = "Insc. Estadual";
        // 
        // txtInscEstadual
        // 
        txtInscEstadual.Font = new Font("Segoe UI", 9F);
        txtInscEstadual.Location = new Point(12, 106);
        txtInscEstadual.Name = "txtInscEstadual";
        txtInscEstadual.Size = new Size(200, 23);
        txtInscEstadual.TabIndex = 7;
        // 
        // lblInscMunicipal
        // 
        lblInscMunicipal.AutoSize = true;
        lblInscMunicipal.Font = new Font("Segoe UI", 9F);
        lblInscMunicipal.Location = new Point(224, 88);
        lblInscMunicipal.Name = "lblInscMunicipal";
        lblInscMunicipal.Size = new Size(87, 15);
        lblInscMunicipal.TabIndex = 8;
        lblInscMunicipal.Text = "Insc. Municipal";
        // 
        // txtInscMunicipal
        // 
        txtInscMunicipal.Font = new Font("Segoe UI", 9F);
        txtInscMunicipal.Location = new Point(224, 106);
        txtInscMunicipal.Name = "txtInscMunicipal";
        txtInscMunicipal.Size = new Size(200, 23);
        txtInscMunicipal.TabIndex = 9;
        // 
        // lblCep
        // 
        lblCep.AutoSize = true;
        lblCep.Font = new Font("Segoe UI", 9F);
        lblCep.Location = new Point(12, 148);
        lblCep.Name = "lblCep";
        lblCep.Size = new Size(28, 15);
        lblCep.TabIndex = 10;
        lblCep.Text = "CEP";
        // 
        // txtCep
        // 
        txtCep.Font = new Font("Segoe UI", 9F);
        txtCep.Location = new Point(12, 166);
        txtCep.Name = "txtCep";
        txtCep.Size = new Size(78, 23);
        txtCep.TabIndex = 11;
        txtCep.TextChanged += TxtCep_TextChanged;
        // 
        // lblLogradouro
        // 
        lblLogradouro.AutoSize = true;
        lblLogradouro.Font = new Font("Segoe UI", 9F);
        lblLogradouro.Location = new Point(102, 148);
        lblLogradouro.Name = "lblLogradouro";
        lblLogradouro.Size = new Size(69, 15);
        lblLogradouro.TabIndex = 12;
        lblLogradouro.Text = "Logradouro";
        // 
        // txtLogradouro
        // 
        txtLogradouro.Font = new Font("Segoe UI", 9F);
        txtLogradouro.Location = new Point(102, 166);
        txtLogradouro.Name = "txtLogradouro";
        txtLogradouro.Size = new Size(282, 23);
        txtLogradouro.TabIndex = 13;
        // 
        // lblNumero
        // 
        lblNumero.AutoSize = true;
        lblNumero.Font = new Font("Segoe UI", 9F);
        lblNumero.Location = new Point(396, 148);
        lblNumero.Name = "lblNumero";
        lblNumero.Size = new Size(51, 15);
        lblNumero.TabIndex = 14;
        lblNumero.Text = "Número";
        // 
        // txtNumero
        // 
        txtNumero.Font = new Font("Segoe UI", 9F);
        txtNumero.Location = new Point(396, 166);
        txtNumero.Name = "txtNumero";
        txtNumero.Size = new Size(80, 23);
        txtNumero.TabIndex = 15;
        // 
        // lblBairro
        // 
        lblBairro.AutoSize = true;
        lblBairro.Font = new Font("Segoe UI", 9F);
        lblBairro.Location = new Point(12, 208);
        lblBairro.Name = "lblBairro";
        lblBairro.Size = new Size(38, 15);
        lblBairro.TabIndex = 16;
        lblBairro.Text = "Bairro";
        // 
        // txtBairro
        // 
        txtBairro.Font = new Font("Segoe UI", 9F);
        txtBairro.Location = new Point(12, 226);
        txtBairro.Name = "txtBairro";
        txtBairro.Size = new Size(180, 23);
        txtBairro.TabIndex = 17;
        // 
        // lblComplemento
        // 
        lblComplemento.AutoSize = true;
        lblComplemento.Font = new Font("Segoe UI", 9F);
        lblComplemento.Location = new Point(488, 148);
        lblComplemento.Name = "lblComplemento";
        lblComplemento.Size = new Size(84, 15);
        lblComplemento.TabIndex = 18;
        lblComplemento.Text = "Complemento";
        // 
        // txtComplemento
        // 
        txtComplemento.Font = new Font("Segoe UI", 9F);
        txtComplemento.Location = new Point(488, 166);
        txtComplemento.Name = "txtComplemento";
        txtComplemento.Size = new Size(124, 23);
        txtComplemento.TabIndex = 19;
        // 
        // lblMunicipio
        // 
        lblMunicipio.AutoSize = true;
        lblMunicipio.Font = new Font("Segoe UI", 9F);
        lblMunicipio.Location = new Point(204, 208);
        lblMunicipio.Name = "lblMunicipio";
        lblMunicipio.Size = new Size(61, 15);
        lblMunicipio.TabIndex = 20;
        lblMunicipio.Text = "Município";
        // 
        // txtMunicipio
        // 
        txtMunicipio.Font = new Font("Segoe UI", 9F);
        txtMunicipio.Location = new Point(204, 226);
        txtMunicipio.Name = "txtMunicipio";
        txtMunicipio.Size = new Size(234, 23);
        txtMunicipio.TabIndex = 21;
        // 
        // lblUf
        // 
        lblUf.AutoSize = true;
        lblUf.Font = new Font("Segoe UI", 9F);
        lblUf.Location = new Point(444, 208);
        lblUf.Name = "lblUf";
        lblUf.Size = new Size(21, 15);
        lblUf.TabIndex = 22;
        lblUf.Text = "UF";
        // 
        // lblEmail
        // 
        lblEmail.AutoSize = true;
        lblEmail.Font = new Font("Segoe UI", 9F);
        lblEmail.Location = new Point(436, 88);
        lblEmail.Name = "lblEmail";
        lblEmail.Size = new Size(41, 15);
        lblEmail.TabIndex = 24;
        lblEmail.Text = "E-mail";
        // 
        // txtEmail
        // 
        txtEmail.Font = new Font("Segoe UI", 9F);
        txtEmail.Location = new Point(436, 106);
        txtEmail.Name = "txtEmail";
        txtEmail.Size = new Size(177, 23);
        txtEmail.TabIndex = 25;
        // 
        // lblDdd
        // 
        lblDdd.AutoSize = true;
        lblDdd.Font = new Font("Segoe UI", 9F);
        lblDdd.Location = new Point(501, 208);
        lblDdd.Name = "lblDdd";
        lblDdd.Size = new Size(31, 15);
        lblDdd.TabIndex = 26;
        lblDdd.Text = "DDD";
        // 
        // txtDdd
        // 
        txtDdd.Font = new Font("Segoe UI", 9F);
        txtDdd.Location = new Point(501, 226);
        txtDdd.Name = "txtDdd";
        txtDdd.Size = new Size(31, 23);
        txtDdd.TabIndex = 27;
        // 
        // lblTelefone
        // 
        lblTelefone.AutoSize = true;
        lblTelefone.Font = new Font("Segoe UI", 9F);
        lblTelefone.Location = new Point(544, 208);
        lblTelefone.Name = "lblTelefone";
        lblTelefone.Size = new Size(51, 15);
        lblTelefone.TabIndex = 28;
        lblTelefone.Text = "Telefone";
        // 
        // txtTelefone
        // 
        txtTelefone.Font = new Font("Segoe UI", 9F);
        txtTelefone.Location = new Point(544, 226);
        txtTelefone.Name = "txtTelefone";
        txtTelefone.Size = new Size(69, 23);
        txtTelefone.TabIndex = 29;
        txtTelefone.TextChanged += TxtTelefone_TextChanged;
        // 
        // lblCliente
        // 
        lblCliente.AutoSize = true;
        lblCliente.Font = new Font("Segoe UI", 9F);
        lblCliente.Location = new Point(573, 28);
        lblCliente.Name = "lblCliente";
        lblCliente.Size = new Size(44, 15);
        lblCliente.TabIndex = 30;
        lblCliente.Text = "Cliente";
        // 
        // txtCliente
        // 
        txtCliente.Font = new Font("Segoe UI", 9F);
        txtCliente.Location = new Point(573, 46);
        txtCliente.Name = "txtCliente";
        txtCliente.Size = new Size(40, 23);
        txtCliente.TabIndex = 31;
        // 
        // btnIncluir
        // 
        btnIncluir.BackColor = Color.FromArgb(245, 232, 229);
        btnIncluir.FlatStyle = FlatStyle.Flat;
        btnIncluir.Font = new Font("Segoe UI", 9F);
        btnIncluir.ForeColor = Color.FromArgb(59, 48, 50);
        btnIncluir.Location = new Point(107, 258);
        btnIncluir.Name = "btnIncluir";
        btnIncluir.Size = new Size(130, 32);
        btnIncluir.TabIndex = 32;
        btnIncluir.Text = "Incluir";
        btnIncluir.UseVisualStyleBackColor = false;
        btnIncluir.Click += BtnIncluir_Click;
        // 
        // btnSalvar
        // 
        btnSalvar.BackColor = Color.FromArgb(142, 59, 82);
        btnSalvar.FlatStyle = FlatStyle.Flat;
        btnSalvar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnSalvar.ForeColor = Color.FromArgb(255, 255, 255);
        btnSalvar.Location = new Point(247, 258);
        btnSalvar.Name = "btnSalvar";
        btnSalvar.Size = new Size(130, 32);
        btnSalvar.TabIndex = 33;
        btnSalvar.Text = "Salvar";
        btnSalvar.UseVisualStyleBackColor = false;
        btnSalvar.Click += BtnSalvar_Click;
        // 
        // btnCancelar
        // 
        btnCancelar.BackColor = Color.FromArgb(245, 232, 229);
        btnCancelar.FlatStyle = FlatStyle.Flat;
        btnCancelar.Font = new Font("Segoe UI", 9F);
        btnCancelar.ForeColor = Color.FromArgb(59, 48, 50);
        btnCancelar.Location = new Point(387, 258);
        btnCancelar.Name = "btnCancelar";
        btnCancelar.Size = new Size(130, 32);
        btnCancelar.TabIndex = 34;
        btnCancelar.Text = "Cancelar";
        btnCancelar.UseVisualStyleBackColor = false;
        btnCancelar.Click += BtnCancelar_Click;
        // 
        // UnidadeUC
        // 
        BackColor = Color.FromArgb(255, 248, 245);
        Controls.Add(lblTitulo);
        Controls.Add(grpLista);
        Controls.Add(grpDados);
        ForeColor = Color.FromArgb(59, 48, 50);
        Name = "UnidadeUC";
        Size = new Size(654, 644);
        grpLista.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvUnidades).EndInit();
        grpDados.ResumeLayout(false);
        grpDados.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }

    private ComboBox cbxUF;
    private DataGridViewTextBoxColumn colID;
    private DataGridViewTextBoxColumn colCNPJ;
}
