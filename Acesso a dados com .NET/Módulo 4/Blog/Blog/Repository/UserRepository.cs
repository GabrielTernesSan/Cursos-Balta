using Blog.Models;
using Microsoft.Data.SqlClient;

namespace Blog.Repository
{
    public class UserRepository : Repository<User>
    {
        private readonly SqlConnection _connection;

        public UserRepository(SqlConnection connection) : base(connection)
            => _connection = connection;

    }
}
