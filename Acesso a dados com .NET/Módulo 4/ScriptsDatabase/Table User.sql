USE [Blog]

GO

CREATE TABLE [User] (
    [Id] INT NOT NULL IDENTITY(1, 1),
    [Name] NVARCHAR(80) NOT NULL, -- aceita caracteres especiais
    [Email] VARCHAR(200) NOT NULL,-- não aceita caracteres especiais
    [PasswordHash] VARCHAR(255) NOT NULL,
    [Bio] TEXT NOT NULL,
    [Image] VARCHAR(2000) NOT NULL,
    [Slug] VARCHAR(80) NOT NULL, -- balta.oi/users/gabriel

    CONSTRAINT [Pk_User] PRIMARY KEY([Id]),
    CONSTRAINT [UQ_User_Email] UNIQUE([Email]), -- Define que o email é único
    CONSTRAINT [UQ_User_Slug] UNIQUE([Slug]) -- Define que o slug é único
)

-- Para pesquisa
-- NONCLUSTERED -> 
CREATE NONCLUSTERED INDEX [IX_User_Email] ON [User]([Email])
CREATE NONCLUSTERED INDEX [IX_User_Slug] ON [User]([Slug])