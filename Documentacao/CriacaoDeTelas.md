# Como Criar uma Tela

Guia para criar telas no DialcronWinforms. O padrão do projeto é: **cada tela é um `UserControl`**, carregado dentro do painel de conteúdo do `MainForm`. Não abrimos novas janelas (`ShowDialog()` / `Show()`): a navegação troca o conteúdo do painel, e o menu lateral fica sempre visível.

Sem ViewModel: o code-behind chama os DAOs diretamente.

---

## 1. Como a navegação funciona

```
MainForm (janela fixa)
├── pnlBotoes      → menu lateral (logo, Agenda, Cadastros, Backup)
└── pnlConteudo    → recebe o UserControl ativo (NavigationHelper)
```

- `Controls/` guarda as telas (`AgendaUC`, `CadastrosUC`, `ClienteUC`, `ServicoUC`, `ProfissionalUC`, `UnidadeUC`).
- `Navigation/NavigationHelper.cs` troca o controle exibido em `pnlConteudo`.
- `Forms/MainForm.cs` decide qual tela abrir em cada clique e assina os eventos de navegação.
- Cada tela é criada uma única vez (`??=` ou no construtor do `MainForm`) e reutilizada.
- Não há botão "Voltar" nas telas: o usuário navega pelo menu lateral.

---

## 2. Onde ficam os arquivos

```
Controls/
├── AgendaUC.cs / .Designer.cs
├── CadastrosUC.cs / .Designer.cs
├── ClienteUC.cs / .Designer.cs
├── ServicoUC.cs / .Designer.cs
├── ProfissionalUC.cs / .Designer.cs
└── UnidadeUC.cs / .Designer.cs

Forms/
└── MainForm.cs / .Designer.cs     # único Form do projeto

Navigation/
└── NavigationHelper.cs
```

Padrões de nomenclatura:

| Item | Padrão | Exemplo |
|------|--------|---------|
| Arquivo | `{Feature}UC.cs` | `ClienteUC.cs` |
| Classe | `public partial class {Feature}UC : UserControl` | `ClienteUC` |
| Namespace | `DialcronWinforms.Controls` | `namespace DialcronWinforms.Controls;` |
| Campo do MainForm | `_{feature}UC` | `_clienteUC` |
| Evento de navegação | `{Opcoes}Clicked` | `ClientesClicked` |

---

## 3. Passo a passo para criar uma tela

### Passo 1 - Criar o UserControl

No Visual Studio: **Add → User Control** em `Controls/`, com o nome `MinhaTelaUC.cs`. O Visual Studio cria o `.cs` e o `.Designer.cs`.

Pelo Designer, adicione os controles e configure as propriedades (`Name`, `Text`, `BackColor`, `Font` etc.). Para ligar um evento: selecione o controle, clique no ícone de raio na janela Properties e dê duplo clique no evento.

> **Importante**: o `.Designer.cs` é gerado pelo Visual Studio. Use o Designer para alterar controles. Se editar à mão, mantenha o estilo do arquivo existente.

### Passo 2 - Ajustar o UserControl ao painel

Toda tela deve preencher o painel de conteúdo. No `InitializeComponent` (ou nas propriedades do Designer):

```csharp
this.Dock = DockStyle.Fill;
this.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
this.Padding = new Padding(20);
this.AutoScroll = true;
this.BackColor = Cores.Creme;
this.ForeColor = Cores.Gray900;
```

> `UserControl` não tem `StartPosition`, `Text` como janela nem `ClientSize` de janela. Não use essas propriedades em telas.

### Passo 3 - Estilizar com a paleta

Cores sempre via `Cores.*` (ver `Cores.cs`). Botões seguem o padrão da barra lateral:

```csharp
private void ConfigurarBotao(Button btn)
{
    btn.BackColor = Cores.Primary;
    btn.ForeColor = Cores.White;
    btn.FlatStyle = FlatStyle.Flat;
    btn.FlatAppearance.BorderSize = 0;
    btn.FlatAppearance.MouseOverBackColor = Cores.Tertiary;
    btn.FlatAppearance.MouseDownBackColor = Cores.Primary;
    btn.Font = new Font("Segoe UI", 11);
}
```

Chame `ConfigurarBotao(...)` no `InitializeComponent` de cada botão.

> Se o Designer regenerar o arquivo e as chamadas sumirem, as cores dos botões voltam ao padrão do sistema. Confira depois de editar pelo Designer.

### Passo 4 - Registrar a tela no MainForm

Se a tela é aberta por um botão do menu lateral, a regra fica no `MainForm`. Exemplo com a Agenda:

```csharp
private AgendaUC? _agendaUC;

private void BtnAgenda_Click(object? sender, EventArgs e)
{
    _agendaUC ??= new AgendaUC();
    NavigationHelper.NavigateTo(_agendaUC);
}
```

Se a tela é aberta a partir de outra tela (como os cadastros, dentro de `CadastrosUC`), a `UserControl` pai expõe um evento e o `MainForm` assina no construtor, **uma única vez**:

```csharp
// CadastrosUC.cs
public event EventHandler? ClientesClicked;

private void BtnClientes_Click(object? sender, EventArgs e) => ClientesClicked?.Invoke(this, e);
```

```csharp
// MainForm.cs - construtor
_cadastrosUC = new CadastrosUC();
_cadastrosUC.ClientesClicked += (s, e) => NavigateToCliente();

private void NavigateToCliente()
{
    _clienteUC ??= new ClienteUC();
    NavigationHelper.NavigateTo(_clienteUC);
}
```

> Não assine eventos dentro do clique do botão: a cada clique o handler seria adicionado de novo.

### Passo 5 - Se a tela precisa do banco

O singleton `Database` entrega a `SQLiteAsyncConnection`. Cada DAO é criado com ela no construtor. Carregue os dados no evento `Load` da tela (ou ao ser exibida), não no construtor:

```csharp
using DialcronWinforms.Data;

private async void OnMinhaTelaLoad(object? sender, EventArgs e)
{
    try
    {
        var dao = new MeuDAO(await Database.Instance.InitializeAsync());
        _grid.DataSource = await dao.GetAllAsync();
    }
    catch (Exception ex)
    {
        MessageBox.Show($"Não foi possível carregar: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
}
```

Como `Database.InitializeAsync()` é idempotente, pode ser chamado em qualquer tela. Referência real: `Data/DAO/BackupDAO.cs`.

> Como a tela é reutilizada, o `Load` dispara uma vez. Para recarregar a cada exibição, chame o carregamento dentro do próprio método que a exibe (por exemplo, em `BtnAgenda_Click` antes de `NavigateTo`), ou crie um método público `Recarregar()` na tela.

### Passo 6 - Compilar

```bash
dotnet build
```

---

## 4. Exemplo 1 - Tela com botões

### `Controls/CadastrosUC.cs`

```csharp
namespace DialcronWinforms.Controls;

public partial class CadastrosUC : UserControl
{
    public event EventHandler? ClientesClicked;
    public event EventHandler? ServicosClicked;

    public CadastrosUC()
    {
        InitializeComponent();

        btnClientes.Click += (s, e) => ClientesClicked?.Invoke(this, e);
        btnServicos.Click += (s, e) => ServicosClicked?.Invoke(this, e);
    }
}
```

### `Controls/CadastrosUC.Designer.cs` (trecho)

```csharp
private void InitializeComponent()
{
    this.btnClientes = new Button();
    this.btnServicos = new Button();
    this.SuspendLayout();

    this.btnClientes.Text = "Clientes";
    this.btnClientes.Size = new Size(190, 42);
    this.btnClientes.Location = new Point(20, 20);
    this.btnClientes.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
    this.ConfigurarBotao(this.btnClientes);

    this.btnServicos.Text = "Serviços";
    this.btnServicos.Size = new Size(190, 42);
    this.btnServicos.Location = new Point(20, 72);
    this.btnServicos.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
    this.ConfigurarBotao(this.btnServicos);

    this.Dock = DockStyle.Fill;
    this.BackColor = Cores.Creme;
    this.Controls.Add(this.btnClientes);
    this.Controls.Add(this.btnServicos);
    this.ResumeLayout(false);
    this.PerformLayout();
}
```

---

## 5. Exemplo 2 - Tela de listagem (DataGridView)

### `Controls/ClienteUC.cs`

```csharp
using DialcronWinforms.Data;

namespace DialcronWinforms.Controls;

public partial class ClienteUC : UserControl
{
    public ClienteUC()
    {
        InitializeComponent();

        Load += OnClienteUCLoad;
    }

    private async void OnClienteUCLoad(object? sender, EventArgs e)
    {
        try
        {
            var dao = new ClienteDAO(await Database.Instance.InitializeAsync());
            _grid.DataSource = await dao.GetAllAsync();
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Não foi possível carregar: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
```

> `ClienteDAO` é um exemplo. Os DAOs seguem o padrão de `BackupDAO`.

### DAO de referência

```csharp
using SQLite;

namespace DialcronWinforms.Data.DAO;

public class ClienteDAO
{
    private readonly SQLiteAsyncConnection _connection;

    public ClienteDAO(SQLiteAsyncConnection connection)
    {
        _connection = connection;
    }

    public Task<List<Cliente>> GetAllAsync()
    {
        return _connection.Table<Cliente>().ToListAsync();
    }
}
```

> **Estado atual**: os models (`Models/`) estão prontos. Os DAOs além do `BackupDAO` ainda precisam ser criados.

---

## 6. Convenções do projeto

### Código C# (code-behind)

- Indentação com **4 espaços** nos arquivos `.cs` e `.Designer.cs`
- Namespace no formato `namespace DialcronWinforms.Controls;`
- Eventos: `private void OnXxxClicked(object? sender, EventArgs e)`
- Campos privados com prefixo `_`
- `async/await` em qualquer operação com banco
- Sem ViewModel: o code-behind chama o DAO diretamente
- Sem comentários desnecessários e sem emojis

### Layout e visual

- Toda tela: `Dock = DockStyle.Fill`, `BackColor = Cores.Creme`, `ForeColor = Cores.Gray900`
- Títulos: `Cores.Primary`, fonte Segoe UI em negrito
- Textos secundários: `Cores.Gray600`
- Botões: `ConfigurarBotao` (ver Passo 3)
- Cores sempre via `Cores.*`; nunca valor fixo como `Color.FromArgb(...)`
- Logo e ícones ficam em `Resources/` (`Icones/`, `Logos/`)

### Banco

- Todo acesso passa por um DAO em `Data/DAO/` (nenhum SQL na tela)
- Cada DAO recebe `SQLiteAsyncConnection` via construtor
- Obter a conexão com `Database.Instance.InitializeAsync()`

---

## 7. Checklist antes de commitar

```
[ ] UserControl criado em Controls/{Feature}UC.cs
[ ] Dock = Fill, BackColor = Cores.Creme, AutoScroll = true
[ ] Botões com ConfigurarBotao (cores da paleta)
[ ] Cores via Cores.* (nenhum valor fixo)
[ ] Tela registrada no MainForm (botão do menu ou evento de um pai)
[ ] Eventos de navegação assinados uma única vez (construtor)
[ ] Acesso a dados via DAO (nenhum SQL na tela)
[ ] dotnet build sem erro
```

---

## 8. Erros comuns

| Erro | Causa | Solução |
|------|-------|---------|
| Tela não aparece no painel | Não chamou `NavigationHelper.NavigateTo` | Chame no clique do botão ou no handler do evento |
| Tela ocupa só parte do painel | Falta `Dock = DockStyle.Fill` | Defina no `InitializeComponent` |
| Botões com cor padrão do Windows | `ConfigurarBotao` não foi chamado (ou sumiu após editar o Designer) | Chame `ConfigurarBotao(btn)` para cada botão |
| Clique abre a tela várias vezes e eventos repetem | Evento assinado dentro do clique | Assine no construtor do `MainForm` |
| `StartPosition` não existe no UserControl | Propriedade de `Form` | Remova; a tela é preenchida pelo painel |
| `SQLiteConnection` nulo | DAO criado sem `InitializeAsync()` | `new MeuDAO(await Database.Instance.InitializeAsync())` |
| Tela abre vazia | Dados carregados no construtor | Carregue no `Load` ou no método que exibe a tela |
| Cor fora da paleta | Valor fixo no código | Use `Cores.Classe` do `Cores.cs` |
