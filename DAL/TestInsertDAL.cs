using CrudWithADONET.DAL.Interface;
using CrudWithADONET.Models;
using System.Data.SqlClient;

namespace CrudWithADONET.DAL
{
    public class TestInsertDAL : ITestInsertDAL
    {
        SqlConnection _connection = null;
        SqlCommand _command = null;

        private readonly IConfiguration _configuration;
        public TestInsertDAL(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public bool InsertUser(UserModel model)
        {
            using(_connection = new SqlConnection(_configuration.GetConnectionString("Database")))
            {
                _command = _connection.CreateCommand();
                _command.CommandType = System.Data.CommandType.StoredProcedure;
                _command.CommandText = "SP_TESTINSERT";
                _command.Parameters.AddWithValue("@NAME", model.Name);
                _command.Parameters.AddWithValue("@AGE", model.Age);
                _command.Parameters.AddWithValue("@EMAIL", model.Email);
                _connection.Open();
                _command.ExecuteNonQuery();
                _connection.Close();
            }

            return true;
        }
    }
}
