namespace DialcronWinforms.Controls;

partial class AgendaUC
{
    private System.ComponentModel.IContainer components = null;

    private Label lblTitulo;
    private MonthCalendar calendario;
    private GroupBox grpAtendimentos;
    private DataGridView dgvAtendimentos;
    private DataGridViewTextBoxColumn colDataHora;
    private DataGridViewTextBoxColumn colCliente;
    private DataGridViewTextBoxColumn colProfissional;
    private DataGridViewTextBoxColumn colSituacao;
    private DataGridViewTextBoxColumn colValor;
    private GroupBox grpDados;
    private Label lblBuscaCliente;
    private TextBox txtBuscaCliente;
    private Label lblUnidade;
    private ComboBox cbxUnidade;
    private Label lblCliente;
    private ComboBox cbxCliente;
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
    private Label lblObservacao;
    private TextBox txtObservacao;
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
        calendario = new MonthCalendar();
        grpAtendimentos = new GroupBox();
        dgvAtendimentos = new DataGridView();
        colDataHora = new DataGridViewTextBoxColumn();
        colCliente = new DataGridViewTextBoxColumn();
        colProfissional = new DataGridViewTextBoxColumn();
        colSituacao = new DataGridViewTextBoxColumn();
        colValor = new DataGridViewTextBoxColumn();
        grpDados = new GroupBox();
        lblBuscaCliente = new Label();
        txtBuscaCliente = new TextBox();
        lblUnidade = new Label();
        cbxUnidade = new ComboBox();
        lblCliente = new Label();
        cbxCliente = new ComboBox();
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
        lblObservacao = new Label();
        txtObservacao = new TextBox();
        btnNovo = new Button();
        btnSalvar = new Button();
        grpAtendimentos.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)dgvAtendimentos).BeginInit();
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
        lblTitulo.Size = new Size(77, 30);
        lblTitulo.TabIndex = 0;
        lblTitulo.Text = "Agenda";
        // 
        // calendario
        // 
        calendario.BackColor = Cores.White;
        calendario.ForeColor = Cores.Gray900;
        calendario.Location = new Point(15, 50);
        calendario.Name = "calendario";
        calendario.TabIndex = 1;
        calendario.TitleBackColor = Cores.Primary;
        calendario.TitleForeColor = Cores.White;
        calendario.TrailingForeColor = Cores.Gray400;
        // 
        // grpAtendimentos
        // 
        grpAtendimentos.BackColor = Cores.White;
        grpAtendimentos.Controls.Add(dgvAtendimentos);
        grpAtendimentos.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        grpAtendimentos.ForeColor = Cores.Gray600;
        grpAtendimentos.Location = new Point(15, 235);
        grpAtendimentos.Name = "grpAtendimentos";
        grpAtendimentos.Size = new Size(624, 200);
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
        dgvAtendimentos.Size = new Size(600, 165);
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
        grpDados.Controls.Add(lblBuscaCliente);
        grpDados.Controls.Add(txtBuscaCliente);
        grpDados.Controls.Add(lblUnidade);
        grpDados.Controls.Add(cbxUnidade);
        grpDados.Controls.Add(lblCliente);
        grpDados.Controls.Add(cbxCliente);
        grpDados.Controls.Add(lblProfissional);
        grpDados.Controls.Add(cbxProfissional);
        grpDados.Controls.Add(lblDataHora);
        grpDados.Controls.Add(dtpAgendamento);
        grpDados.Controls.Add(lblSituacao);
        grpDados.Controls.Add(cbxSituacao);
        grpDados.Controls.Add(lblValor);
        grpDados.Controls.Add(txtValor);
        grpDados.Controls.Add(chkPago);
        grpDados.Controls.Add(lblDescricao);
        grpDados.Controls.Add(txtDescricao);
        grpDados.Controls.Add(lblObservacao);
        grpDados.Controls.Add(txtObservacao);
        grpDados.Controls.Add(btnNovo);
        grpDados.Controls.Add(btnSalvar);
        grpDados.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
        grpDados.ForeColor = Cores.Gray600;
        grpDados.Location = new Point(15, 445);
        grpDados.Name = "grpDados";
        grpDados.Size = new Size(624, 395);
        grpDados.TabIndex = 3;
        grpDados.TabStop = false;
        grpDados.Text = "Atendimento";
        // 
        // lblBuscaCliente
        // 
        lblBuscaCliente.AutoSize = true;
        lblBuscaCliente.Font = new Font("Segoe UI", 9F);
        lblBuscaCliente.ForeColor = Cores.PrimaryDarkText;
        lblBuscaCliente.Location = new Point(12, 28);
        lblBuscaCliente.Name = "lblBuscaCliente";
        lblBuscaCliente.Size = new Size(182, 15);
        lblBuscaCliente.TabIndex = 0;
        lblBuscaCliente.Text = "Buscar cliente (nome ou telefone)";
        // 
        // txtBuscaCliente
        // 
        txtBuscaCliente.Font = new Font("Segoe UI", 9F);
        txtBuscaCliente.Location = new Point(12, 46);
        txtBuscaCliente.Name = "txtBuscaCliente";
        txtBuscaCliente.Size = new Size(300, 23);
        txtBuscaCliente.TabIndex = 1;
        // 
        // lblUnidade
        // 
        lblUnidade.AutoSize = true;
        lblUnidade.Font = new Font("Segoe UI", 9F);
        lblUnidade.ForeColor = Cores.PrimaryDarkText;
        lblUnidade.Location = new Point(330, 28);
        lblUnidade.Name = "lblUnidade";
        lblUnidade.Size = new Size(51, 15);
        lblUnidade.TabIndex = 2;
        lblUnidade.Text = "Unidade";
        // 
        // cbxUnidade
        // 
        cbxUnidade.DropDownStyle = ComboBoxStyle.DropDownList;
        cbxUnidade.Font = new Font("Segoe UI", 9F);
        cbxUnidade.FormattingEnabled = true;
        cbxUnidade.Location = new Point(330, 46);
        cbxUnidade.Name = "cbxUnidade";
        cbxUnidade.Size = new Size(282, 23);
        cbxUnidade.TabIndex = 3;
        // 
        // lblCliente
        // 
        lblCliente.AutoSize = true;
        lblCliente.Font = new Font("Segoe UI", 9F);
        lblCliente.ForeColor = Cores.PrimaryDarkText;
        lblCliente.Location = new Point(12, 80);
        lblCliente.Name = "lblCliente";
        lblCliente.Size = new Size(39, 15);
        lblCliente.TabIndex = 4;
        lblCliente.Text = "Cliente";
        // 
        // cbxCliente
        // 
        cbxCliente.DropDownStyle = ComboBoxStyle.DropDownList;
        cbxCliente.Font = new Font("Segoe UI", 9F);
        cbxCliente.FormattingEnabled = true;
        cbxCliente.Location = new Point(12, 98);
        cbxCliente.Name = "cbxCliente";
        cbxCliente.Size = new Size(600, 23);
        cbxCliente.TabIndex = 5;
        // 
        // lblProfissional
        // 
        lblProfissional.AutoSize = true;
        lblProfissional.Font = new Font("Segoe UI", 9F);
        lblProfissional.ForeColor = Cores.PrimaryDarkText;
        lblProfissional.Location = new Point(12, 132);
        lblProfissional.Name = "lblProfissional";
        lblProfissional.Size = new Size(67, 15);
        lblProfissional.TabIndex = 6;
        lblProfissional.Text = "Profissional";
        // 
        // cbxProfissional
        // 
        cbxProfissional.DropDownStyle = ComboBoxStyle.DropDownList;
        cbxProfissional.Font = new Font("Segoe UI", 9F);
        cbxProfissional.FormattingEnabled = true;
        cbxProfissional.Location = new Point(12, 150);
        cbxProfissional.Name = "cbxProfissional";
        cbxProfissional.Size = new Size(300, 23);
        cbxProfissional.TabIndex = 7;
        // 
        // lblDataHora
        // 
        lblDataHora.AutoSize = true;
        lblDataHora.Font = new Font("Segoe UI", 9F);
        lblDataHora.ForeColor = Cores.PrimaryDarkText;
        lblDataHora.Location = new Point(330, 132);
        lblDataHora.Name = "lblDataHora";
        lblDataHora.Size = new Size(82, 15);
        lblDataHora.TabIndex = 8;
        lblDataHora.Text = "Data e horário";
        // 
        // dtpAgendamento
        // 
        dtpAgendamento.CustomFormat = "dd/MM/yyyy HH:mm";
        dtpAgendamento.Font = new Font("Segoe UI", 9F);
        dtpAgendamento.Format = DateTimePickerFormat.Custom;
        dtpAgendamento.Location = new Point(330, 150);
        dtpAgendamento.Name = "dtpAgendamento";
        dtpAgendamento.Size = new Size(282, 23);
        dtpAgendamento.TabIndex = 9;
        // 
        // lblSituacao
        // 
        lblSituacao.AutoSize = true;
        lblSituacao.Font = new Font("Segoe UI", 9F);
        lblSituacao.ForeColor = Cores.PrimaryDarkText;
        lblSituacao.Location = new Point(12, 184);
        lblSituacao.Name = "lblSituacao";
        lblSituacao.Size = new Size(51, 15);
        lblSituacao.TabIndex = 10;
        lblSituacao.Text = "Situação";
        // 
        // cbxSituacao
        // 
        cbxSituacao.DropDownStyle = ComboBoxStyle.DropDownList;
        cbxSituacao.Font = new Font("Segoe UI", 9F);
        cbxSituacao.FormattingEnabled = true;
        cbxSituacao.Location = new Point(12, 202);
        cbxSituacao.Name = "cbxSituacao";
        cbxSituacao.Size = new Size(200, 23);
        cbxSituacao.TabIndex = 11;
        // 
        // lblValor
        // 
        lblValor.AutoSize = true;
        lblValor.Font = new Font("Segoe UI", 9F);
        lblValor.ForeColor = Cores.PrimaryDarkText;
        lblValor.Location = new Point(230, 184);
        lblValor.Name = "lblValor";
        lblValor.Size = new Size(36, 15);
        lblValor.TabIndex = 12;
        lblValor.Text = "Valor";
        // 
        // txtValor
        // 
        txtValor.Font = new Font("Segoe UI", 9F);
        txtValor.Location = new Point(230, 202);
        txtValor.Name = "txtValor";
        txtValor.Size = new Size(100, 23);
        txtValor.TabIndex = 13;
        // 
        // chkPago
        // 
        chkPago.AutoSize = true;
        chkPago.Font = new Font("Segoe UI", 9F);
        chkPago.ForeColor = Cores.PrimaryDarkText;
        chkPago.Location = new Point(350, 204);
        chkPago.Name = "chkPago";
        chkPago.Size = new Size(54, 19);
        chkPago.TabIndex = 14;
        chkPago.Text = "Pago";
        chkPago.UseVisualStyleBackColor = true;
        // 
        // lblDescricao
        // 
        lblDescricao.AutoSize = true;
        lblDescricao.Font = new Font("Segoe UI", 9F);
        lblDescricao.ForeColor = Cores.PrimaryDarkText;
        lblDescricao.Location = new Point(12, 236);
        lblDescricao.Name = "lblDescricao";
        lblDescricao.Size = new Size(63, 15);
        lblDescricao.TabIndex = 15;
        lblDescricao.Text = "Descrição";
        // 
        // txtDescricao
        // 
        txtDescricao.Font = new Font("Segoe UI", 9F);
        txtDescricao.Location = new Point(12, 254);
        txtDescricao.Name = "txtDescricao";
        txtDescricao.Size = new Size(600, 23);
        txtDescricao.TabIndex = 16;
        // 
        // lblObservacao
        // 
        lblObservacao.AutoSize = true;
        lblObservacao.Font = new Font("Segoe UI", 9F);
        lblObservacao.ForeColor = Cores.PrimaryDarkText;
        lblObservacao.Location = new Point(12, 288);
        lblObservacao.Name = "lblObservacao";
        lblObservacao.Size = new Size(74, 15);
        lblObservacao.TabIndex = 17;
        lblObservacao.Text = "Observação";
        // 
        // txtObservacao
        // 
        txtObservacao.Font = new Font("Segoe UI", 9F);
        txtObservacao.Location = new Point(12, 306);
        txtObservacao.Name = "txtObservacao";
        txtObservacao.Size = new Size(600, 23);
        txtObservacao.TabIndex = 18;
        // 
        // btnNovo
        // 
        btnNovo.BackColor = Cores.Secondary;
        btnNovo.FlatStyle = FlatStyle.Flat;
        btnNovo.Font = new Font("Segoe UI", 9F);
        btnNovo.ForeColor = Cores.PrimaryDarkText;
        btnNovo.Location = new Point(12, 350);
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
        btnSalvar.Location = new Point(172, 350);
        btnSalvar.Name = "btnSalvar";
        btnSalvar.Size = new Size(130, 32);
        btnSalvar.TabIndex = 20;
        btnSalvar.Text = "Salvar";
        btnSalvar.UseVisualStyleBackColor = false;
        btnSalvar.Click += BtnSalvar_Click;
        // 
        // AgendaUC
        // 
        AutoScroll = true;
        BackColor = Cores.Creme;
        Controls.Add(lblTitulo);
        Controls.Add(calendario);
        Controls.Add(grpAtendimentos);
        Controls.Add(grpDados);
        ForeColor = Cores.Gray900;
        Name = "AgendaUC";
        Size = new Size(654, 860);
        grpAtendimentos.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)dgvAtendimentos).EndInit();
        grpDados.ResumeLayout(false);
        grpDados.PerformLayout();
        ResumeLayout(false);
        PerformLayout();
    }
}
