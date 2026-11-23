---
name: Back (DAO)
about: Criar ou ajustar um DAO do sistema
title: "Criar DAO de "
labels: back
---

## Tipo

- [ ] Front (Tela)
- [x] Back (DAO)
- [ ] Integração
- [ ] Outros
- [ ] Documentação

## DAO: [Nome da Entidade]

[Descrição breve do que o DAO deve fazer]

### Métodos

- GetAllAsync
- GetByIdAsync
- InsertAsync
- UpdateAsync
- DeleteAsync

### Convenções do projeto

- Arquivo: `Data/DAO/[Nome]DAO.cs`
- Namespace: `DialcronWinforms.Data.DAO`
- Recebe `SQLiteAsyncConnection` no construtor
- Usar `async/await` para todas as operações

### Checklist

- [ ] Data/DAO/[Nome]DAO.cs criado
- [ ] Recebe SQLiteAsyncConnection no construtor
- [ ] Todos os métodos implementados
- [ ] dotnet build sem erro
