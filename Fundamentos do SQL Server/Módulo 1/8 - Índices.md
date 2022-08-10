## Índices

````sql
USE [Curso]

DROP TABLE [Aluno]

CREATE TABLE [Aluno](
    [Id] INT NOT NULL,
    [Nome] NVARCHAR(80) NOT NULL,
    [Email] NVARCHAR(180) NOT NULL,
    [Nascimento] DATETIME DEFAULT(GETDATE()),
    [Active] BIT DEFAULT(0),
    
    -- Pode adicionar um nome a chave
    CONSTRAINT [PK_Aluno] PRIMARY KEY([Id]),
    -- Pode adicionar um nome a uma propriedade UNIQUE
    CONSTRAINT [UQ_Aluno_Email] UNIQUE([Email]),
) 

GO -- Insere no banco / salvando

-- Para pesquisas massivas (invisível)
CREATE INDEX [IX_Aluno_Email] ON [Aluno](Email)

-- Excluir index
DROP INDEX [IX_Aluno_Email] ON [Aluno]
````

