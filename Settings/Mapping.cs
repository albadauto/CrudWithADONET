using AutoMapper;
using CrudWithADONET.DAO;
using CrudWithADONET.Models;

namespace CrudWithADONET.Settings
{
    public static class Mapping
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<UserModel, UserDAO>();
                config.CreateMap<UserDAO, UserModel>();

            });
            return mappingConfig;
        }
    }
}
