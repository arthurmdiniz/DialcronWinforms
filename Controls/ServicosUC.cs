using System.ComponentModel;
using System.Globalization;
using DialcronWinforms.Data;
using DialcronWinforms.Data.DAO;
using DialcronWinforms.Models;

namespace DialcronWinforms.Controls;

public partial class ServicoUC : UserControl
{
    private readonly BindingList<Servico> _servico = new();
    private readonly BindingList<Unidade> _unidades = new();
    private Servico? _selecionado;

    public ServicoUC()
    {
        InitializeComponent();

        cbxUnidade.DataSource = _unidades;
        cbxUnidade.DisplayMember = nameof(Unidade.NomeFantasia);
        cbxUnidade.ValueMember = nameof(Unidade.IdUnidade);
        cbxUnidade.SelectedIndex = -1;

        dgvServicos.DataSource = _servico;
        dgvServicos.SelectionChanged += DgvServicos_SelectionChanged;
        dgvServicos.KeyDown += DgvServicos_KeyDown;
    }

    private void DgvServicos_KeyDown(object? sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            e.SuppressKeyPress = true;
            e.Handled = true;
            txtNome.Focus();
        }
    }

    private void DgvServicos_SelectionChanged(object? sender, EventArgs e)
    {
        if (dgvServicos.CurrentRow?.DataBoundItem is not Servico servico)
            return;

        _selecionado = servico;
        PreencherFormulario(servico);
    }

    private void BtnNovo_Click(object? sender, EventArgs e)
    {
        LimparSelecao();
        LimparFormulario();
        txtNome.Focus();
    }

    private async void BtnSalvar_Click(object? sender, EventArgs e)
    {
        if (!ValidarFormulario())
            return;

        try
        {
            var dao = await CriarDaoAsync();

            if (_selecionado is null)
            {
                var novo = new Servico();
                PreencherModelo(novo);
                await dao.InsertAsync(novo);
                MessageBox.Show("Serviço cadastrado com sucesso.", "Serviços", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _servico.Add(novo);
                _selecionado = novo;
                SelecionarNaGrid(novo);
            }
            else
            {
                PreencherModelo(_selecionado);
                await dao.UpdateAsync(_selecionado);
                dgvServicos.Refresh();
                MessageBox.Show("Serviço atualizado com sucesso.", "Serviços", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Não foi possível salvar o serviço: {ex.Message}", "Serviços", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private bool ValidarFormulario()
    {
        if (string.IsNullOrWhiteSpace(txtNome.Text))
        {
            Alertar("Informe o nome do Serviço.", txtNome);
            return false;
        }

        if (cbxUnidade.SelectedItem is not Unidade)
        {
            Alertar("Selecione a unidade do serviço.", cbxUnidade);
            return false;
        }

        if (FuncoesGerais.LerDecimal(txtPreco.Text) is not > 0)
        {
            Alertar("Informe um preço válido.", txtPreco);
            return false;
        }

        if (FuncoesGerais.LerInteiro(txtTempo.Text) is not > 0)
        {
            Alertar("Informe a duração em minutos.", txtTempo);
            return false;
        }

        return true;
    }

    private static void Alertar(string mensagem, Control campo)
    {
        MessageBox.Show(mensagem, "Serviços", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        campo.Focus();
    }

    private void LimparSelecao()
    {
        dgvServicos.ClearSelection();
        _selecionado = null;
    }

    private void SelecionarNaGrid(Servico servico)
    {
        foreach (DataGridViewRow row in dgvServicos.Rows)
        {
            if (row.DataBoundItem == servico)
            {
                row.Selected = true;
                dgvServicos.CurrentCell = row.Cells[0];
                return;
            }
        }
    }

    private void PreencherFormulario(Servico s)
    {
        cbxUnidade.SelectedItem = _unidades.FirstOrDefault(u => u.IdUnidade == s.Unidade);
        txtNome.Text = s.Nome;
        txtPreco.Text = FormatarPreco((decimal)s.Preco);
        txtTempo.Text = s.DuracaoMinutos.ToString();
        chkAtivo.Checked = s.Ativo != "N";
    }

    private void PreencherModelo(Servico s)
    {
        s.Unidade = (cbxUnidade.SelectedItem as Unidade)?.IdUnidade ?? 0;
        s.Nome = txtNome.Text.Trim();
        s.Preco = (double)(FuncoesGerais.LerDecimal(txtPreco.Text) ?? 0m);
        s.DuracaoMinutos = FuncoesGerais.LerInteiro(txtTempo.Text) ?? 0;

        s.Ativo = chkAtivo.Checked ? "S" : "N";
    }

    private void LimparFormulario()
    {
        foreach (System.Windows.Forms.Control ctrl in new System.Windows.Forms.Control[]
        {
            txtNome, txtPreco, txtTempo
        })
        {
            ctrl.Text = string.Empty;
        }

        cbxUnidade.SelectedIndex = -1;
        chkAtivo.Checked = true;
    }

}
