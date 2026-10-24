using System.ComponentModel;
using System.Globalization;
using SQLite;
using DialcronWinforms.Data;
using DialcronWinforms.Data.DAO;
using DialcronWinforms.Forms;
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

    private readonly BindingList<AgendaItem> _visiveis = new();
    private List<Cliente> _clientes = new();
    private List<Unidade> _unidades = new();
    private List<Profissional> _profissionais = new();
    private List<Servico> _servicos = new();
    private AgendaItem? _selecionado;

    public AgendaUC()
    {
        InitializeComponent();

        dgvAtendimentos.DataSource = _visiveis;
        dgvAtendimentos.SelectionChanged += DgvAtendimentos_SelectionChanged;
        clbServicos.ItemCheck += ClbServicos_ItemCheck;
        txtValor.Leave += TxtValor_Leave;
        Load += AgendaUC_Load;
        dtpDataAgenda.ValueChanged += async (_, _) => await FiltrarPorDiaAsync(dtpDataAgenda.Value.Date);
        Resize += (_, _) => CentralizarConteudo();
    }

    private void CentralizarConteudo()
    {
        var x = Math.Max(0, (ClientSize.Width - grpDados.Width) / 2);
        lblTitulo.Left = x;
        dtpDataAgenda.Left = x + grpDados.Width - dtpDataAgenda.Width;
        grpAtendimentos.Left = x;
        grpDados.Left = x;
    }

    private void ClbServicos_ItemCheck(object? sender, ItemCheckEventArgs e)
    {
        var total = 0m;
        for (var i = 0; i < clbServicos.Items.Count; i++)
        {
            var marcado = i == e.Index ? e.NewValue == CheckState.Checked : clbServicos.GetItemChecked(i);
            if (marcado)
                total += (decimal)((Servico)clbServicos.Items[i]).Preco;
        }

        txtValor.Text = FormatarValor(total);
    }

    private void TxtValor_Leave(object? sender, EventArgs e)
    {
        if (FuncoesGerais.LerDecimal(txtValor.Text) is decimal valor)
            txtValor.Text = FormatarValor(valor);
    }

    private static string FormatarValor(decimal valor)
    {
        return string.Create(CultureInfo.InvariantCulture, $"R${valor:0.00}");
    }

    private async void AgendaUC_Load(object? sender, EventArgs e)
    {
        try
        {
            var conexao = await Database.Instance.InitializeAsync();
            _clientes = await new ClienteDAO(conexao).GetAllAsync();
            _unidades = await new UnidadeDAO(conexao).GetAllAsync();
            _profissionais = await new ProfissionalDAO(conexao).GetAllAsync();
            _servicos = (await new ServicoDAO(conexao).GetAllAsync()).Where(s => s.Ativo != "N").ToList();
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

        clbServicos.Items.Clear();
        clbServicos.DisplayMember = nameof(Servico.Nome);
        foreach (var servico in _servicos)
            clbServicos.Items.Add(servico);

        await FiltrarPorDiaAsync(dtpDataAgenda.Value.Date);
    }

    private async Task FiltrarPorDiaAsync(DateTime data)
    {
        LimparSelecao();
        LimparFormulario();
        _visiveis.Clear();

        try
        {
            var conexao = await Database.Instance.InitializeAsync();
            var belos = await new BelAtendimentoDAO(conexao).GetByDataAsync(data);
            var atendimentoDao = new AtendimentoDAO(conexao);
            var servicoDao = new AtendimentoServicoDAO(conexao);

            foreach (var belo in belos.OrderBy(b => b.DtaAtendimento))
            {
                var cadastro = await atendimentoDao.GetByIdAsync(belo.Atendimento);
                if (cadastro is null)
                    continue;

                var servicos = await servicoDao.GetByAtendimentoAsync(belo.Id);

                _visiveis.Add(new AgendaItem
                {
                    Cadastro = cadastro,
                    Belo = belo,
                    ServicosIds = servicos.Select(s => s.Servico).ToList(),
                    NomeCliente = _clientes.FirstOrDefault(c => c.ClienteId == cadastro.Cliente)?.Nome ?? string.Empty,
                    NomeProfissional = _profissionais.FirstOrDefault(p => p.Id == belo.Profissional)?.Nome ?? string.Empty,
                });
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Não foi possível carregar os atendimentos: {ex.Message}", "Agenda", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        LimparSelecao();
        LimparFormulario();
    }

    private void DgvAtendimentos_SelectionChanged(object? sender, EventArgs e)
    {
        if (dgvAtendimentos.CurrentRow?.DataBoundItem is not AgendaItem item)
            return;

        _selecionado = item;
        PreencherFormulario(item);
    }

    private void BtnBuscarCliente_Click(object? sender, EventArgs e)
    {
        using var janela = new BuscarClienteForm(_clientes);
        if (janela.ShowDialog(FindForm()) != DialogResult.OK || janela.ClienteSelecionado is null)
            return;

        cbxCliente.SelectedItem = _clientes.FirstOrDefault(c => c.ClienteId == janela.ClienteSelecionado.ClienteId);
    }

    private void BtnNovo_Click(object? sender, EventArgs e)
    {
        LimparSelecao();
        LimparFormulario();
        cbxUnidade.Focus();
    }

    private async void BtnSalvar_Click(object? sender, EventArgs e)
    {
        if (!ValidarFormulario())
            return;

        try
        {
            var conexao = await Database.Instance.InitializeAsync();

            var novoAtendimento = _selecionado is null;

            if (_selecionado is null)
            {
                var agora = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
                var novo = new AgendaItem
                {
                    Cadastro = new Atendimento { DtaCriacao = agora },
                    Belo = new BelAtendimento { DtaCriacao = agora },
                };
                PreencherModelo(novo);

                await conexao.RunInTransactionAsync(tx =>
                {
                    tx.Insert(novo.Cadastro);
                    novo.Belo.Atendimento = novo.Cadastro.Id;
                    tx.Insert(novo.Belo);
                    InserirServicos(tx, novo);
                });
            }
            else
            {
                var atual = _selecionado;
                PreencherModelo(atual);

                await conexao.RunInTransactionAsync(tx =>
                {
                    tx.Update(atual.Cadastro);
                    tx.Update(atual.Belo);
                    tx.Table<AtendimentoServico>().Delete(s => s.Atendimento == atual.Belo.Id);
                    InserirServicos(tx, atual);
                });
            }

            await FiltrarPorDiaAsync(dtpDataAgenda.Value.Date);

            MessageBox.Show(
                novoAtendimento ? "Atendimento cadastrado com sucesso." : "Atendimento atualizado com sucesso.",
                "Agenda",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Não foi possível salvar o atendimento: {ex.Message}", "Agenda", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private static void InserirServicos(SQLiteConnection tx, AgendaItem item)
    {
        foreach (var servicoId in item.ServicosIds)
        {
            tx.Insert(new AtendimentoServico
            {
                Atendimento = item.Belo.Id,
                Servico = servicoId,
            });
        }
    }

    private async void BtnExcluir_Click(object? sender, EventArgs e)
    {
        if (_selecionado is null)
        {
            MessageBox.Show("Selecione um atendimento na lista para excluir.", "Agenda", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        var confirmacao = MessageBox.Show(
            $"Excluir o atendimento de \"{_selecionado.NomeCliente}\"?",
            "Agenda",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question);

        if (confirmacao != DialogResult.Yes)
            return;

        try
        {
            var conexao = await Database.Instance.InitializeAsync();
            _selecionado.Belo.Situacao = "E";
            await new BelAtendimentoDAO(conexao).UpdateAsync(_selecionado.Belo);

            LimparSelecao();
            await FiltrarPorDiaAsync(dtpDataAgenda.Value.Date);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Não foi possível excluir o atendimento: {ex.Message}", "Agenda", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        if (!dtpAgendamento.Checked)
        {
            Alertar("Informe a data e o horário do atendimento.", dtpAgendamento);
            return false;
        }

        if (clbServicos.CheckedItems.Count == 0)
        {
            Alertar("Selecione pelo menos um serviço.", clbServicos);
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
        dgvAtendimentos.ClearSelection();
        _selecionado = null;
    }

    private void PreencherFormulario(AgendaItem item)
    {
        var cadastro = item.Cadastro;
        var belo = item.Belo;

        cbxUnidade.SelectedItem = _unidades.FirstOrDefault(u => u.IdUnidade == cadastro.Unidade);
        cbxCliente.SelectedItem = _clientes.FirstOrDefault(c => c.ClienteId == cadastro.Cliente);
        cbxProfissional.SelectedItem = _profissionais.FirstOrDefault(p => p.Id == belo.Profissional);
        cbxSituacao.SelectedItem = Situacoes.FirstOrDefault(s => s.Codigo == belo.Situacao) ?? Situacoes[0];
        dtpAgendamento.Value = item.Hora == DateTime.MinValue ? DateTime.Now : item.Hora;
        dtpAgendamento.Checked = true;
        txtDescricao.Text = cadastro.Descricao;
        for (var i = 0; i < clbServicos.Items.Count; i++)
            clbServicos.SetItemChecked(i, item.ServicosIds.Contains(((Servico)clbServicos.Items[i]).Id));
        txtValor.Text = FormatarValor((decimal)belo.Valor);
        chkPago.Checked = belo.Pago == 1;
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

        item.ServicosIds = clbServicos.CheckedItems.Cast<Servico>().Select(s => s.Id).ToList();
        item.NomeCliente = cliente?.Nome ?? string.Empty;
        item.NomeProfissional = profissional?.Nome ?? string.Empty;
    }

    private void LimparFormulario()
    {
        txtDescricao.Text = string.Empty;
        for (var i = 0; i < clbServicos.Items.Count; i++)
            clbServicos.SetItemChecked(i, false);
        txtValor.Text = string.Empty;
        chkPago.Checked = false;
        cbxCliente.SelectedIndex = -1;
        cbxUnidade.SelectedIndex = -1;
        cbxProfissional.SelectedIndex = -1;
        cbxSituacao.SelectedItem = Situacoes[0];
        dtpAgendamento.Value = dtpDataAgenda.Value.Date.Add(DateTime.Now.TimeOfDay);
        dtpAgendamento.Checked = false;
    }

    private sealed record OpcaoSituacao(string Codigo, string Descricao);

    private sealed class AgendaItem
    {
        public Atendimento Cadastro { get; set; } = new();

        public BelAtendimento Belo { get; set; } = new();

        public string NomeCliente { get; set; } = string.Empty;

        public string NomeProfissional { get; set; } = string.Empty;

        public List<int> ServicosIds { get; set; } = new();

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
