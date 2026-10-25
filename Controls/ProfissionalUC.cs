using System.ComponentModel;
using DialcronWinforms.Models;

namespace DialcronWinforms.Controls;

public partial class ProfissionalUC : UserControl
{
    private readonly BindingList<Profissional> _profissionais = new();
    private readonly BindingList<Unidade> _unidades = new();
    private Profissional? _selecionado;
    private int _proximoId = 1;

    public ProfissionalUC()
    {
        InitializeComponent();

        cbxUnidade.DataSource = _unidades;
        cbxUnidade.DisplayMember = nameof(Unidade.NomeFantasia);
        cbxUnidade.ValueMember = nameof(Unidade.IdUnidade);
        cbxUnidade.SelectedIndex = -1;

        dgvProfissionais.DataSource = _profissionais;
        dgvProfissionais.SelectionChanged += DgvProfissionais_SelectionChanged;
        dgvProfissionais.KeyDown += DgvProfissionais_KeyDown;
    }

    private void DgvProfissionais_KeyDown(object? sender, KeyEventArgs e)
    {
        if (e.KeyCode == Keys.Enter)
        {
            e.SuppressKeyPress = true;
            e.Handled = true;
            txtNome.Focus();
        }
    }

    private void DgvProfissionais_SelectionChanged(object? sender, EventArgs e)
    {
        if (dgvProfissionais.CurrentRow?.DataBoundItem is not Profissional profissional)
            return;

        _selecionado = profissional;
        PreencherFormulario(profissional);
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
            MessageBox.Show("Informe o nome do profissional.", "Profissionais", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtNome.Focus();
            return;
        }

        if (_selecionado is null)
        {
            var novo = new Profissional { Id = _proximoId++ };
            PreencherModelo(novo);
            _profissionais.Add(novo);
            _selecionado = novo;
            SelecionarNaGrid(novo);
        }
        else
        {
            PreencherModelo(_selecionado);
            dgvProfissionais.Refresh();
        }
    }

    private void LimparSelecao()
    {
        _selecionado = null;
        dgvProfissionais.ClearSelection();
    }

    private void SelecionarNaGrid(Profissional profissional)
    {
        foreach (DataGridViewRow row in dgvProfissionais.Rows)
        {
            if (row.DataBoundItem == profissional)
            {
                row.Selected = true;
                dgvProfissionais.CurrentCell = row.Cells[0];
                return;
            }
        }
    }

    private void PreencherFormulario(Profissional p)
    {
        cbxUnidade.SelectedItem = _unidades.FirstOrDefault(u => u.IdUnidade == p.Unidade);
        txtNome.Text = p.Nome;
        txtEspecialidade.Text = p.Especialidade;
        txtDddTelefone.Text = p.DddTelefone?.ToString();
        txtTelefone.Text = p.Telefone?.ToString();
        txtDddCelular.Text = p.DddCelular?.ToString();
        txtCelular.Text = p.Celular?.ToString();
        txtDddOutros.Text = p.DddOutros?.ToString();
        txtTelefoneOutros.Text = p.TelefoneOutros?.ToString();
        chkAtivo.Checked = p.Ativo != "N";
    }

    private void PreencherModelo(Profissional p)
    {
        p.Unidade = (cbxUnidade.SelectedItem as Unidade)?.IdUnidade ?? 0;
        p.Nome = txtNome.Text.Trim();
        p.Especialidade = txtEspecialidade.Text.Trim();
        p.DddTelefone = FuncoesGerais.LerInteiro(txtDddTelefone.Text);
        p.Telefone = FuncoesGerais.LerInteiro(txtTelefone.Text);
        p.DddCelular = FuncoesGerais.LerInteiro(txtDddCelular.Text);
        p.Celular = FuncoesGerais.LerInteiro(txtCelular.Text);
        p.DddOutros = FuncoesGerais.LerInteiro(txtDddOutros.Text);
        p.TelefoneOutros = FuncoesGerais.LerInteiro(txtTelefoneOutros.Text);
        p.Ativo = chkAtivo.Checked ? "S" : "N";
    }

    private void LimparFormulario()
    {
        foreach (System.Windows.Forms.Control ctrl in new System.Windows.Forms.Control[]
        {
            txtNome, txtEspecialidade, txtDddTelefone, txtTelefone,
            txtDddCelular, txtCelular, txtDddOutros, txtTelefoneOutros
        })
        {
            ctrl.Text = string.Empty;
        }

        cbxUnidade.SelectedIndex = -1;
        chkAtivo.Checked = true;
    }

    // --- Input formatting for Telephone fields ---
    private bool _isFormatting;

    private void TxtTelefone_TextChanged(object? sender, EventArgs e)
    {
        FormatarTelefone(txtTelefone);
    }

    private void TxtCelular_TextChanged(object? sender, EventArgs e)
    {
        FormatarTelefone(txtCelular);
    }

    private void TxtTelefoneOutros_TextChanged(object? sender, EventArgs e)
    {
        FormatarTelefone(txtTelefoneOutros);
    }

    private void FormatarTelefone(TextBox tb)
    {
        if (_isFormatting) return;
        _isFormatting = true;
        var selStart = tb.SelectionStart;
        var digitsBefore = tb.Text.Take(Math.Max(0, Math.Min(selStart, tb.Text.Length))).Count(char.IsDigit);
        var formatted = FuncoesGerais.FormatTelefone(tb.Text);
        tb.Text = formatted;
        tb.SelectionStart = FuncoesGerais.MapDigitsToPosition(formatted, digitsBefore);
        _isFormatting = false;
    }
}
