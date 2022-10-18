using Dapper;
using DependencyStore.Models;
using DependencyStore.Repositories.Contracts;
using Microsoft.Data.SqlClient;

namespace DependencyStore.Repositories;

public class CustomerRepository : ICustomerRepository
{
    // É uma boa prática nomear variáveis privadas com "_"
    // Usamos "readonly" possibilitar que a variável seja atribuida dentro do construtor e somente dentro dele,
    // uma única vez
    private readonly SqlConnection _connection;

    public CustomerRepository(SqlConnection connection)
         => _connection = connection;


    public async Task<Customer?> GetByIdAsync(string customerId)
    {
        const string query = "SELECT [Id], [Name], [Email] FROM CUSTOMER WHERE ID=@id";
        return await _connection.QueryFirstOrDefaultAsync<Customer>(query, new
        {
            id = customerId
        });
    }
}