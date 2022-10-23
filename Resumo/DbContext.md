## DbContext

O Entity Framework Core fornece uma classe principal chamada DBContext, na qual é o canal de conexão com o banco de dados, esta classe de contexto vai administrar as entidades durante o tempo de execução, isso vai incluir preencher objetos no banco de dados, controlar as alterações feitas nos objetos, atualizar os dados no banco de dados, em outras palavras o DBContext representa a conexão com o banco de dados.

O DBContext possui um ou mais DBSet que representam as tabelas do banco de dados, que são passados/acessados através do LINQ(Language INtegrated Query) o LINQ é um conjunto recurso que foi implementado na plataforma .NET e que permite realizar consulta em banco de dados que usa uma sintaxe parecida com SQL.