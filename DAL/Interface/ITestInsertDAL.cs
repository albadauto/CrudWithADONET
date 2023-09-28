using CrudWithADONET.DAO;
using CrudWithADONET.Models;

namespace CrudWithADONET.DAL.Interface
{
    public interface ITestInsertDAL
    {
        public bool InsertUser(UserDAO model);
        public UserDAO GetAllUser(int id);
    }
}
