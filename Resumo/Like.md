## LIKE

````sql
SELECT TOP 100
   *
FROM    
    [Curso]
WHERE   
    [Nome] LIKE 'Fundamentos' -- Não vai funcionar
    [Nome] LIKE '%Fundamentos' -- Termina com "Fundamentos"
    [Nome] LIKE 'Fundamentos%' -- Começa com "Fundamentos"
    [Nome] LIKE '%Fundamentos%' -- Contém "Fundamentos"
````

