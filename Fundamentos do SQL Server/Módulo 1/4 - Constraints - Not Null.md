## Constraints - Not Null

````sql
USE [Curso]

DROP TABLE [Aluno]

CREATE TABLE [Aluno](
    [Id] INT NOT NULL,
    [Nome] NVARCHAR(80) NOT NULL,
    [Nascimento] DATETIME DEFAULT(GETDATE()),
    -- [Nascimento] DATETIME NULL,
    [Active] BIT DEFAULT(0),
)

GO -- Insere no banco / salvando

ALTER TABLE [Aluno]
    ALTER COLUMN [Active] BIT NOT NULL
````