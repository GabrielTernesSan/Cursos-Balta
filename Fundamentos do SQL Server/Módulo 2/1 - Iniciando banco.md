## Iniciando o banco

````sql
CREATE DATABASE [Balta]

GO

CREATE TABLE [Student](
    [Id] UNIQUEIDENTIFIER NOT NULL,
    [Name] NVARCHAR(120) NOT NULL,
    [Email] NVARCHAR(180) NOT NULL,
    [Document] NVARCHAR(20) NULL,
    [Phone] NVARCHAR(20) NULL,
    [Birthdate] DATETIME NULL,
    [CreateDate] DATETIME NOT NULL,
    CONSTRAINT [PK_Student] PRIMARY KEY ([Id])
);

GO
````

