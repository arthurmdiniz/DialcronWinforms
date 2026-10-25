namespace DialcronWinforms.Controls;

partial class AgendaUC
{
    private System.ComponentModel.IContainer components = null;

    private Label lblTitulo;
    private DateTimePicker dtpDataAgenda;
    private GroupBox grpAtendimentos;
    private DataGridView dgvAtendimentos;
    private DataGridViewTextBoxColumn colDataHora;
    private DataGridViewTextBoxColumn colCliente;
    private DataGridViewTextBoxColumn colProfissional;
    private DataGridViewTextBoxColumn colSituacao;
    private DataGridViewTextBoxColumn colValor;
    private GroupBox grpDados;
    private Label lblUnidade;
    private ComboBox cbxUnidade;
    private Label lblCliente;
    private ComboBox cbxCliente;
    private Button btnBuscarCliente;
    private Label lblProfissional;
    private ComboBox cbxProfissional;
    private Label lblDataHora;
    private DateTimePicker dtpAgendamento;
    private Label lblSituacao;
    private ComboBox cbxSituacao;
    private Label lblValor;
    private TextBox txtValor;
    private CheckBox chkPago;
    private Label lblDescricao;
    private TextBox txtDescricao;
    private GroupBox grpServicos;
    private CheckedListBox clbServicos;
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
        dtpDataAgenda = new DateTimePicker();
        grpAtendimentos = new GroupBox();
        dgvAtendimentos = new DataGridView();
        colDataHora = new DataGridViewTextBoxColumn();
        colCliente = new DataGridViewTextBoxColumn();
        colProfissional = new DataGridViewTextBoxColumn();
        colSituacao = new DataGridViewTextBoxColumn();
        colValor = new DataGridViewTextBoxColumn();
        grpDados = new GroupBox();
        lblUnidade = new Label();
        cbxUnidade = new ComboBox();
        lblCliente = new Label();
        cbxCliente = new ComboBox();
        btnBuscarCliente = new Button();
        lblProfissional = new Label();
        cbxProfissional = new ComboBox();
        lblDataHora = new Label();
        dtpAgendamento = new DateTimePicker();
        lblSituacao = new Label();
        cbxSituacao = new ComboBox();
        lblValor = new Label();
        txtValor = new TextBox();
        chkPago = new CheckBox();
        lblDescricao = new Label();
        txtDescricao = new TextBox();
        grpServicos = new GroupBox();
        clbServicos = new CheckedListBox();
        btnNovo = new Button();
        btnSalvar = new Button();
        btnExcluir = new Button();
        grpAtendimentos.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvAtendimentos).BeginInit();
        grpDados.SuspendLayout();
        grpServicos.SuspendLayout();
        SuspendLayout();
        // 
        // lblTitulo
        // 
        lblTitulo.AutoSize = true;
        lblTitulo.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
        lblTitulo.ForeColor = Cores.PrimaryDarkText;
        lblTitulo.Location = new Point(15, 10);
        lblTitulo.Name = "lblTitulo";
        lblTitulo.Size = new Size(77, 30);
        lblTitulo.TabIndex = 0;
        lblTitulo.Text = "Agenda";
        // 
        // dtpDataAgenda
        // 
        dtpDataAgenda.Font = new Font("Segoe UI", 9F);
        dtpDataAgenda.Format = DateTimePickerFormat.Short;
        dtpDataAgenda.Location = new Point(440, 14);
        dtpDataAgenda.Name = "dtpDataAgenda";
        dtpDataAgenda.Size = new Size(120, 23);
        dtpDataAgenda.TabIndex = 0;
        // 
        // grpAtendimentos
        // 
        grpAtendimentos.BackColor = Cores.White;
        grpAtendimentos.Controls.Add(dgvAtendimentos);
        grpAtendimentos.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        grpAtendimentos.ForeColor = Cores.Gray600;
        grpAtendimentos.Location = new Point(15, 50);
        grpAtendimentos.Name = "grpAtendimentos";
        grpAtendimentos.Size = new Size(560, 170);
        grpAtendimentos.TabIndex = 2;
        grpAtendimentos.TabStop = false;
        grpAtendimentos.Text = "Atendimentos do dia";
        // 
        // dgvAtendimentos
        // 
        dgvAtendimentos.AllowUserToAddRows = false;
        dgvAtendimentos.AllowUserToDeleteRows = false;
        dgvAtendimentos.AutoGenerateColumns = false;
        dgvAtendimentos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvAtendimentos.BackgroundColor = Cores.White;
        dgvAtendimentos.BorderStyle = BorderStyle.None;
        dgvAtendimentos.Columns.AddRange(new DataGridViewColumn[] { colDataHora, colCliente, colProfissional, colSituacao, colValor });
        dgvAtendimentos.Font = new Font("Segoe UI", 9F);
        dgvAtendimentos.Location = new Point(12, 25);
        dgvAtendimentos.MultiSelect = false;
        dgvAtendimentos.Name = "dgvAtendimentos";
        dgvAtendimentos.ReadOnly = true;
        dgvAtendimentos.RowHeadersVisible = false;
        dgvAtendimentos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvAtendimentos.Size = new Size(536, 135);
        dgvAtendimentos.TabIndex = 0;
        // 
        // colDataHora
        // 
        colDataHora.DataPropertyName = "DataHora";
        colDataHora.FillWeight = 20F;
        colDataHora.HeaderText = "Data e horário";
        colDataHora.Name = "colDataHora";
        colDataHora.ReadOnly = true;
        // 
        // colCliente
        // 
        colCliente.DataPropertyName = "NomeCliente";
        colCliente.FillWeight = 25F;
        colCliente.HeaderText = "Cliente";
        colCliente.Name = "colCliente";
        colCliente.ReadOnly = true;
        // 
        // colProfissional
        // 
        colProfissional.DataPropertyName = "NomeProfissional";
        colProfissional.FillWeight = 20F;
        colProfissional.HeaderText = "Profissional";
        colProfissional.Name = "colProfissional";
        colProfissional.ReadOnly = true;
        // 
        // colSituacao
        // 
        colSituacao.DataPropertyName = "SituacaoDescricao";
        colSituacao.FillWeight = 20F;
        colSituacao.HeaderText = "Situação";
        colSituacao.Name = "colSituacao";
        colSituacao.ReadOnly = true;
        // 
        // colValor
        // 
        colValor.DataPropertyName = "ValorFormatado";
        colValor.FillWeight = 15F;
        colValor.HeaderText = "Valor";
        colValor.Name = "colValor";
        colValor.ReadOnly = true;
        // 
        // grpDados
        // 
        grpDados.BackColor = Cores.White;
        grpDados.Controls.Add(lblUnidade);
        grpDados.Controls.Add(cbxUnidade);
        grpDados.Controls.Add(lblCliente);
        grpDados.Controls.Add(cbxCliente);
        grpDados.Controls.Add(btnBuscarCliente);
        grpDados.Controls.Add(lblProfissional);
        grpDados.Controls.Add(cbxProfissional);
        grpDados.Controls.Add(lblDataHora);
        grpDados.Controls.Add(dtpAgendamento);
        grpDados.Controls.Add(lblSituacao);
        grpDados.Controls.Add(cbxSituacao);
        grpDados.Controls.Add(lblDescricao);
        grpDados.Controls.Add(txtDescricao);
        grpDados.Controls.Add(grpServicos);
        grpDados.Controls.Add(btnNovo);
        grpDados.Controls.Add(btnSalvar);
        grpDados.Controls.Add(btnExcluir);
        grpDados.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        grpDados.ForeColor = Cores.Gray600;
        grpDados.Location = new Point(15, 230);
        grpDados.Name = "grpDados";
        grpDados.Size = new Size(560, 418);
        grpDados.TabIndex = 3;
        grpDados.TabStop = false;
        grpDados.Text = "Atendimento";
        // 
        // lblUnidade
        // 
        lblUnidade.AutoSize = true;
        lblUnidade.Font = new Font("Segoe UI", 9F);
        lblUnidade.ForeColor = Cores.PrimaryDarkText;
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
        cbxUnidade.Size = new Size(260, 23);
        cbxUnidade.TabIndex = 1;
        // 
        // lblCliente
        // 
        lblCliente.AutoSize = true;
        lblCliente.Font = new Font("Segoe UI", 9F);
        lblCliente.ForeColor = Cores.PrimaryDarkText;
        lblCliente.Location = new Point(286, 28);
        lblCliente.Name = "lblCliente";
        lblCliente.Size = new Size(39, 15);
        lblCliente.TabIndex = 2;
        lblCliente.Text = "Cliente";
        // 
        // cbxCliente
        // 
        cbxCliente.DropDownStyle = ComboBoxStyle.DropDownList;
        cbxCliente.Font = new Font("Segoe UI", 9F);
        cbxCliente.FormattingEnabled = true;
        cbxCliente.Location = new Point(286, 46);
        cbxCliente.Name = "cbxCliente";
        cbxCliente.Size = new Size(206, 23);
        cbxCliente.TabIndex = 3;
        // 
        // btnBuscarCliente
        // 
        btnBuscarCliente.BackColor = Cores.Secondary;
        btnBuscarCliente.FlatStyle = FlatStyle.Flat;
        btnBuscarCliente.Font = new Font("Segoe UI Emoji", 9F);
        btnBuscarCliente.ForeColor = Cores.PrimaryDarkText;
        btnBuscarCliente.Location = new Point(498, 45);
        btnBuscarCliente.Name = "btnBuscarCliente";
        btnBuscarCliente.Size = new Size(34, 25);
        btnBuscarCliente.TabIndex = 4;
        btnBuscarCliente.Text = "🔍";
        btnBuscarCliente.UseVisualStyleBackColor = false;
        btnBuscarCliente.Click += BtnBuscarCliente_Click;
        // 
        // lblProfissional
        // 
        lblProfissional.AutoSize = true;
        lblProfissional.Font = new Font("Segoe UI", 9F);
        lblProfissional.ForeColor = Cores.PrimaryDarkText;
        lblProfissional.Location = new Point(12, 80);
        lblProfissional.Name = "lblProfissional";
        lblProfissional.Size = new Size(67, 15);
        lblProfissional.TabIndex = 5;
        lblProfissional.Text = "Profissional";
        // 
        // cbxProfissional
        // 
        cbxProfissional.DropDownStyle = ComboBoxStyle.DropDownList;
        cbxProfissional.Font = new Font("Segoe UI", 9F);
        cbxProfissional.FormattingEnabled = true;
        cbxProfissional.Location = new Point(12, 98);
        cbxProfissional.Name = "cbxProfissional";
        cbxProfissional.Size = new Size(180, 23);
        cbxProfissional.TabIndex = 6;
        // 
        // lblDataHora
        // 
        lblDataHora.AutoSize = true;
        lblDataHora.Font = new Font("Segoe UI", 9F);
        lblDataHora.ForeColor = Cores.PrimaryDarkText;
        lblDataHora.Location = new Point(206, 80);
        lblDataHora.Name = "lblDataHora";
        lblDataHora.Size = new Size(82, 15);
        lblDataHora.TabIndex = 7;
        lblDataHora.Text = "Data e horário";
        // 
        // dtpAgendamento
        // 
        dtpAgendamento.CustomFormat = "dd/MM/yyyy HH:mm";
        dtpAgendamento.Font = new Font("Segoe UI", 9F);
        dtpAgendamento.Format = DateTimePickerFormat.Custom;
        dtpAgendamento.Location = new Point(206, 98);
        dtpAgendamento.Name = "dtpAgendamento";
        dtpAgendamento.ShowCheckBox = true;
        dtpAgendamento.Size = new Size(160, 23);
        dtpAgendamento.TabIndex = 8;
        // 
        // lblSituacao
        // 
        lblSituacao.AutoSize = true;
        lblSituacao.Font = new Font("Segoe UI", 9F);
        lblSituacao.ForeColor = Cores.PrimaryDarkText;
        lblSituacao.Location = new Point(380, 80);
        lblSituacao.Name = "lblSituacao";
        lblSituacao.Size = new Size(51, 15);
        lblSituacao.TabIndex = 9;
        lblSituacao.Text = "Situação";
        // 
        // cbxSituacao
        // 
        cbxSituacao.DropDownStyle = ComboBoxStyle.DropDownList;
        cbxSituacao.Font = new Font("Segoe UI", 9F);
        cbxSituacao.FormattingEnabled = true;
        cbxSituacao.Location = new Point(380, 98);
        cbxSituacao.Name = "cbxSituacao";
        cbxSituacao.Size = new Size(168, 23);
        cbxSituacao.TabIndex = 10;
        // 
        // lblValor
        // 
        lblValor.AutoSize = true;
        lblValor.Font = new Font("Segoe UI", 9F);
        lblValor.ForeColor = Cores.PrimaryDarkText;
        lblValor.Location = new Point(10, 116);
        lblValor.Name = "lblValor";
        lblValor.Size = new Size(36, 15);
        lblValor.TabIndex = 11;
        lblValor.Text = "Valor";
        // 
        // txtValor
        // 
        txtValor.Font = new Font("Segoe UI", 9F);
        txtValor.Location = new Point(10, 134);
        txtValor.Name = "txtValor";
        txtValor.Size = new Size(100, 23);
        txtValor.TabIndex = 12;
        // 
        // chkPago
        // 
        chkPago.AutoSize = true;
        chkPago.Font = new Font("Segoe UI", 9F);
        chkPago.ForeColor = Cores.PrimaryDarkText;
        chkPago.Location = new Point(120, 136);
        chkPago.Name = "chkPago";
        chkPago.Size = new Size(54, 19);
        chkPago.TabIndex = 13;
        chkPago.Text = "Pago";
        chkPago.UseVisualStyleBackColor = true;
        // 
        // lblDescricao
        // 
        lblDescricao.AutoSize = true;
        lblDescricao.Font = new Font("Segoe UI", 9F);
        lblDescricao.ForeColor = Cores.PrimaryDarkText;
        lblDescricao.Location = new Point(12, 132);
        lblDescricao.Name = "lblDescricao";
        lblDescricao.Size = new Size(63, 15);
        lblDescricao.TabIndex = 14;
        lblDescricao.Text = "Descrição";
        // 
        // txtDescricao
        // 
        txtDescricao.Font = new Font("Segoe UI", 9F);
        txtDescricao.Location = new Point(12, 150);
        txtDescricao.Name = "txtDescricao";
        txtDescricao.Size = new Size(536, 23);
        txtDescricao.TabIndex = 15;
        // 
        // grpServicos
        // 
        grpServicos.Controls.Add(clbServicos);
        grpServicos.Controls.Add(lblValor);
        grpServicos.Controls.Add(txtValor);
        grpServicos.Controls.Add(chkPago);
        grpServicos.Font = new Font("Segoe UI", 9F);
        grpServicos.ForeColor = Cores.PrimaryDarkText;
        grpServicos.Location = new Point(12, 184);
        grpServicos.Name = "grpServicos";
        grpServicos.Size = new Size(536, 170);
        grpServicos.TabIndex = 16;
        grpServicos.TabStop = false;
        grpServicos.Text = "Serviços";
        // 
        // clbServicos
        // 
        clbServicos.CheckOnClick = true;
        clbServicos.ColumnWidth = 165;
        clbServicos.Font = new Font("Segoe UI", 9F);
        clbServicos.FormattingEnabled = true;
        clbServicos.IntegralHeight = false;
        clbServicos.MultiColumn = true;
        clbServicos.Location = new Point(10, 20);
        clbServicos.Name = "clbServicos";
        clbServicos.Size = new Size(516, 90);
        clbServicos.TabIndex = 0;
        // 
        // btnNovo
        // 
        btnNovo.BackColor = Cores.Secondary;
        btnNovo.FlatStyle = FlatStyle.Flat;
        btnNovo.Font = new Font("Segoe UI", 9F);
        btnNovo.ForeColor = Cores.PrimaryDarkText;
        btnNovo.Location = new Point(65, 368);
        btnNovo.Name = "btnNovo";
        btnNovo.Size = new Size(150, 32);
        btnNovo.TabIndex = 19;
        btnNovo.Text = "Novo Atendimento";
        btnNovo.UseVisualStyleBackColor = false;
        btnNovo.Click += BtnNovo_Click;
        // 
        // btnSalvar
        // 
        btnSalvar.BackColor = Cores.Primary;
        btnSalvar.FlatStyle = FlatStyle.Flat;
        btnSalvar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnSalvar.ForeColor = Cores.White;
        btnSalvar.Location = new Point(225, 368);
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
        btnExcluir.ForeColor = Cores.PrimaryDarkText;
        btnExcluir.Location = new Point(365, 368);
        btnExcluir.Name = "btnExcluir";
        btnExcluir.Size = new Size(130, 32);
        btnExcluir.TabIndex = 21;
        btnExcluir.Text = "Excluir";
        btnExcluir.UseVisualStyleBackColor = false;
        btnExcluir.Click += BtnExcluir_Click;
        // 
        // AgendaUC
        // 
        AutoScroll = true;
        BackColor = Cores.Creme;
        Controls.Add(lblTitulo);
        Controls.Add(dtpDataAgenda);
        Controls.Add(grpAtendimentos);
        Controls.Add(grpDados);
        ForeColor = Cores.Gray900;
        Name = "AgendaUC";
        Size = new Size(580, 860);
        grpAtendimentos.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvAtendimentos).EndInit();
        grpDados.ResumeLayout(false);
        grpDados.PerformLayout();
        grpServicos.ResumeLayout(false);
        ResumeLayout(false);
        PerformLayout();
    }
}
