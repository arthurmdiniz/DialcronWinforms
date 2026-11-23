# Relatório de Testes Unitários e Garantia de Qualidade (GQS)

Este documento registra as evidências de validação e garantia de qualidade de software do projeto **DialcronWinforms**, cumprindo os requisitos práticos da disciplina de Gestão e Qualidade de Software (GQS).

## 1. Ambiente e Ferramentas de Teste

Para garantir a confiabilidade e o isolamento das regras de negócio em relação à interface gráfica (Windows Forms), foi adotada a seguinte stack de testes:
* **Framework de Testes:** xUnit.net (v3.1.4)
* **Ambiente de Execução:** .NET 10.0 (Windows)
* **Mecanismo de Execução:** CLI do .NET (`dotnet test`)

---

## 2. Resumo da Execução dos Testes

Os testes unitários foram executados localmente via terminal para validar a integridade dos algoritmos desenvolvidos. O projeto passou com **100% de aproveitamento**.

* **Comando Executado:** `dotnet test DialcronWinforms.Tests/DialcronWinforms.Tests.csproj`
* **Total de Cenários Analisados:** 8
* **Testes com Sucesso (Passed):** 8
* **Testes Falhos (Failed):** 0
* **Testes Ignorados (Skipped):** 0
* **Tempo Total de Execução:** 5,3 segundos

---

## 3. Log Oficial de Saída do Console

```text
Restauração concluída (12,3s)
DialcronWinforms net10.0-windows êxito(s) com 1 aviso(s) (8,4s) -> bin\Debug\net10.0-windows\DialcronWinforms.dll
DialcronWinforms.Tests net10.0-windows êxito (3,8s) -> DialcronWinforms.Tests\bin\Debug\net10.0-windows\DialcronWinforms.Tests.dll
[xUnit.net 00:00:00.00] xUnit.net VSTest Adapter v3.1.4+50e68bbb8b (64-bit .NET 10.0.12)
[xUnit.net 00:00:01.46]   Discovering: DialcronWinforms.Tests
[xUnit.net 00:00:01.59]   Discovered:  DialcronWinforms.Tests
[xUnit.net 00:00:01.64]   Starting:    DialcronWinforms.Tests
[xUnit.net 00:00:02.92]   Finished:    DialcronWinforms.Tests
DialcronWinforms.Tests teste net10.0-windows êxito (5,5s)

Resumo do teste: total: 8; falhou: 0; bem-sucedido: 8; ignorado: 0; duração: 5,3s
Construir êxito(s) com 1 aviso(s) em 32,3s
```

---

## 4. Apontamentos de Garantia de Qualidade (Clean Code)

Como parte do processo de revisão de código e aderência aos padrões de **Código Limpo (Clean Code)** e **Tratamento de Erros**, foi mapeado um alerta emitido pelo compilador durante a execução da suite de testes:

* **Alerta Identificado:** `warning CS8618`
* **Arquivo:** `Models/Servico.cs` (Linha 25, Coluna 19)
* **Descrição:** A propriedade não anulável 'Tempo' precisa conter um valor não nulo ao sair do construtor.

### Recomendações de Refatoração para a Equipe:
Para mitigar riscos de `NullReferenceException` em tempo de execução e limpar os avisos de build do projeto, recomenda-se que a equipe de desenvolvimento aplique uma das seguintes soluções no modelo:
1. Declarar a propriedade como opcional/anulável: `public string? Tempo { get; set; }`
2. Tornar a propriedade obrigatória utilizando o modificador do C#: `public required string Tempo { get; set; }`
