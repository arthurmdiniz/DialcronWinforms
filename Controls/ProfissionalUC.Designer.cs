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
    private Label lblNome;
    private TextBox txtNome;
    private Label lblEspecialidade;
    private TextBox txtEspecialidade;
    private Label lblTelefone;
    private TextBox txtTelefone;
    private Label lblCelular;
    private TextBox txtCelular;
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
        dgvProfissionais = new DataGridView();
        colId = new DataGridViewTextBoxColumn();
        colNome = new DataGridViewTextBoxColumn();
        grpDados = new GroupBox();
        lblNome = new Label();
        txtNome = new TextBox();
        lblEspecialidade = new Label();
        txtEspecialidade = new TextBox();
        lblTelefone = new Label();
        txtTelefone = new TextBox();
        lblCelular = new Label();
        txtCelular = new TextBox();
        btnNovo = new Button();
        btnSalvar = new Button();
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
        grpDados.Controls.Add(lblNome);
        grpDados.Controls.Add(txtNome);
        grpDados.Controls.Add(lblEspecialidade);
        grpDados.Controls.Add(txtEspecialidade);
        grpDados.Controls.Add(lblTelefone);
        grpDados.Controls.Add(txtTelefone);
        grpDados.Controls.Add(lblCelular);
        grpDados.Controls.Add(txtCelular);
        grpDados.Controls.Add(btnNovo);
        grpDados.Controls.Add(btnSalvar);
        grpDados.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        grpDados.ForeColor = Cores.Gray600;
        grpDados.Location = new Point(15, 262);
        grpDados.Name = "grpDados";
        grpDados.Size = new Size(624, 200);
        grpDados.TabIndex = 2;
        grpDados.TabStop = false;
        grpDados.Text = "Dados";
        // 
        // lblNome
        // 
        lblNome.AutoSize = true;
        lblNome.Font = new Font("Segoe UI", 9F);
        lblNome.ForeColor = Cores.Gray900;
        lblNome.Location = new Point(12, 28);
        lblNome.Name = "lblNome";
        lblNome.Size = new Size(39, 15);
        lblNome.TabIndex = 0;
        lblNome.Text = "Nome";
        // 
        // txtNome
        // 
        txtNome.Font = new Font("Segoe UI", 9F);
        txtNome.Location = new Point(12, 46);
        txtNome.Name = "txtNome";
        txtNome.Size = new Size(280, 23);
        txtNome.TabIndex = 1;
        // 
        // lblEspecialidade
        // 
        lblEspecialidade.AutoSize = true;
        lblEspecialidade.Font = new Font("Segoe UI", 9F);
        lblEspecialidade.ForeColor = Cores.Gray900;
        lblEspecialidade.Location = new Point(312, 28);
        lblEspecialidade.Name = "lblEspecialidade";
        lblEspecialidade.Size = new Size(78, 15);
        lblEspecialidade.TabIndex = 2;
        lblEspecialidade.Text = "Especialidade";
        // 
        // txtEspecialidade
        // 
        txtEspecialidade.Font = new Font("Segoe UI", 9F);
        txtEspecialidade.Location = new Point(312, 46);
        txtEspecialidade.Name = "txtEspecialidade";
        txtEspecialidade.Size = new Size(280, 23);
        txtEspecialidade.TabIndex = 3;
        // 
        // lblTelefone
        // 
        lblTelefone.AutoSize = true;
        lblTelefone.Font = new Font("Segoe UI", 9F);
        lblTelefone.ForeColor = Cores.Gray900;
        lblTelefone.Location = new Point(12, 88);
        lblTelefone.Name = "lblTelefone";
        lblTelefone.Size = new Size(50, 15);
        lblTelefone.TabIndex = 4;
        lblTelefone.Text = "Telefone";
        // 
        // txtTelefone
        // 
        txtTelefone.Font = new Font("Segoe UI", 9F);
        txtTelefone.Location = new Point(12, 106);
        txtTelefone.Name = "txtTelefone";
        txtTelefone.Size = new Size(200, 23);
        txtTelefone.TabIndex = 5;
        txtTelefone.TextChanged += TxtTelefone_TextChanged;
        // 
        // lblCelular
        // 
        lblCelular.AutoSize = true;
        lblCelular.Font = new Font("Segoe UI", 9F);
        lblCelular.ForeColor = Cores.Gray900;
        lblCelular.Location = new Point(312, 88);
        lblCelular.Name = "lblCelular";
        lblCelular.Size = new Size(44, 15);
        lblCelular.TabIndex = 6;
        lblCelular.Text = "Celular";
        // 
        // txtCelular
        // 
        txtCelular.Font = new Font("Segoe UI", 9F);
        txtCelular.Location = new Point(312, 106);
        txtCelular.Name = "txtCelular";
        txtCelular.Size = new Size(200, 23);
        txtCelular.TabIndex = 7;
        txtCelular.TextChanged += TxtCelular_TextChanged;
        // 
        // btnNovo
        // 
        btnNovo.BackColor = Cores.Secondary;
        btnNovo.FlatStyle = FlatStyle.Flat;
        btnNovo.Font = new Font("Segoe UI", 9F);
        btnNovo.ForeColor = Cores.Gray900;
        btnNovo.Location = new Point(12, 150);
        btnNovo.Name = "btnNovo";
        btnNovo.Size = new Size(130, 32);
        btnNovo.TabIndex = 8;
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
        btnSalvar.Location = new Point(152, 150);
        btnSalvar.Name = "btnSalvar";
        btnSalvar.Size = new Size(130, 32);
        btnSalvar.TabIndex = 9;
        btnSalvar.Text = "Salvar";
        btnSalvar.UseVisualStyleBackColor = false;
        btnSalvar.Click += BtnSalvar_Click;
        // 
        // ProfissionalUC
        // 
        BackColor = Cores.Creme;
        Controls.Add(lblTitulo);
        Controls.Add(grpLista);
        Controls.Add(grpDados);
        ForeColor = Cores.Gray900;
        Name = "ProfissionalUC";
        Size = new Size(654, 480);
        grpLista.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvProfissionais).EndInit();
        grpDados.ResumeLayout(false);
        grpDados.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }
}
