## Alter/Drop Table

````sql
USE [Curso]

-- Adicionando uma coluna na tabela ALUNO
ALTER TABLE [Aluno]
    ADD [Document] NVARCHAR(11)
    
-- Remove uma coluna
ALTER TABLE [Aluno]
    DROP COLUMN [Documento]
    
-- Altera uma coluna
ALTER TABLE [Aluno]
    ALTER COLUMN [Document] CHAR(11)
````

