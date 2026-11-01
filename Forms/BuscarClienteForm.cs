using System.Diagnostics.CodeAnalysis;
using DialcronWinforms.Models;

namespace DialcronWinforms.Forms;

[ExcludeFromCodeCoverage]
public class BuscarClienteForm : Form
{
    private readonly List<Cliente> _clientes;
    private readonly Label lblFiltro = new();
    private readonly TextBox txtFiltro = new();
    private readonly DataGridView dgvClientes = new();
    private readonly Button btnSelecionar = new();
    private readonly Button btnCancelar = new();

    public Cliente? ClienteSelecionado { get; private set; }

    public BuscarClienteForm(IEnumerable<Cliente> clientes)
    {
        _clientes = clientes.ToList();

        Text = "Buscar cliente";
        ClientSize = new Size(560, 440);
        MinimumSize = new Size(420, 320);
        StartPosition = FormStartPosition.CenterParent;
        FormBorderStyle = FormBorderStyle.Sizable;
        ShowInTaskbar = false;
        MaximizeBox = false;
        MinimizeBox = false;
        BackColor = Cores.White;
        Font = new Font("Segoe UI", 9F);

        lblFiltro.AutoSize = true;
        lblFiltro.Location = new Point(12, 12);
        lblFiltro.ForeColor = Cores.PrimaryDarkText;
        lblFiltro.Text = "Nome ou telefone";

        txtFiltro.Location = new Point(12, 32);
        txtFiltro.Size = new Size(536, 23);
        txtFiltro.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        txtFiltro.TextChanged += (_, _) => Filtrar();

        dgvClientes.Location = new Point(12, 64);
        dgvClientes.Size = new Size(536, 325);
        dgvClientes.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
        dgvClientes.AllowUserToAddRows = false;
        dgvClientes.AllowUserToDeleteRows = false;
        dgvClientes.AutoGenerateColumns = false;
        dgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        dgvClientes.BackgroundColor = Cores.White;
        dgvClientes.BorderStyle = BorderStyle.None;
        dgvClientes.MultiSelect = false;
        dgvClientes.ReadOnly = true;
        dgvClientes.RowHeadersVisible = false;
        dgvClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        dgvClientes.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = nameof(ClienteItem.Nome), HeaderText = "Nome", FillWeight = 50F });
        dgvClientes.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = nameof(ClienteItem.Telefone), HeaderText = "Telefone", FillWeight = 25F });
        dgvClientes.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = nameof(ClienteItem.Email), HeaderText = "E-mail", FillWeight = 25F });
        dgvClientes.CellDoubleClick += (_, e) =>
        {
            if (e.RowIndex >= 0)
                Confirmar();
        };

        btnSelecionar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        btnSelecionar.BackColor = Cores.Primary;
        btnSelecionar.FlatStyle = FlatStyle.Flat;
        btnSelecionar.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
        btnSelecionar.ForeColor = Cores.White;
        btnSelecionar.Location = new Point(348, 400);
        btnSelecionar.Size = new Size(96, 30);
        btnSelecionar.Text = "Selecionar";
        btnSelecionar.UseVisualStyleBackColor = false;
        btnSelecionar.Click += (_, _) => Confirmar();

        btnCancelar.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
        btnCancelar.BackColor = Cores.Secondary;
        btnCancelar.FlatStyle = FlatStyle.Flat;
        btnCancelar.ForeColor = Cores.PrimaryDarkText;
        btnCancelar.Location = new Point(452, 400);
        btnCancelar.Size = new Size(96, 30);
        btnCancelar.Text = "Cancelar";
        btnCancelar.UseVisualStyleBackColor = false;
        btnCancelar.DialogResult = DialogResult.Cancel;

        AcceptButton = btnSelecionar;
        CancelButton = btnCancelar;

        Controls.Add(lblFiltro);
        Controls.Add(txtFiltro);
        Controls.Add(dgvClientes);
        Controls.Add(btnSelecionar);
        Controls.Add(btnCancelar);

        Filtrar();
    }

    private void Filtrar()
    {
        var termo = txtFiltro.Text.Trim();
        var digitos = FuncoesGerais.OnlyDigits(termo);

        var filtrados = _clientes
            .Where(c => termo.Length == 0
                || (c.Nome?.Contains(termo, StringComparison.OrdinalIgnoreCase) ?? false)
                || (digitos.Length > 0 && TelefoneDigitos(c).Contains(digitos)))
            .Select(c => new ClienteItem(c))
            .ToList();

        dgvClientes.DataSource = filtrados;
    }

    private void Confirmar()
    {
        if (dgvClientes.CurrentRow?.DataBoundItem is not ClienteItem item)
            return;

        ClienteSelecionado = item.Cliente;
        DialogResult = DialogResult.OK;
    }

    private static string TelefoneDigitos(Cliente c)
    {
        return (c.DddTelefone?.ToString() ?? string.Empty) + (c.Telefone?.ToString() ?? string.Empty);
    }

    private sealed class ClienteItem
    {
        public ClienteItem(Cliente cliente)
        {
            Cliente = cliente;
        }

        public Cliente Cliente { get; }

        public string Nome => Cliente.Nome ?? string.Empty;

        public string Telefone => Cliente.Telefone is null
            ? string.Empty
            : $"({Cliente.DddTelefone}) {Cliente.Telefone}";

        public string Email => Cliente.Email ?? string.Empty;
    }
}
