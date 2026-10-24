using System.ComponentModel;
using System.Globalization;
using DialcronWinforms.Data;
using DialcronWinforms.Data.DAO;
using DialcronWinforms.Models;

namespace DialcronWinforms.Controls;

public partial class ClienteUC : UserControl
{
    private readonly BindingList<Cliente> _clientes = new();
    private Cliente? _selecionado;

    public ClienteUC()
    {
        InitializeComponent();

        dgvClientes.DataSource = _clientes;
        dgvClientes.SelectionChanged += DgvClientes_SelectionChanged;
        Load += OnClienteUCLoad;
    }

    private async void OnClienteUCLoad(object? sender, EventArgs e)
    {
        try
        {
            var dao = await CriarDaoAsync();
            var clientes = await dao.GetAllAsync();

            _clientes.Clear();
            foreach (var cliente in clientes)
                _clientes.Add(cliente);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Não foi possível carregar os clientes: {ex.Message}", "Clientes", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        LimparSelecao();
        LimparFormulario();
    }

    private static async Task<ClienteDAO> CriarDaoAsync()
    {
        return new ClienteDAO(await Database.Instance.InitializeAsync());
    }

    private void DgvClientes_SelectionChanged(object? sender, EventArgs e)
    {
        if (dgvClientes.CurrentRow?.DataBoundItem is not Cliente cliente)
            return;

        _selecionado = cliente;
        PreencherFormulario(cliente);
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
                var novo = new Cliente();
                PreencherModelo(novo);
                await dao.InsertAsync(novo);
                _clientes.Add(novo);
                _selecionado = novo;
                SelecionarNaGrid(novo);
            }
            else
            {
                PreencherModelo(_selecionado);
                await dao.UpdateAsync(_selecionado);
                dgvClientes.Refresh();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Não foi possível salvar o cliente: {ex.Message}", "Clientes", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private bool ValidarFormulario()
    {
        if (string.IsNullOrWhiteSpace(txtNome.Text))
        {
            Alertar("Informe o nome do cliente.", txtNome);
            return false;
        }

        if (FuncoesGerais.LerInteiro(txtDdd.Text) is not > 0)
        {
            Alertar("Informe o DDD do telefone.", txtDdd);
            return false;
        }

        if (FuncoesGerais.LerInteiro(txtTelefone.Text) is not > 0)
        {
            Alertar("Informe o telefone.", txtTelefone);
            return false;
        }

        if (!string.IsNullOrWhiteSpace(txtDtaNascimento.Text) &&
            !DateTime.TryParseExact(txtDtaNascimento.Text.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out _))
        {
            Alertar("Informe a data de nascimento no formato dd/mm/aaaa.", txtDtaNascimento);
            return false;
        }

        return true;
    }

    private static void Alertar(string mensagem, Control campo)
    {
        MessageBox.Show(mensagem, "Clientes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        campo.Focus();
    }

    private void LimparSelecao()
    {
        dgvClientes.ClearSelection();
        _selecionado = null;
    }

    private void SelecionarNaGrid(Cliente cliente)
    {
        foreach (DataGridViewRow row in dgvClientes.Rows)
        {
            if (row.DataBoundItem == cliente)
            {
                row.Selected = true;
                dgvClientes.CurrentCell = row.Cells[0];
                return;
            }
        }
    }

    private void PreencherFormulario(Cliente c)
    {
        txtNome.Text = c.Nome;
        txtDdd.Text = c.DddTelefone?.ToString() ?? string.Empty;
        txtTelefone.Text = c.Telefone?.ToString() ?? string.Empty;
        txtEmail.Text = c.Email;
        txtDtaNascimento.Text = c.DtaNascimento;
    }

    private void PreencherModelo(Cliente c)
    {
        c.Nome = txtNome.Text.Trim();
        c.DddTelefone = FuncoesGerais.LerInteiro(txtDdd.Text);
        c.Telefone = FuncoesGerais.LerInteiro(txtTelefone.Text);
        c.Email = string.IsNullOrWhiteSpace(txtEmail.Text) ? null : txtEmail.Text.Trim();
        c.DtaNascimento = string.IsNullOrWhiteSpace(txtDtaNascimento.Text) ? null : txtDtaNascimento.Text.Trim();
    }

    private void LimparFormulario()
    {
        foreach (Control ctrl in new Control[]
        {
            txtNome, txtDdd, txtTelefone, txtEmail, txtDtaNascimento
        })
        {
            ctrl.Text = string.Empty;
        }
    }
}
