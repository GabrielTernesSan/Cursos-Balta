## Delete

````sql
-- Não vai funcionar porque definimos a tabela "Categoria" como chave estrangeira em "Cursos"
-- Para isso que serve os "CONSTRAINTS"
DELETE FROM 
    [Categoria]
WHERE
    [Id] = 4
````

````sql
-- Se quiser mesmo excluir essa categoria tem que excluir os cursos relacionados a ela
DELETE FROM 
    [Curso]
WHERE
    [CategoriaId] = 4
````

