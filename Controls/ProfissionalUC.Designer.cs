namespace DialcronWinforms.Controls;

partial class ProfissionalUC
{
    private System.ComponentModel.IContainer components = null;

    private Label lblTitulo;
    private GroupBox grpLista;
    private DataGridView dgvProfissionais;
    private DataGridViewTextBoxColumn colId;
    private DataGridViewTextBoxColumn colNome;
    private GroupBox grpDados;
    private Label lblUnidade;
    private ComboBox cbxUnidade;
    private Label lblNome;
    private TextBox txtNome;
    private Label lblEspecialidade;
    private TextBox txtEspecialidade;
    private Label lblDddTelefone;
    private TextBox txtDddTelefone;
    private Label lblTelefone;
    private TextBox txtTelefone;
    private Label lblDddCelular;
    private TextBox txtDddCelular;
    private Label lblCelular;
    private TextBox txtCelular;
    private Label lblDddOutros;
    private TextBox txtDddOutros;
    private Label lblTelefoneOutros;
    private TextBox txtTelefoneOutros;
    private CheckBox chkAtivo;
    private Button btnNovo;
    private Button btnSalvar;
    private Button btnExcluir;

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
        dgvProfissionais = new DataGridView();
        colId = new DataGridViewTextBoxColumn();
        colNome = new DataGridViewTextBoxColumn();
        grpDados = new GroupBox();
        lblUnidade = new Label();
        cbxUnidade = new ComboBox();
        lblNome = new Label();
        txtNome = new TextBox();
        lblEspecialidade = new Label();
        txtEspecialidade = new TextBox();
        lblDddTelefone = new Label();
        txtDddTelefone = new TextBox();
        lblTelefone = new Label();
        txtTelefone = new TextBox();
        lblDddCelular = new Label();
        txtDddCelular = new TextBox();
        lblCelular = new Label();
        txtCelular = new TextBox();
        lblDddOutros = new Label();
        txtDddOutros = new TextBox();
        lblTelefoneOutros = new Label();
        txtTelefoneOutros = new TextBox();
        chkAtivo = new CheckBox();
        btnNovo = new Button();
        btnSalvar = new Button();
        btnExcluir = new Button();
        grpLista.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvProfissionais).BeginInit();
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
        lblTitulo.Size = new Size(291, 30);
        lblTitulo.TabIndex = 0;
        lblTitulo.Text = "Cadastro de Profissionais";
        // 
        // grpLista
        // 
        grpLista.BackColor = Cores.White;
        grpLista.Controls.Add(dgvProfissionais);
        grpLista.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        grpLista.ForeColor = Cores.Gray600;
        grpLista.Location = new Point(15, 50);
        grpLista.Name = "grpLista";
        grpLista.Size = new Size(624, 206);
        grpLista.TabIndex = 1;
        grpLista.TabStop = false;
        grpLista.Text = "Lista";
        // 
        // dgvProfissionais
        // 
        dgvProfissionais.AllowUserToAddRows = false;
        dgvProfissionais.AllowUserToDeleteRows = false;
        dgvProfissionais.AutoGenerateColumns = false;
        dgvProfissionais.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvProfissionais.BackgroundColor = Cores.White;
        dgvProfissionais.BorderStyle = BorderStyle.None;
        dgvProfissionais.Columns.AddRange(new DataGridViewColumn[] { colId, colNome });
        dgvProfissionais.Font = new Font("Segoe UI", 9F);
        dgvProfissionais.Location = new Point(12, 25);
        dgvProfissionais.MultiSelect = false;
        dgvProfissionais.Name = "dgvProfissionais";
        dgvProfissionais.ReadOnly = true;
        dgvProfissionais.RowHeadersVisible = false;
        dgvProfissionais.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvProfissionais.Size = new Size(600, 175);
        dgvProfissionais.TabIndex = 0;
        // 
        // colId
        // 
        colId.DataPropertyName = "Id";
        colId.FillWeight = 20F;
        colId.HeaderText = "ID";
        colId.Name = "colId";
        colId.ReadOnly = true;
        // 
        // colNome
        // 
        colNome.DataPropertyName = "Nome";
        colNome.FillWeight = 80F;
        colNome.HeaderText = "Nome";
        colNome.Name = "colNome";
        colNome.ReadOnly = true;
        // 
        // grpDados
        // 
        grpDados.BackColor = Cores.White;
        grpDados.Controls.Add(lblUnidade);
        grpDados.Controls.Add(cbxUnidade);
        grpDados.Controls.Add(lblNome);
        grpDados.Controls.Add(txtNome);
        grpDados.Controls.Add(lblEspecialidade);
        grpDados.Controls.Add(txtEspecialidade);
        grpDados.Controls.Add(lblDddTelefone);
        grpDados.Controls.Add(txtDddTelefone);
        grpDados.Controls.Add(lblTelefone);
        grpDados.Controls.Add(txtTelefone);
        grpDados.Controls.Add(lblDddCelular);
        grpDados.Controls.Add(txtDddCelular);
        grpDados.Controls.Add(lblCelular);
        grpDados.Controls.Add(txtCelular);
        grpDados.Controls.Add(lblDddOutros);
        grpDados.Controls.Add(txtDddOutros);
        grpDados.Controls.Add(lblTelefoneOutros);
        grpDados.Controls.Add(txtTelefoneOutros);
        grpDados.Controls.Add(chkAtivo);
        grpDados.Controls.Add(btnNovo);
        grpDados.Controls.Add(btnSalvar);
        grpDados.Controls.Add(btnExcluir);
        grpDados.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        grpDados.ForeColor = Cores.Gray600;
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
        lblUnidade.ForeColor = Cores.Gray900;
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
        lblNome.ForeColor = Cores.Gray900;
        lblNome.Location = new Point(156, 28);
        lblNome.Name = "lblNome";
        lblNome.Size = new Size(39, 15);
        lblNome.TabIndex = 2;
        lblNome.Text = "Nome";
        // 
        // txtNome
        // 
        txtNome.Font = new Font("Segoe UI", 9F);
        txtNome.Location = new Point(156, 46);
        txtNome.Name = "txtNome";
        txtNome.Size = new Size(240, 23);
        txtNome.TabIndex = 3;
        // 
        // lblEspecialidade
        // 
        lblEspecialidade.AutoSize = true;
        lblEspecialidade.Font = new Font("Segoe UI", 9F);
        lblEspecialidade.ForeColor = Cores.Gray900;
        lblEspecialidade.Location = new Point(406, 28);
        lblEspecialidade.Name = "lblEspecialidade";
        lblEspecialidade.Size = new Size(78, 15);
        lblEspecialidade.TabIndex = 4;
        lblEspecialidade.Text = "Especialidade";
        // 
        // txtEspecialidade
        // 
        txtEspecialidade.Font = new Font("Segoe UI", 9F);
        txtEspecialidade.Location = new Point(406, 46);
        txtEspecialidade.Name = "txtEspecialidade";
        txtEspecialidade.Size = new Size(200, 23);
        txtEspecialidade.TabIndex = 5;
        // 
        // lblDddTelefone
        // 
        lblDddTelefone.AutoSize = true;
        lblDddTelefone.Font = new Font("Segoe UI", 9F);
        lblDddTelefone.ForeColor = Cores.Gray900;
        lblDddTelefone.Location = new Point(12, 88);
        lblDddTelefone.Name = "lblDddTelefone";
        lblDddTelefone.Size = new Size(30, 15);
        lblDddTelefone.TabIndex = 6;
        lblDddTelefone.Text = "DDD";
        // 
        // txtDddTelefone
        // 
        txtDddTelefone.Font = new Font("Segoe UI", 9F);
        txtDddTelefone.Location = new Point(12, 106);
        txtDddTelefone.Name = "txtDddTelefone";
        txtDddTelefone.Size = new Size(60, 23);
        txtDddTelefone.TabIndex = 7;
        // 
        // lblTelefone
        // 
        lblTelefone.AutoSize = true;
        lblTelefone.Font = new Font("Segoe UI", 9F);
        lblTelefone.ForeColor = Cores.Gray900;
        lblTelefone.Location = new Point(90, 88);
        lblTelefone.Name = "lblTelefone";
        lblTelefone.Size = new Size(50, 15);
        lblTelefone.TabIndex = 8;
        lblTelefone.Text = "Telefone";
        // 
        // txtTelefone
        // 
        txtTelefone.Font = new Font("Segoe UI", 9F);
        txtTelefone.Location = new Point(90, 106);
        txtTelefone.Name = "txtTelefone";
        txtTelefone.Size = new Size(150, 23);
        txtTelefone.TabIndex = 9;
        txtTelefone.TextChanged += TxtTelefone_TextChanged;
        // 
        // lblDddCelular
        // 
        lblDddCelular.AutoSize = true;
        lblDddCelular.Font = new Font("Segoe UI", 9F);
        lblDddCelular.ForeColor = Cores.Gray900;
        lblDddCelular.Location = new Point(258, 88);
        lblDddCelular.Name = "lblDddCelular";
        lblDddCelular.Size = new Size(30, 15);
        lblDddCelular.TabIndex = 10;
        lblDddCelular.Text = "DDD";
        // 
        // txtDddCelular
        // 
        txtDddCelular.Font = new Font("Segoe UI", 9F);
        txtDddCelular.Location = new Point(258, 106);
        txtDddCelular.Name = "txtDddCelular";
        txtDddCelular.Size = new Size(60, 23);
        txtDddCelular.TabIndex = 11;
        // 
        // lblCelular
        // 
        lblCelular.AutoSize = true;
        lblCelular.Font = new Font("Segoe UI", 9F);
        lblCelular.ForeColor = Cores.Gray900;
        lblCelular.Location = new Point(336, 88);
        lblCelular.Name = "lblCelular";
        lblCelular.Size = new Size(44, 15);
        lblCelular.TabIndex = 12;
        lblCelular.Text = "Celular";
        // 
        // txtCelular
        // 
        txtCelular.Font = new Font("Segoe UI", 9F);
        txtCelular.Location = new Point(336, 106);
        txtCelular.Name = "txtCelular";
        txtCelular.Size = new Size(150, 23);
        txtCelular.TabIndex = 13;
        txtCelular.TextChanged += TxtCelular_TextChanged;
        // 
        // lblDddOutros
        // 
        lblDddOutros.AutoSize = true;
        lblDddOutros.Font = new Font("Segoe UI", 9F);
        lblDddOutros.ForeColor = Cores.Gray900;
        lblDddOutros.Location = new Point(12, 148);
        lblDddOutros.Name = "lblDddOutros";
        lblDddOutros.Size = new Size(30, 15);
        lblDddOutros.TabIndex = 14;
        lblDddOutros.Text = "DDD";
        // 
        // txtDddOutros
        // 
        txtDddOutros.Font = new Font("Segoe UI", 9F);
        txtDddOutros.Location = new Point(12, 166);
        txtDddOutros.Name = "txtDddOutros";
        txtDddOutros.Size = new Size(60, 23);
        txtDddOutros.TabIndex = 15;
        // 
        // lblTelefoneOutros
        // 
        lblTelefoneOutros.AutoSize = true;
        lblTelefoneOutros.Font = new Font("Segoe UI", 9F);
        lblTelefoneOutros.ForeColor = Cores.Gray900;
        lblTelefoneOutros.Location = new Point(90, 148);
        lblTelefoneOutros.Name = "lblTelefoneOutros";
        lblTelefoneOutros.Size = new Size(88, 15);
        lblTelefoneOutros.TabIndex = 16;
        lblTelefoneOutros.Text = "Outro telefone";
        // 
        // txtTelefoneOutros
        // 
        txtTelefoneOutros.Font = new Font("Segoe UI", 9F);
        txtTelefoneOutros.Location = new Point(90, 166);
        txtTelefoneOutros.Name = "txtTelefoneOutros";
        txtTelefoneOutros.Size = new Size(150, 23);
        txtTelefoneOutros.TabIndex = 17;
        txtTelefoneOutros.TextChanged += TxtTelefoneOutros_TextChanged;
        // 
        // chkAtivo
        // 
        chkAtivo.AutoSize = true;
        chkAtivo.Checked = true;
        chkAtivo.CheckState = CheckState.Checked;
        chkAtivo.Font = new Font("Segoe UI", 9F);
        chkAtivo.ForeColor = Cores.Gray900;
        chkAtivo.Location = new Point(336, 168);
        chkAtivo.Name = "chkAtivo";
        chkAtivo.Size = new Size(54, 19);
        chkAtivo.TabIndex = 18;
        chkAtivo.Text = "Ativo";
        chkAtivo.UseVisualStyleBackColor = true;
        // 
        // btnNovo
        // 
        btnNovo.BackColor = Cores.Secondary;
        btnNovo.FlatStyle = FlatStyle.Flat;
        btnNovo.Font = new Font("Segoe UI", 9F);
        btnNovo.ForeColor = Cores.Gray900;
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
        btnSalvar.BackColor = Cores.Primary;
        btnSalvar.FlatStyle = FlatStyle.Flat;
        btnSalvar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnSalvar.ForeColor = Cores.White;
        btnSalvar.Location = new Point(152, 210);
        btnSalvar.Name = "btnSalvar";
        btnSalvar.Size = new Size(130, 32);
        btnSalvar.TabIndex = 20;
        btnSalvar.Text = "Salvar";
        btnSalvar.UseVisualStyleBackColor = false;
        btnSalvar.Click += BtnSalvar_Click;
        // 
        // btnExcluir
        // 
        btnExcluir.BackColor = Cores.Secondary;
        btnExcluir.FlatStyle = FlatStyle.Flat;
        btnExcluir.Font = new Font("Segoe UI", 9F);
        btnExcluir.ForeColor = Cores.Gray900;
        btnExcluir.Location = new Point(292, 210);
        btnExcluir.Name = "btnExcluir";
        btnExcluir.Size = new Size(130, 32);
        btnExcluir.TabIndex = 21;
        btnExcluir.Text = "Excluir";
        btnExcluir.UseVisualStyleBackColor = false;
        btnExcluir.Click += BtnExcluir_Click;
        // 
        // ProfissionalUC
        // 
        BackColor = Cores.Creme;
        Controls.Add(lblTitulo);
        Controls.Add(grpLista);
        Controls.Add(grpDados);
        ForeColor = Cores.Gray900;
        Name = "ProfissionalUC";
        Size = new Size(654, 540);
        grpLista.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvProfissionais).EndInit();
        grpDados.ResumeLayout(false);
        grpDados.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }
}
