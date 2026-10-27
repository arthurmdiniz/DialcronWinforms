---
name: Front (Tela)
about: Criar ou ajustar uma tela do sistema
title: "Criar tela de "
labels: front
---

## Tipo

- [ ] Front (Tela)
- [ ] Back (DAO)
- [ ] Integração
- [ ] Outros
- [ ] Documentação

## Tela: [Nome da Tela]

[Descrição breve do que a tela deve fazer]

### Requisitos

- 

### Convenções do projeto

- Cores: usar `Cores.cs` (Primary, Secondary, Creme, etc.)
- Arquivo: `Controls/[NomeDaTela]UC.cs`
- Namespace: `DialcronWinforms.Controls`
- Herança: `UserControl`
- Controles: `_camelCase` com underscore

### Checklist

- [ ] Controls/[NomeDaTela]UC.cs criado
- [ ] Classe herda de UserControl
- [ ] Tela registrada no MainForm (botão do menu ou evento de um pai)
- [ ] Controles com _camelCase e underscore
- [ ] Eventos Click e Load implementados
- [ ] dotnet build sem erro
