## Identity

`````sql
CREATE DATABASE [Cursos]
GO

USE [Cursos]

CREATE TABLE [Categoria] (
    -- Incrementa automático de 1 em 1
    [Id] INT NOT NULL IDENTITY(1, 1), 
    [Nome] NVARCHAR(80) NOT NULL,

    CONSTRAINT [PK_Categoria] PRIMARY KEY([Id])
)
GO

CREATE TABLE [Curso] (
    -- Incrementa automático de 1 em 1
    [Id] INT NOT NULL IDENTITY(1, 1), 
    [Nome] NVARCHAR(80) NOT NULL,
    [CategoriaId] INT NOT NULL,

    -- Pode adicionar um nome a chave
    CONSTRAINT [PK_Curso] PRIMARY KEY([Id]),
    CONSTRAINT [FK_Curso_Categoria] FOREIGN KEY([CategoriaId])
        REFERENCES [Categoria]([Id])
)
GO
`````

