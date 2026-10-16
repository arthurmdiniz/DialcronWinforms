using System.ComponentModel;
using DialcronWinforms.Models;

namespace DialcronWinforms.Controls;

public partial class ServicoUC : UserControl
{
    private readonly BindingList<Servico> _servico = new();
    private readonly BindingList<Unidade> _unidades = new();
    private Servico? _selecionado;
    private int _proximoId = 1;

    public ServicoUC()
    {
        InitializeComponent();

        cbxUnidade.DataSource = _unidades;
        cbxUnidade.DisplayMember = nameof(Unidade.NomeFantasia);
        cbxUnidade.ValueMember = nameof(Unidade.IdUnidade);
        cbxUnidade.SelectedIndex = -1;

        dgvServicos.DataSource = _servico;
        dgvServicos.SelectionChanged += DgvServicos_SelectionChanged;
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

    private void BtnSalvar_Click(object? sender, EventArgs e)
    {
        var nome = txtNome.Text.Trim();

        if (string.IsNullOrWhiteSpace(nome))
        {
            MessageBox.Show("Informe o nome do Serviço.", "Serviços", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtNome.Focus();
            return;
        }

        if (_selecionado is null)
        {
            var novo = new Servico { Id = _proximoId++ };
            PreencherModelo(novo);
            _servico.Add(novo);
            _selecionado = novo;
            SelecionarNaGrid(novo);
        }
        else
        {
            PreencherModelo(_selecionado);
            dgvServicos.Refresh();
        }
    }

    private void LimparSelecao()
    {
        _selecionado = null;
        dgvServicos.ClearSelection();
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
        txtPreco.Text = s.Preco.ToString();
        txtTempo.Text = s.Tempo.ToString();
        chkAtivo.Checked = s.Ativo != "N";
    }

    private void PreencherModelo(Servico s)
    {
        s.Unidade = (cbxUnidade.SelectedItem as Unidade)?.IdUnidade ?? 0;
        s.Nome = txtNome.Text.Trim();
        s.Preco = (double)FuncoesGerais.LerDecimal(txtPreco.Text);
        s.Tempo = FuncoesGerais.LerInteiro(txtTempo.Text);

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