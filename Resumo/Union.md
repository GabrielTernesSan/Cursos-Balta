## Union

````sql
SELECT TOP 10
 *
FROM    
    [Curso]

UNION

SELECT TOP 10
 *
FROM    
    [Categoria]

-- Não vai funcionar os campos tem que ter dados similares
````

```sql
SELECT TOP 10
  [Id],
  [Nome]
FROM    
    [Curso]

UNION

SELECT TOP 10
  [Id],
  [Nome]
FROM    
    [Categoria]
-- Retorna ambos agrupados
```

```sql
SELECT TOP 10
  [Id],
  [Nome]
FROM    
    [Curso]

UNION ALL -- Executa como se fosse um SELECT DISTINCT

SELECT TOP 10
  [Id],
  [Nome]
FROM    
    [Categoria]
-- Retorna ambos agrupados
```

