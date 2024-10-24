using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SistemaGestionEntities;
using SistemaGestionData.DataAccess;

namespace SistemaGestionBussiness.Services;

public class UserServices
{
    private UserDataAccess _usuarioDataAccess;

    public UserServices(UserDataAccess usuarioDataAccess)
    {
        _usuarioDataAccess = usuarioDataAccess;
    }

    public List<UserEntity> GetUsers()
    {
        return _usuarioDataAccess.GetUsers();
    }

    public List<UserEntity> GetUserBy(string filtro)
    {
        return _usuarioDataAccess.GetUserBy(filtro);
    }

    public UserEntity? GetOneUser(int id)
    {
        return _usuarioDataAccess.GetOneUser(id);
    }

    public void InsertUser(UserEntity user)
    {
        _usuarioDataAccess.UserInsert(user);
    }

    public void UserUpdate(int id, UserEntity user)
    {
        _usuarioDataAccess.UserUpdate(id, user);
    }

}
