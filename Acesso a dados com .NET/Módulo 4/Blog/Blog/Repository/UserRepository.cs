using Blog.Models;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;

namespace Blog.Repository
{
    public class UserRepository
    {

        private SqlConnection _connection = new SqlConnection("");

        public IEnumerable<User> Get() => _connection.GetAll<User>();

        public User GetById(int id) => _connection.Get<User>(id);

        public void Create(User user) => _connection.Insert<User>(user);
    }
}
