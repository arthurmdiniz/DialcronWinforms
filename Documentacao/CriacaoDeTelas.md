# Como Criar uma Tela

Guia passo a passo para criar telas (Forms) no DialcronWinforms, seguindo o padrao do projeto: **code-behind, sem ViewModel**, com o code-behind chamando os DAOs direto.

---

## 1. Onde ficam as telas

Todas as telas ficam em `Forms/`:

```
Forms/
├── MainForm.cs          # Tela principal (menu)
├── CadastrosForm.cs      # Menu de cadastros
├── ClienteForm.cs        # Cadastro de clientes
├── ServicoForm.cs        # Cadastro de servicos
├── ProfissionalForm.cs   # Cadastro de profissionais
├── UnidadeForm.cs        # Cadastro de unidades
└── AgendaForm.cs         # Agenda de atendimentos
```

Padroes de nomenclatura:

| Item | Padrao | Exemplo |
|------|--------|---------|
| Arquivo | `{Feature}Form.cs` | `ClienteForm.cs` |
| Classe | `partial class {Feature}Form : Form` | `ClienteForm` |
| Namespace | `DialcronWinforms.Forms` | `namespace DialcronWinforms.Forms;` |
| Controles | `_camelCase` com underscore | `_txtNome`, `_btnSalvar` |

---

## 2. Passo a passo

### Passo 1 - Criar o arquivo

Em `Forms/`, crie o arquivo da nova tela:

- `MinhaTelaForm.cs`

### Passo 2 - Criar o Designer no Visual Studio

O Visual Studio pode gerar o arquivo `.Designer.cs` automaticamente com os controles visuais. Para isso:

1. No **Solution Explorer**, clique com o botão direito no projeto
2. Selecione **Add** → **Windows Form**
3. Nomeie o arquivo como `MinhaTelaForm.cs` (o Visual Studio cria o `.cs` e o `.Designer.cs` juntos)
4. No **Designer** (tela visual), arraste controles da **Toolbox** (Labels, TextBoxes, Buttons, DataGridView, etc.)
5. Na janela **Properties** (F4), configure `Name`, `Text`, `Size`, `Location`, `BackColor`, etc.
6. Para conectar eventos: selecione o controle → na janela Properties clique no ícone de raio (Events) → duplo-clique no evento (ex: `Click`) para gerar o handler

O Visual Studio gera automaticamente no `.Designer.cs`:

```csharp
partial class MinhaTelaForm
{
    private System.ComponentModel.IContainer components = null;

    private Label lblTitulo;
    private Button btnSalvar;

    protected override void Dispose(bool disposing) { ... }

    private void InitializeComponent()
    {
        this.lblTitulo = new Label();
        this.btnSalvar = new Button();
        // ... configuracoes dos controles
        this.Controls.Add(this.lblTitulo);
        this.Controls.Add(this.btnSalvar);
    }
}
```

> **Importante**: O `.Designer.cs` e gerado pelo Visual Studio. Nao edite manualmente — use a interface visual (Designer) para adicionar, remover ou modificar controles. A logica de negocio fica no `.cs` (code-behind).
>
> **Pre-requisito**: O projeto deve abrir corretamente no Visual Studio. Se as telas nao abrirem no Designer, verifique se os eventos `Click` estao conectados no `.cs` (code-behind) — sem eles, os botoes abrem mas nao executam nenhuma acao.

### Passo 4 - Estrutura basica (opcional, se nao usar o Designer)

```csharp
namespace DialcronWinforms.Forms;

public class MinhaTelaForm : Form
{
    public MinhaTelaForm()
    {
        Text = "Minha Tela";
        Size = new Size(600, 450);
        StartPosition = FormStartPosition.CenterScreen;
        BackColor = Cores.Creme;
    }
}
```

### Passo 5 - Adicionar controles manualmente

```csharp
public MinhaTelaForm()
{
    Text = "Minha Tela";
    Size = new Size(600, 450);
    StartPosition = FormStartPosition.CenterScreen;
    BackColor = Cores.Creme;

    var lblTitulo = new Label
    {
        Text = "Minha Tela",
        Font = new Font("Segoe UI", 18, FontStyle.Bold),
        ForeColor = Cores.Primary,
        AutoSize = true,
        Location = new Point(20, 20)
    };

    var btnSalvar = new Button
    {
        Text = "Salvar",
        Size = new Size(100, 35),
        Location = new Point(20, 80),
        BackColor = Cores.Primary,
        ForeColor = Cores.White,
        FlatStyle = FlatStyle.Flat
    };
    btnSalvar.FlatAppearance.BorderSize = 0;
    btnSalvar.Click += OnSalvarClicked;

    Controls.Add(lblTitulo);
    Controls.Add(btnSalvar);
}

private void OnSalvarClicked(object? sender, EventArgs e)
{
    // Logica do botao
}
```

### Passo 6 - Se a tela precisa do banco

O singleton `Database` entrega a `SQLiteAsyncConnection`; cada DAO e criado com ela no construtor:

```csharp
using DialcronWinforms.Data;

private async void MinhaTelaForm_Load(object? sender, EventArgs e)
{
    try
    {
        var dao = new MeuDAO(await Database.Instance.InitializeAsync());
        var registros = await dao.GetAllAsync();

        // Preencher DataGridView ou outros controles
    }
    catch (Exception ex)
    {
        MessageBox.Show($"Nao foi possivel carregar: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}
```

Como `Database.InitializeAsync()` e idempotente, pode chamar em qualquer tela. Exemplo real: `Data/DAO/BackupDAO.cs`.

### Passo 7 - Compilar

```bash
dotnet build
```

---

## 3. Exemplo 1 - Tela simples (menu de botoes)

### `Forms/MinhaTelaForm.cs`

```csharp
namespace DialcronWinforms.Forms;

public class MinhaTelaForm : Form
{
    public MinhaTelaForm()
    {
        Text = "Minha Tela";
        Size = new Size(400, 350);
        StartPosition = FormStartPosition.CenterScreen;
        BackColor = Cores.Creme;

        var lblTitulo = new Label
        {
            Text = "Minha Tela",
            Font = new Font("Segoe UI", 20, FontStyle.Bold),
            ForeColor = Cores.Primary,
            AutoSize = true,
            Location = new Point(120, 30)
        };

        var btnOpcaoUm = new Button
        {
            Text = "Opcao 1",
            Size = new Size(200, 40),
            Location = new Point(100, 90),
            BackColor = Cores.Primary,
            ForeColor = Cores.White,
            FlatStyle = FlatStyle.Flat,
            Font = new Font("Segoe UI", 11)
        };
        btnOpcaoUm.FlatAppearance.BorderSize = 0;
        btnOpcaoUm.Click += OnOpcaoUmClicked;

        var btnOpcaoDois = new Button
        {
            Text = "Opcao 2",
            Size = new Size(200, 40),
            Location = new Point(100, 145),
            BackColor = Cores.Primary,
            ForeColor = Cores.White,
            FlatStyle = FlatStyle.Flat,
            Font = new Font("Segoe UI", 11)
        };
        btnOpcaoDois.FlatAppearance.BorderSize = 0;
        btnOpcaoDois.Click += OnOpcaoDoisClicked;

        var btnVoltar = new Button
        {
            Text = "Voltar",
            Size = new Size(100, 35),
            Location = new Point(150, 220),
            BackColor = Cores.Gray200,
            ForeColor = Cores.Gray900,
            FlatStyle = FlatStyle.Flat,
            Font = new Font("Segoe UI", 10)
        };
        btnVoltar.FlatAppearance.BorderSize = 0;
        btnVoltar.Click += OnVoltarClicked;

        Controls.Add(lblTitulo);
        Controls.Add(btnOpcaoUm);
        Controls.Add(btnOpcaoDois);
        Controls.Add(btnVoltar);
    }

    private void OnOpcaoUmClicked(object? sender, EventArgs e)
    {
        // Navegar para outra tela
    }

    private void OnOpcaoDoisClicked(object? sender, EventArgs e)
    {
        // Navegar para outra tela
    }

    private void OnVoltarClicked(object? sender, EventArgs e)
    {
        Close();
    }
}
```

---

## 4. Exemplo 2 - Tela de listagem (DataGridView)

Lista carregada do banco, com busca e DataGridView.

### `Forms/ListaForm.cs`

```csharp
using DialcronWinforms.Data;

namespace DialcronWinforms.Forms;

public class ListaForm : Form
{
    private readonly DataGridView _grid = new();
    private readonly TextBox _txtBusca = new();

    public ListaForm()
    {
        Text = "Lista";
        Size = new Size(800, 500);
        StartPosition = FormStartPosition.CenterScreen;
        BackColor = Cores.Creme;

        var lblTitulo = new Label
        {
            Text = "Lista",
            Font = new Font("Segoe UI", 18, FontStyle.Bold),
            ForeColor = Cores.Primary,
            AutoSize = true,
            Location = new Point(20, 20)
        };

        _txtBusca.Location = new Point(20, 60);
        _txtBusca.Size = new Size(300, 25);
        _txtBusca.PlaceholderText = "Buscar...";
        _txtBusca.TextChanged += OnBuscaTextChanged;

        _grid.Location = new Point(20, 100);
        _grid.Size = new Size(740, 320);
        _grid.ReadOnly = true;
        _grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        _grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        _grid.BackgroundColor = Cores.White;
        _grid.BorderStyle = BorderStyle.None;

        var btnVoltar = new Button
        {
            Text = "Voltar",
            Size = new Size(100, 35),
            Location = new Point(20, 430),
            BackColor = Cores.Gray200,
            ForeColor = Cores.Gray900,
            FlatStyle = FlatStyle.Flat
        };
        btnVoltar.FlatAppearance.BorderSize = 0;
        btnVoltar.Click += (s, e) => Close();

        Controls.Add(lblTitulo);
        Controls.Add(_txtBusca);
        Controls.Add(_grid);
        Controls.Add(btnVoltar);

        Load += OnFormLoad;
    }

    private async void OnFormLoad(object? sender, EventArgs e)
    {
        try
        {
            var dao = new MeuDAO(await Database.Instance.InitializeAsync());
            var registros = await dao.GetAllAsync();

            _grid.DataSource = registros;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Nao foi possivel carregar: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void OnBuscaTextChanged(object? sender, EventArgs e)
    {
        // Filtrar registros pelo texto da busca
    }
}
```

> `OnFormLoad` e `async void` porque o evento nao permite `async Task`. Carregue dados sempre nele (e nao no construtor), para a lista recarregar toda vez que a tela aparece.

> No Exemplo 2, `MeuModel` representa a classe de dominio. Use os models de `Models/` diretamente.

> **Nota sobre o Exemplo 2**: Se usar o Designer do Visual Studio (Passo 2), os controles `_grid` e `_txtBusca` serao declarados no `.Designer.cs` com nomes definidos na janela Properties. Ajuste o nome das variaveis no codigo conforme definido no Designer.

---

## 5. Exemplo 3 - Tela com acesso ao banco

### `Forms/ListaForm.cs` (trecho do DAO)

```csharp
using DialcronWinforms.Data;

private async void OnFormLoad(object? sender, EventArgs e)
{
    var dao = new MeuDAO(await Database.Instance.InitializeAsync());

    _grid.DataSource = await dao.GetAllAsync();
}
```

O DAO segue o padrao do projeto: recebe a `SQLiteAsyncConnection` no construtor e expoe metodos `async`. Referencia real: `Data/DAO/BackupDAO.cs`.

```csharp
using SQLite;

namespace DialcronWinforms.Data.DAO;

public class MeuDAO
{
    private readonly SQLiteAsyncConnection _connection;

    public MeuDAO(SQLiteAsyncConnection connection)
    {
        _connection = connection;
    }

    public Task<List<MeuModel>> GetAllAsync()
    {
        return _connection.Table<MeuModel>().ToListAsync();
    }
}
```

> **Estado atual**: os models (`Models/`) estao prontos. Crie os DAOs para cada entidade seguindo o padrao acima.

---

## 6. Navegacao entre telas

Para abrir outra tela a partir de um botao:

```csharp
private void OnAbrirTelaClicked(object? sender, EventArgs e)
{
    var tela = new OutraTelaForm();
    tela.ShowDialog();  // Modal (bloqueia a tela atual)
    // ou
    tela.Show();        // Nao modal (permite alternar entre telas)
}
```

Para voltar:

```csharp
private void OnVoltarClicked(object? sender, EventArgs e)
{
    Close();  // Fecha a tela atual
}
```

---

## 7. Convencoes do projeto

### Codigo C# (code-behind)

- Indentacao com **tabs** (arquivos `.cs`)
- Namespace unico no formato `namespace DialcronWinforms.Forms;`
- Eventos: `private void OnXxxClicked(object? sender, EventArgs e)`
- Metodos e variaveis em **camelCase**; privados com prefixo `_` (`_txtNome`, `_btnSalvar`)
- `async/await` em qualquer operacao com banco
- Sem ViewModel: o code-behind chama o DAO direto
- **Sem comentarios** no codigo e **Sem emojis**

### Controles

- Indentacao com **4 espacos** (se houver designer)
- `Text` com acentuacao correta em textos visiveis
- Cores sempre via `Cores.Classe` (ver `Cores.cs`); nunca valor fixo
- `StartPosition = FormStartPosition.CenterScreen` em todas as telas
- `BackColor = Cores.Creme` como fundo padrao
- Botoes com `FlatStyle = FlatStyle.Flat` e `FlatAppearance.BorderSize = 0`

### Banco

- Todo acesso passa por um DAO em `Data/DAO/` (nenhum SQL na Form)
- Cada DAO recebe `SQLiteAsyncConnection` via construtor
- Chamar `Database.Instance.InitializeAsync()` para obter a conexao

---

## 8. Checklist antes de commitar

```
[ ] Arquivo em Forms/{Feature}Form.cs criado
[ ] Designer criado no Visual Studio (Add → Windows Form) ou controles adicionados manualmente
[ ] Classe herda de Form
[ ] Text, Size, StartPosition, BackColor configurados
[ ] Controles com _camelCase e underscore
[ ] Eventos com OnXxxClicked(object? sender, EventArgs e)
[ ] Acesso a dados via DAO (nenhum SQL na Form)
[ ] Cores via Cores.Classe (nenhum valor fixo)
[ ] dotnet build sem erro
```

---

## 9. Erros comuns

| Erro | Causa | Solucao |
|------|-------|---------|
| `Form` nao encontrado | Falta using | `using System.Windows.Forms;` (implicito com ImplicitUsings) |
| `Cores.Primary` nao encontrado | Falta using | `using DialcronWinforms;` ou reference a classe |
| `Database` nao encontrado | Falta using | `using DialcronWinforms.Data;` |
| `SQLiteConnection` nulo | DAO criado sem `InitializeAsync()` | `new MeuDAO(await Database.Instance.InitializeAsync())` |
| Tela abre em branco | Dados carregados no construtor | Carregue no evento `Load`, nao no construtor |
| Estetica quebrada | Valor de cor fixo no codigo | Use `Cores.Classe` do `Cores.cs` |
| Botao nao faz nada | Evento nao conectado | `btn.Click += OnXxxClicked;` |
