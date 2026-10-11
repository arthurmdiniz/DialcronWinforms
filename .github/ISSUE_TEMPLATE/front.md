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
- Arquivo: `Forms/[NomeDaTela]Form.cs`
- Namespace: `DialcronWinforms.Forms`
- Controles: `_camelCase` com underscore

### Checklist

- [ ] Forms/[NomeDaTela]Form.cs criado
- [ ] Classe herda de Form
- [ ] Text, Size, StartPosition, BackColor configurados
- [ ] Controles com _camelCase e underscore
- [ ] Eventos Click e Load implementados
- [ ] dotnet build sem erro
