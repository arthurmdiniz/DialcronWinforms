# DialcronWinforms

Aplicativo desktop para gestão de agendamentos de salão de beleza, desenvolvido em C# com Windows Forms no .NET 10.

## Visão geral

O projeto centraliza o fluxo de agendamento, cadastro de clientes, serviços, profissionais, unidades e controle de agenda em uma interface desktop Windows. A persistência é feita em SQLite e a base de dados pode ser gerada automaticamente ao primeiro uso, com um arquivo seed incluído no repositório.

## Stack tecnológica

| Componente | Tecnologia |
|------------|------------|
| Framework | Windows Forms (.NET 10) |
| Linguagem | C# |
| Persistência | SQLite |
| ORM / acesso | sqlite-net-pcl |
| Arquitetura | Code-behind + DAO |
| Testes | xUnit |

## Como começar

1. Configure o ambiente seguindo o guia em [SETUP.md](SETUP.md)
2. Consulte a documentação de telas em [Documentacao/CriacaoDeTelas.md](Documentacao/CriacaoDeTelas.md)
3. Veja os documentos adicionais em [Documentacao/](Documentacao/)

## Estrutura do projeto

```text
DialcronWinforms/
├── Controls/                  # UserControls da interface
├── Data/                     # Conexão e DAOs
│   └── DAO/
├── Forms/                    # Form principal e janelas do sistema
├── Models/                   # Entidades do domínio
├── Navigation/               # Navegação entre telas
├── Resources/                # Ícones, logos e assets
├── DialcronWinforms.Tests/   # Projeto de testes automatizados
├── Documentacao/             # Documentação e referências
├── Cores.cs                  # Paleta visual do sistema
├── Program.cs                # Inicialização da aplicação
├── README.md                 # Visão geral do projeto
├── SETUP.md                  # Guia de configuração local
├── Relatório_de_Testes.md    # Evidência de execução de testes
├── DialcronWinforms.csproj
├── DialcronWinforms.sln
├── LICENSE
└── .gitignore
```

## Funcionalidades principais

- Cadastro de clientes
- Cadastro de serviços
- Cadastro de profissionais
- Cadastro de unidades
- Agenda / agendamento visual
- Backup e restauração do banco de dados
- Navegação por menu lateral e `UserControl`

## Paleta de cores

A identidade visual é definida em `Cores.cs`:

| Chave | Cor (HEX) | Finalidade |
|-------|-----------|------------|
| Primary | `#8E3B52` | cor principal |
| Secondary | `#F5E8E5` | cor secundária |
| Tertiary | `#C77C8A` | destaques |
| Creme | `#FFF8F5` | fundo claro |
| Sucesso | `#72A68A` | estados positivos |
| Atencao | `#D6A84F` | alertas |
| Erro | `#C95C62` | erros |

## Banco de dados

- Banco: SQLite
- Estrutura: tabela principal com entidades do domínio (`cad_*` e `bel_*`)
- Seed incluído: `Documentacao/DialcronSB_PADRAO.db`
- Banco de trabalho: gerado automaticamente no primeiro uso
- Backup: botão na tela principal para exportação/restore do banco

## Testes

O projeto inclui testes automatizados em `DialcronWinforms.Tests`.

```bash
dotnet test --nologo
```

## Licença

Consulte [LICENSE](LICENSE).
