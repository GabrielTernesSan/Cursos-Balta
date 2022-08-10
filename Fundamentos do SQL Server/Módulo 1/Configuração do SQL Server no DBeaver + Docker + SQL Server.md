## Configuração do SQL Server no DBeaver + Docker + SQL Server

### Docker

`docker pull mcr.microsoft.com/mssql/server`

`docker run --name sqlserver -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=1q2w3e4r@#$" -p 1433:1433 -d mcr.microsoft.com/mssql/server`

### DBeaver

Usuário: "sa"