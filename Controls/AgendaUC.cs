using System.ComponentModel;
using System.Globalization;
using DialcronWinforms.Data;
using DialcronWinforms.Data.DAO;
using DialcronWinforms.Models;

namespace DialcronWinforms.Controls;

public partial class AgendaUC : UserControl
{
    private static readonly OpcaoSituacao[] Situacoes =
    {
        new("a", "Agendado"),
        new("v", "Confirmado"),
        new("f", "Concluído"),
        new("c", "Cancelado"),
        new("n", "Não compareceu"),
    };

    private readonly List<AgendaItem> _itens = new();
    private readonly BindingList<AgendaItem> _visiveis = new();
    private List<Cliente> _clientes = new();
    private List<Unidade> _unidades = new();
    private List<Profissional> _profissionais = new();
    private AgendaItem? _selecionado;
    private int _proximoId = 1;

    public AgendaUC()
    {
        InitializeComponent();

        dgvAtendimentos.DataSource = _visiveis;
        dgvAtendimentos.SelectionChanged += DgvAtendimentos_SelectionChanged;
        calendario.DateSelected += Calendario_DateSelected;
        txtBuscaCliente.TextChanged += TxtBuscaCliente_TextChanged;
        Load += AgendaUC_Load;
    }

    private async void AgendaUC_Load(object? sender, EventArgs e)
    {
        try
        {
            var conexao = await Database.Instance.InitializeAsync();
            _clientes = await new ClienteDAO(conexao).GetAllAsync();
            _unidades = await new UnidadeDAO(conexao).GetAllAsync();
            _profissionais = await new ProfissionalDAO(conexao).GetAllAsync();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Não foi possível carregar os cadastros: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        cbxCliente.DataSource = _clientes;
        cbxCliente.DisplayMember = nameof(Cliente.Nome);
        cbxCliente.SelectedIndex = -1;

        cbxUnidade.DataSource = _unidades;
        cbxUnidade.DisplayMember = nameof(Unidade.NomeFantasia);
        cbxUnidade.SelectedIndex = -1;

        cbxProfissional.DataSource = _profissionais;
        cbxProfissional.DisplayMember = nameof(Profissional.Nome);
        cbxProfissional.SelectedIndex = -1;

        cbxSituacao.DataSource = Situacoes;
        cbxSituacao.DisplayMember = nameof(OpcaoSituacao.Descricao);

        FiltrarPorDia(calendario.SelectionStart);
    }

    private void Calendario_DateSelected(object? sender, DateRangeEventArgs e)
    {
        FiltrarPorDia(e.Start);
    }

    private void FiltrarPorDia(DateTime data)
    {
        LimparSelecao();
        LimparFormulario();
        _visiveis.Clear();

        foreach (var item in _itens.Where(i => i.Data == data.Date))
            _visiveis.Add(item);
    }

    private void DgvAtendimentos_SelectionChanged(object? sender, EventArgs e)
    {
        if (dgvAtendimentos.CurrentRow?.DataBoundItem is not AgendaItem item)
            return;

        _selecionado = item;
        PreencherFormulario(item);
    }

    private void TxtBuscaCliente_TextChanged(object? sender, EventArgs e)
    {
        var termo = txtBuscaCliente.Text.Trim();
        var digitos = FuncoesGerais.OnlyDigits(termo);

        var filtrados = _clientes
            .Where(c => termo.Length == 0
                || (c.Nome?.Contains(termo, StringComparison.OrdinalIgnoreCase) ?? false)
                || (digitos.Length > 0 && TelefoneDigitos(c).Contains(digitos)))
            .ToList();

        var selecionado = cbxCliente.SelectedItem as Cliente;
        cbxCliente.DataSource = filtrados;
        cbxCliente.SelectedItem = filtrados.FirstOrDefault(c => c.ClienteId == selecionado?.ClienteId);
    }

    private static string TelefoneDigitos(Cliente c)
    {
        return (c.DddTelefone?.ToString() ?? string.Empty) + (c.Telefone?.ToString() ?? string.Empty);
    }

    private void BtnNovo_Click(object? sender, EventArgs e)
    {
        LimparSelecao();
        LimparFormulario();
        txtBuscaCliente.Focus();
    }

    private void BtnSalvar_Click(object? sender, EventArgs e)
    {
        if (!ValidarFormulario())
            return;

        if (_selecionado is null)
        {
            var novo = new AgendaItem
            {
                Cadastro = new Atendimento { Id = _proximoId },
                Belo = new BelAtendimento { Id = _proximoId },
            };
            _proximoId++;
            PreencherModelo(novo);
            _itens.Add(novo);
            FiltrarPorDia(calendario.SelectionStart);
            SelecionarNaGrid(novo);
        }
        else
        {
            PreencherModelo(_selecionado);
            var atual = _selecionado;
            FiltrarPorDia(calendario.SelectionStart);
            SelecionarNaGrid(atual);
        }
    }

    private bool ValidarFormulario()
    {
        if (cbxUnidade.SelectedItem is not Unidade)
        {
            Alertar("Selecione a unidade.", cbxUnidade);
            return false;
        }

        if (cbxCliente.SelectedItem is not Cliente)
        {
            Alertar("Selecione o cliente.", cbxCliente);
            return false;
        }

        if (cbxProfissional.SelectedItem is not Profissional)
        {
            Alertar("Selecione o profissional.", cbxProfissional);
            return false;
        }

        if (string.IsNullOrWhiteSpace(txtDescricao.Text))
        {
            Alertar("Informe a descrição do atendimento.", txtDescricao);
            return false;
        }

        return true;
    }

    private static void Alertar(string mensagem, Control campo)
    {
        MessageBox.Show(mensagem, "Agenda", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        campo.Focus();
    }

    private void LimparSelecao()
    {
        _selecionado = null;
        dgvAtendimentos.ClearSelection();
    }

    private void SelecionarNaGrid(AgendaItem item)
    {
        foreach (DataGridViewRow row in dgvAtendimentos.Rows)
        {
            if (row.DataBoundItem == item)
            {
                row.Selected = true;
                dgvAtendimentos.CurrentCell = row.Cells[0];
                return;
            }
        }
    }

    private void PreencherFormulario(AgendaItem item)
    {
        var cadastro = item.Cadastro;
        var belo = item.Belo;

        txtBuscaCliente.Text = string.Empty;
        cbxUnidade.SelectedItem = _unidades.FirstOrDefault(u => u.IdUnidade == cadastro.Unidade);
        cbxCliente.SelectedItem = _clientes.FirstOrDefault(c => c.ClienteId == cadastro.Cliente);
        cbxProfissional.SelectedItem = _profissionais.FirstOrDefault(p => p.Id == belo.Profissional);
        cbxSituacao.SelectedItem = Situacoes.FirstOrDefault(s => s.Codigo == belo.Situacao) ?? Situacoes[0];
        dtpAgendamento.Value = item.Hora == DateTime.MinValue ? DateTime.Now : item.Hora;
        txtDescricao.Text = cadastro.Descricao;
        txtValor.Text = belo.Valor.ToString("0.00", CultureInfo.InvariantCulture);
        chkPago.Checked = belo.Pago == 1;
        txtObservacao.Text = belo.Observacao;
    }

    private void PreencherModelo(AgendaItem item)
    {
        var cadastro = item.Cadastro;
        var belo = item.Belo;
        var cliente = cbxCliente.SelectedItem as Cliente;
        var profissional = cbxProfissional.SelectedItem as Profissional;

        cadastro.Unidade = (cbxUnidade.SelectedItem as Unidade)?.IdUnidade ?? 0;
        cadastro.Cliente = cliente?.ClienteId;
        cadastro.Descricao = txtDescricao.Text.Trim();

        belo.Atendimento = cadastro.Id;
        belo.Profissional = profissional?.Id ?? 0;
        belo.DtaAtendimento = dtpAgendamento.Value.ToString("yyyy-MM-dd HH:mm", CultureInfo.InvariantCulture);
        belo.Situacao = (cbxSituacao.SelectedItem as OpcaoSituacao)?.Codigo ?? Situacoes[0].Codigo;
        belo.Valor = (double)(FuncoesGerais.LerDecimal(txtValor.Text) ?? 0m);
        belo.Pago = chkPago.Checked ? 1 : 0;
        belo.Observacao = string.IsNullOrWhiteSpace(txtObservacao.Text) ? null : txtObservacao.Text.Trim();

        item.NomeCliente = cliente?.Nome ?? string.Empty;
        item.NomeProfissional = profissional?.Nome ?? string.Empty;
    }

    private void LimparFormulario()
    {
        txtBuscaCliente.Text = string.Empty;
        txtDescricao.Text = string.Empty;
        txtValor.Text = string.Empty;
        txtObservacao.Text = string.Empty;
        chkPago.Checked = false;
        cbxCliente.SelectedIndex = -1;
        cbxUnidade.SelectedIndex = -1;
        cbxProfissional.SelectedIndex = -1;
        cbxSituacao.SelectedItem = Situacoes[0];
        dtpAgendamento.Value = calendario.SelectionStart.Date.Add(DateTime.Now.TimeOfDay);
    }

    private sealed record OpcaoSituacao(string Codigo, string Descricao);

    private sealed class AgendaItem
    {
        public Atendimento Cadastro { get; set; } = new();

        public BelAtendimento Belo { get; set; } = new();

        public string NomeCliente { get; set; } = string.Empty;

        public string NomeProfissional { get; set; } = string.Empty;

        public DateTime Data => Hora.Date;

        public DateTime Hora => TryLerDataHora(Belo.DtaAtendimento, out var dataHora) ? dataHora : DateTime.MinValue;

        public string DataHora => Hora == DateTime.MinValue
            ? string.Empty
            : Hora.ToString("dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);

        public string SituacaoDescricao => Situacoes.FirstOrDefault(s => s.Codigo == Belo.Situacao)?.Descricao ?? Belo.Situacao ?? string.Empty;

        public string ValorFormatado => Belo.Valor.ToString("C", CultureInfo.GetCultureInfo("pt-BR"));
    }

    private static readonly string[] FormatosDataHora = { "yyyy-MM-dd HH:mm", "yyyy-MM-dd" };

    private static bool TryLerDataHora(string? texto, out DateTime dataHora)
    {
        return DateTime.TryParseExact(texto, FormatosDataHora, CultureInfo.InvariantCulture, DateTimeStyles.None, out dataHora);
    }
}
