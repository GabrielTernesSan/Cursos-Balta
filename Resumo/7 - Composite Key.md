## Composite Key

`````sql
USE [Curso]

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

-- DROP TABLE [Curso]

CREATE TABLE [Curso](
    [Id] INT NOT NULL,
    [Nome] NVARCHAR(80) NOT NULL,
    [CategoriaId] INT NOT NULL,
    
    -- Pode adicionar um nome a chave
    CONSTRAINT [PK_Curso] PRIMARY KEY([Id]),
    CONSTRAINT [FK_Curso_Categoria] FOREIGN KEY([CategoriaId])
        REFERENCES [Categoria]([Id])
) 

GO

CREATE TABLE [Categoria](
    [Id] INT NOT NULL,
    [Nome] NVARCHAR(80) NOT NULL,
    
    -- Pode adicionar um nome a chave
    CONSTRAINT [PK_Categoria] PRIMARY KEY([Id])
)

GO

-- DROP TABLE [ProgressoCurso]

CREATE TABLE [ProgressoCurso](
    [AlunoId] INT NOT NULL,
    [CursoId] INT NOT NULL,
    [Progresso] INT NOT NULL,
    [UltimaAtualizacao] DATETIME NOT NULL DEFAULT(GETDATE()),

    CONSTRAINT [PK_ProgressoCurso] PRIMARY KEY([AlunoId], [CursoId])
    
) 

GO
`````

