## Constraints - Unique

````sql
USE [Curso]

CREATE TABLE [Aluno](
    -- Unique garante que um campo irá ser único
    [Id] INT NOT NULL UNIQUE,
    [Nome] NVARCHAR(80) NOT NULL,
    -- Muito usado para emails também
    [Email] NVARCHAR(180) NOT NULL UNIQUE,
    [Nascimento] DATETIME DEFAULT(GETDATE()),
    [Active] BIT DEFAULT(0),
)
````