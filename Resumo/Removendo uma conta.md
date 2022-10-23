## Removendo um conta

````sql
CREATE OR ALTER PROCEDURE spStudentProgress (
    @StudentId UNIQUEIDENTIFIER
)
AS
    SELECT 
        [Student].[Name] AS [Student],
        [Course].[Title] AS [Course],
        [StudentCourse].[Progress],
        -- Data da última atualização
        [StudentCourse].[LastUpdateDate]
    FROM
        [StudentCourse]
        INNER JOIN [Student] ON [StudentCourse].[StudentId] = [Student].[Id]
        INNER JOIN [Course] ON [StudentCourse].[CourseId] = [Course].[Id]
    WHERE
        [StudentCourse].[StudentId] = @StudentId
        AND [StudentCourse].[Progress] < 100
        AND [StudentCourse].[Progress] > 0
    ORDER BY
        [StudentCourse].[LastUpdateDate] DESC
````

````sql
EXEC spStudentProgress '79b82071-80a8-4e78-a79c-92c8cd1fd052'
````

```sql
-- Primeiro temos que excluir os registros do aluno da [StudentCourse] para depois excluir o aluno da tabela [Student]
DECLARE @StudentId UNIQUEIDENTIFIER = '79b82071-80a8-4e78-a79c-92c8cd1fd052'

BEGIN TRANSACTION
    DELETE FROM 
        [StudentCourse]
    WHERE
        [StudentId] = @StudentId

    DELETE FROM 
        [Student]
    WHERE
        [Id] = @StudentId
COMMIT
    
 
```

````SQL
CREATE OR ALTER PROCEDURE spDeleteStudent (
    @StudentId UNIQUEIDENTIFIER
)
AS
    BEGIN TRANSACTION
        DELETE FROM 
            [StudentCourse] 
        WHERE 
            [StudentId] = @StudentId

        DELETE FROM 
            [Student] 
        WHERE 
            [Id] = @StudentId
    COMMIT
````

