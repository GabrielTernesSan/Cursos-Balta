## Create Database / Drop Database

### New Query

**CUIDAR O BANCO QUE ESTÁ USANDO**

**** No master ****

````sql
USE [master];
CREATE DATABASE [(Nome do banco)]
````

````sql
DROP DATABASE [Curso]
````



Forçar exclusão

`````sql
USE [master];

DECLARE @kill varchar(8000) = '';  
SELECT @kill = @kill + 'kill ' + CONVERT(varchar(5), session_id) + ';'  
FROM sys.dm_exec_sessions
WHERE database_id  = db_id('Curso')

EXEC(@kill);

DROP DATABASE [Curso]
`````

