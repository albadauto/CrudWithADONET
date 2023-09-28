using CrudWithADONET.DAL.Interface;
using CrudWithADONET.DAO;
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
        public bool InsertUser(UserDAO model)
        {
            using (_connection = new SqlConnection(_configuration.GetConnectionString("Database")))
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

        public UserDAO GetAllUser(int id)
        {
            using (_connection = new SqlConnection(_configuration.GetConnectionString("Database")))
            {
                _command = _connection.CreateCommand();
                _command.CommandType = System.Data.CommandType.StoredProcedure;
                _command.CommandText = "AA_SP_BUSCAUSUARIO";
                _command.Parameters.AddWithValue("@ID", id);
                _connection.Open();
                var reader = _command.ExecuteReader();
                if (reader.Read())
                {
                    return new UserDAO()
                    {
                        Name = reader.GetString(1),
                        Age = reader.GetInt32(3),
                        Email = reader.GetString(2)

                    };
                }
                _connection.Close();
                return new UserDAO();


            }
        }
    }
}
