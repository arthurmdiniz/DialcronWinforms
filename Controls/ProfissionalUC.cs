using System.ComponentModel;
using DialcronWinforms.Data;
using DialcronWinforms.Data.DAO;
using DialcronWinforms.Models;

namespace DialcronWinforms.Controls;

public partial class ProfissionalUC : UserControl
{
    private readonly BindingList<Profissional> _profissionais = new();
    private readonly BindingList<Unidade> _unidades = new();
    private Profissional? _selecionado;

    public ProfissionalUC()
    {
        InitializeComponent();

        cbxUnidade.DataSource = _unidades;
        cbxUnidade.DisplayMember = nameof(Unidade.NomeFantasia);
        cbxUnidade.ValueMember = nameof(Unidade.IdUnidade);
        cbxUnidade.SelectedIndex = -1;

        dgvProfissionais.DataSource = _profissionais;
        dgvProfissionais.SelectionChanged += DgvProfissionais_SelectionChanged;
        Load += OnProfissionalUCLoad;
    }

    private async void OnProfissionalUCLoad(object? sender, EventArgs e)
    {
        try
        {
            var connection = await Database.Instance.InitializeAsync();
            var unidades = await new UnidadeDAO(connection).GetAllAsync();
            var profissionais = await new ProfissionalDAO(connection).GetAllAsync();

            _unidades.Clear();
            foreach (var unidade in unidades)
                _unidades.Add(unidade);

            _profissionais.Clear();
            foreach (var profissional in profissionais)
                _profissionais.Add(profissional);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Não foi possível carregar os profissionais: {ex.Message}", "Profissionais", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        LimparSelecao();
        LimparFormulario();
    }

    private static async Task<ProfissionalDAO> CriarDaoAsync()
    {
        return new ProfissionalDAO(await Database.Instance.InitializeAsync());
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

    private async void BtnSalvar_Click(object? sender, EventArgs e)
    {
        var nome = txtNome.Text.Trim();

        if (string.IsNullOrWhiteSpace(nome))
        {
            MessageBox.Show("Informe o nome do profissional.", "Profissionais", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtNome.Focus();
            return;
        }

        if (cbxUnidade.SelectedItem is not Unidade)
        {
            MessageBox.Show("Selecione a unidade do profissional.", "Profissionais", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            cbxUnidade.Focus();
            return;
        }

        if (FuncoesGerais.LerInteiro(txtDddCelular.Text) is not > 0)
        {
            MessageBox.Show("Informe o DDD do celular.", "Profissionais", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtDddCelular.Focus();
            return;
        }

        if (FuncoesGerais.LerInteiro(txtCelular.Text) is not > 0)
        {
            MessageBox.Show("Informe o celular.", "Profissionais", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtCelular.Focus();
            return;
        }

        try
        {
            var dao = await CriarDaoAsync();

            if (_selecionado is null)
            {
                var novo = new Profissional();
                PreencherModelo(novo);
                await dao.InsertAsync(novo);
                MessageBox.Show("Profissional cadastrado com sucesso.", "Profissionais", MessageBoxButtons.OK, MessageBoxIcon.Information);
                _profissionais.Add(novo);
                _selecionado = novo;
                SelecionarNaGrid(novo);
            }
            else
            {
                PreencherModelo(_selecionado);
                await dao.UpdateAsync(_selecionado);
                dgvProfissionais.Refresh();
                MessageBox.Show("Profissional atualizado com sucesso.", "Profissionais", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Não foi possível salvar o profissional: {ex.Message}", "Profissionais", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void LimparSelecao()
    {
        dgvProfissionais.ClearSelection();
        _selecionado = null;
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
