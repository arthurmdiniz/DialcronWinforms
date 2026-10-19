# Fluxo de Branches (GitFlow) e Versionamento

## Branches

| Branch | Função |
|---|---|
| `main` | Código em produção. Cada commit nela corresponde a uma versão publicada. |
| `develop` | Integração das funcionalidades já concluídas, para a próxima versão. |
| `feat/*` (ex.: `feat/DWF-42`) | Uma branch por issue. Sai de `develop` e volta para `develop` via PR. |
| `release/*` (ex.: `release/1.1.0`) | Preparação de uma versão: ajustes finais e versão no `.csproj`. Sai de `develop` e é mesclada em `main` e em `develop`. |
| `hotfix/*` (ex.: `hotfix/1.0.1`) | Correção urgente em produção. Sai de `main` e é mesclada em `main` e em `develop`. |

## Fluxo de uma funcionalidade

1. Criar a branch a partir de `develop`: `git switch -c feat/DWF-XX develop`
2. Desenvolver e commitar na branch da issue.
3. Abrir um Pull Request para `develop`.
4. Após aprovação, mesclar em `develop` e excluir a branch.

## Fluxo de uma release

1. `git switch -c release/X.Y.Z develop`
2. Atualizar a versão em `DialcronWinforms.csproj` (`<Version>`).
3. Mesclar em `main` e criar a tag `vX.Y.Z`.
4. Mesclar a mesma branch de volta em `develop`.

## Git Semântico (SemVer)

Versões no formato `MAJOR.MINOR.PATCH`:

- **MAJOR**: mudanças incompatíveis (ex.: alteração no esquema do banco sem migração).
- **MINOR**: novas funcionalidades compatíveis (ex.: nova tela).
- **PATCH**: correções compatíveis (ex.: ajuste de bug).

Tags seguem o padrão `vX.Y.Z`, por exemplo `v1.0.0`.

## Mensagens de commit

Usar o padrão Conventional Commits:

- `feat: ...` para nova funcionalidade
- `fix: ...` para correção de bug
- `docs: ...` para documentação
- `refactor: ...` para refatoração sem mudança de comportamento
- `test: ...` para testes
- `chore: ...` para tarefas de manutenção
