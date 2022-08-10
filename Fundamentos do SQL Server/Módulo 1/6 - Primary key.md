## Primary key

```sql
CREATE TABLE [Aluno](
    [Id] INT NOT NULL UNIQUE,
    [Nome] NVARCHAR(80) NOT NULL,
    [Email] NVARCHAR(180) NOT NULL UNIQUE,
    [Nascimento] DATETIME DEFAULT(GETDATE()),
    [Active] BIT DEFAULT(0),
    
    -- Temos uma maneira melhor de definir o ID, a PRIMARY KEY
    PRIMARY KEY([Id])
    -- Podemos ter PRIMARY KEY composta
    PRIMARY KEY([Id], [Email])
)

-- Se esqueceu de adicionar a PRIMARY KEY
ALTER TABLE [Aluno]
	ADD PRIMARY KEY([Id])
	
-- Pode dropar PRIMARY KEY
ALTER TABLE [Aluno]
	DROP CONSTRAINT [PK_Aluno_3214EC79079B0D3]
```

````sql
CREATE TABLE [Aluno](
    [Id] INT NOT NULL UNIQUE,
    [Nome] NVARCHAR(80) NOT NULL,
    [Email] NVARCHAR(180) NOT NULL,
    [Nascimento] DATETIME DEFAULT(GETDATE()),
    [Active] BIT DEFAULT(0),
    
    -- Pode adicionar um nome a chave
    CONSTRAINT [PK_Aluno] PRIMARY KEY([Id]),
    -- Pode adicionar um nome a uma propriedade UNIQUE
    CONSTRAINT [UQ_Aluno_Email] UNIQUE([Email]),
) 