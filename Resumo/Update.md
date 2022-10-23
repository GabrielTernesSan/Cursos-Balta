## Update

`````sql
UPDATE 
    [Categoria] 
SET 
    [Nome] = 'Azure'
-- Jamais esquecer o "WHERE"
WHERE
    [Id] = 2
`````

`````sql
-- Inicia uma transação
BEGIN TRANSACTION
    UPDATE  
        [Categoria]
    SET 
        [Nome] = 'DevOps'
    WHERE   
        [Id] = 2
-- Desfaz a ação
ROLLBACK
`````

Para garantir o resultado realiza-se a ação e vê quantas linhas foram afetadas, se for as desejadas realiza a ação sem o `ROLLBACK` e substitui por `COMMIT`

````sql
-- Inicia uma transação
BEGIN TRANSACTION
    UPDATE  
        [Categoria]
    SET 
        [Nome] = 'DevOps'
    WHERE   
        [Id] = 2
-- Salva a ação
COMMIT
````

