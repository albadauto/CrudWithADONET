using CrudWithADONET.Models;

namespace CrudWithADONET.DAL.Interface
{
    public interface ITestInsertDAL
    {
        public bool InsertUser(UserModel model);
    }
}
