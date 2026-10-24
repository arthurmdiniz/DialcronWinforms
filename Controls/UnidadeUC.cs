using System.ComponentModel;
using DialcronWinforms.Data;
using DialcronWinforms.Data.DAO;
using DialcronWinforms.Models;

namespace DialcronWinforms.Controls;

public partial class UnidadeUC : UserControl
{
    private readonly BindingList<Unidade> _unidades = new();
    private Unidade? _selecionado;

    public UnidadeUC()
    {
        InitializeComponent();

        dgvUnidades.DataSource = _unidades;
        dgvUnidades.SelectionChanged += DgvUnidades_SelectionChanged;
        Load += OnUnidadeUCLoad;
    }

    private async void OnUnidadeUCLoad(object? sender, EventArgs e)
    {
        try
        {
            var dao = await CriarDaoAsync();
            var unidades = await dao.GetAllAsync();

            _unidades.Clear();
            foreach (var unidade in unidades)
                _unidades.Add(unidade);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Não foi possível carregar as unidades: {ex.Message}", "Unidades", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private static async Task<UnidadeDAO> CriarDaoAsync()
    {
        return new UnidadeDAO(await Database.Instance.InitializeAsync());
    }

    private void DgvUnidades_SelectionChanged(object? sender, EventArgs e)
    {
        if (dgvUnidades.CurrentRow?.DataBoundItem is not Unidade unidade)
            return;

        _selecionado = unidade;
        PreencherFormulario(unidade);
    }

    private void BtnIncluir_Click(object? sender, EventArgs e)
    {
        LimparSelecao();
        LimparFormulario();
        txtNomeFantasia.Focus();
    }

    private async void BtnSalvar_Click(object? sender, EventArgs e)
    {
        var nomeFantasia = txtNomeFantasia.Text.Trim();

        if (string.IsNullOrWhiteSpace(nomeFantasia))
        {
            MessageBox.Show("Informe o nome fantasia da unidade.", "Unidades", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            txtNomeFantasia.Focus();
            return;
        }

        try
        {
            var dao = await CriarDaoAsync();

            if (_selecionado is null)
            {
                var nova = new Unidade();
                PreencherModelo(nova);
                await dao.InsertAsync(nova);
                _unidades.Add(nova);
                _selecionado = nova;
                SelecionarNaGrid(nova);
            }
            else
            {
                PreencherModelo(_selecionado);
                await dao.UpdateAsync(_selecionado);
                dgvUnidades.Refresh();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Não foi possível salvar a unidade: {ex.Message}", "Unidades", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void BtnCancelar_Click(object? sender, EventArgs e)
    {
        LimparSelecao();
        LimparFormulario();
    }

    private void LimparSelecao()
    {
        _selecionado = null;
        dgvUnidades.ClearSelection();
    }

    private void SelecionarNaGrid(Unidade unidade)
    {
        foreach (DataGridViewRow row in dgvUnidades.Rows)
        {
            if (row.DataBoundItem == unidade)
            {
                row.Selected = true;
                dgvUnidades.CurrentCell = row.Cells[0];
                return;
            }
        }
    }

    private void PreencherFormulario(Unidade u)
    {
        txtNomeFantasia.Text = u.NomeFantasia;
        txtRazaoSocial.Text = u.RazaoSocial;
        txtCnpj.Text = u.Cnpj;
        txtInscEstadual.Text = u.InscEstadual;
        txtInscMunicipal.Text = u.InscMunicipal;
        txtCep.Text = u.Cep?.ToString();
        txtLogradouro.Text = u.Logradouro;
        txtNumero.Text = u.Numero?.ToString();
        txtBairro.Text = u.Bairro;
        txtComplemento.Text = u.Complemento;
        txtMunicipio.Text = u.Municipio;
        cbxUF.Text = u.Uf;
        txtEmail.Text = u.Email;
        txtDdd.Text = u.Ddd?.ToString();
        txtTelefone.Text = u.Telefone?.ToString();
        txtCliente.Text = u.Cliente?.ToString();
    }

    private void PreencherModelo(Unidade u)
    {
        u.NomeFantasia = txtNomeFantasia.Text.Trim();
        u.RazaoSocial = txtRazaoSocial.Text.Trim();
        u.Cnpj = txtCnpj.Text.Trim();
        u.InscEstadual = txtInscEstadual.Text.Trim();
        u.InscMunicipal = txtInscMunicipal.Text.Trim();
        u.Cep = FuncoesGerais.LerInteiro(txtCep.Text);
        u.Logradouro = txtLogradouro.Text.Trim();
        u.Numero = FuncoesGerais.LerInteiro(txtNumero.Text);
        u.Bairro = txtBairro.Text.Trim();
        u.Complemento = txtComplemento.Text.Trim();
        u.Municipio = txtMunicipio.Text.Trim();
        u.Uf = cbxUF.Text.Trim();
        u.Email = txtEmail.Text.Trim();
        u.Ddd = FuncoesGerais.LerInteiro(txtDdd.Text);
        u.Telefone = FuncoesGerais.LerInteiro(txtTelefone.Text);
        u.Cliente = FuncoesGerais.LerInteiro(txtCliente.Text);
    }

    private void LimparFormulario()
    {
        foreach (System.Windows.Forms.Control ctrl in new System.Windows.Forms.Control[]
        {
            txtNomeFantasia, txtRazaoSocial, txtCnpj, txtInscEstadual, txtInscMunicipal,
            txtCep, txtLogradouro, txtNumero, txtBairro, txtComplemento,
            txtMunicipio, cbxUF, txtEmail, txtDdd, txtTelefone, txtCliente
        })
        {
            ctrl.Text = string.Empty;
        }
    }

    // --- Input formatting for CNPJ, CEP and Telephone ---
    private bool _isFormatting;

    private void TxtCnpj_TextChanged(object? sender, EventArgs e)
    {
        if (_isFormatting) return;
        _isFormatting = true;
        var tb = txtCnpj;
        var selStart = tb.SelectionStart;
        var digitsBefore = tb.Text.Take(Math.Max(0, Math.Min(selStart, tb.Text.Length))).Count(char.IsDigit);
        var formatted = FuncoesGerais.FormatCnpj(tb.Text);
        tb.Text = formatted;
        tb.SelectionStart = FuncoesGerais.MapDigitsToPosition(formatted, digitsBefore);
        _isFormatting = false;
    }

    private void TxtCep_TextChanged(object? sender, EventArgs e)
    {
        if (_isFormatting) return;
        _isFormatting = true;
        var tb = txtCep;
        var selStart = tb.SelectionStart;
        var digitsBefore = tb.Text.Take(Math.Max(0, Math.Min(selStart, tb.Text.Length))).Count(char.IsDigit);
        var formatted = FuncoesGerais.FormatCep(tb.Text);
        tb.Text = formatted;
        tb.SelectionStart = FuncoesGerais.MapDigitsToPosition(formatted, digitsBefore);
        _isFormatting = false;
    }

    private void TxtTelefone_TextChanged(object? sender, EventArgs e)
    {
        if (_isFormatting) return;
        _isFormatting = true;
        var tb = txtTelefone;
        var selStart = tb.SelectionStart;
        var digitsBefore = tb.Text.Take(Math.Max(0, Math.Min(selStart, tb.Text.Length))).Count(char.IsDigit);
        var formatted = FuncoesGerais.FormatTelefone(tb.Text);
        tb.Text = formatted;
        tb.SelectionStart = FuncoesGerais.MapDigitsToPosition(formatted, digitsBefore);
        _isFormatting = false;
    }
}
