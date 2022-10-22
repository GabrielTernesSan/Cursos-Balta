- [ ] Adicionar a propriedade `bool ativo` em `relatorio`

- [ ] Filtro de relatórios ativos nos endpoints dos usuários (parâmetro no repo, ag.Roles)

  ```c#
  public Task<IActionResult> obterRelatorios(bool isAdm = true)
  {
  }
  ```

- [ ] Alterar fluxo do relatório cadastrado

- [ ] Implementar fluxo com propriedade `ativo` e `ir para homologacao`

|   Ativo    | Homologação |                          Situação                           |
| :--------: | :---------: | :---------------------------------------------------------: |
| Verdadeiro |    Falso    |      Ativo para usuários, fora da lista de homologação      |
|   Falso    | Verdadeiro  | Somente na fila de homologação e não visível para o usuário |
|   Falso    |    Falso    |                Relatório rejeitado, excluido                |

> No cadastro necessita estar ativo ou na fila de homologação?

- [ ] Retirar Favoritar das movimentações
- [ ] Alterar mensagem das movimentações
- [ ] Adicionar tabela de relatórios rejeitados (Somente Admin)

## Dúvidas

- [x] No endpoint de novidades o response está sem data, como ordenar? pode ter

- [ ] Link de homologação e link de produção?