## Revisão de índices

### Qual a diferença entre clustered index e nonclustered index?

O índice *clusterizado* é quase um sinônimo de chave primária. De fato só pode usar um por tabela e tem que ser na ordem da inserção dos dados, o que obviamente exclui chaves primárias naturais. Em um índice assim a chave é a posição onde o dado está. Na verdade **ele é a própria tabela**.

A chave primária está obviamente em ordem, assim possibilitando a pesquisa binária que é muito importante para dar performance.

O índice não *clusterizado* são todos os outros índices onde você terá uma chave qualquer e um apontador para a tabela de dados. Então há sempre duas pesquisas, uma no índice *non-cluster* e depois sabendo qual a posição dele buscará o dado de fato na tabela, que até pode ser um índice *clusterizado*.

Um índice não *clusterizado* tem as chaves em ordem também e pode fazer pesquisa binária da mesma forma.