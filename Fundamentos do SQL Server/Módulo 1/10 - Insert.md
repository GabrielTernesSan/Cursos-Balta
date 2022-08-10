## Insert

````sql
INSERT INTO [Categoria]([Nome]) VALUES('Backend')
INSERT INTO [Categoria]([Nome]) VALUES('Frontend')
INSERT INTO [Categoria]([Nome]) VALUES('Mobile')

INSERT INTO [Curso]([Nome], [CategoriaId]) VALUES('Fundamentos de C#', 1)
INSERT INTO [Curso]([Nome], [CategoriaId]) VALUES('Fundamentos de OOP', 1)
INSERT INTO [Curso]([Nome], [CategoriaId]) VALUES('Fundamentos de Angular', 2)
INSERT INTO [Curso]([Nome], [CategoriaId]) VALUES('Fundamentos de Flutter', 3)

INSERT INTO [Curso] VALUES('Fundamentos de Rest', 3)
````

