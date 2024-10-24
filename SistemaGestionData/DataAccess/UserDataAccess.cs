using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaGestionData.Context;
using SistemaGestionEntities;

namespace SistemaGestionData.DataAccess;

public class UserDataAccess
{
    private CoderHouseContext _context;

    public UserDataAccess(CoderHouseContext context)
    {
        _context = context;
    }

    public List<UserEntity> GetUsers()
    {
        return _context.Users.ToList();
    }

    public List<UserEntity> GetUserBy(string filtro)
    {
        return _context.Users.Where(u => u.Name.Contains(filtro)).ToList();
    }

    public UserEntity? GetOneUser(int id)
    {
        return _context.Users.Find(id);
    }

    public void UserInsert(UserEntity user)
    {
        _context.Users.Add(user);
        _context.SaveChanges();
    }

    public void UserUpdate(int id, UserEntity user)
    {
        UserEntity? userToUpdate = GetOneUser(id);
        if (userToUpdate != null)
        {
            userToUpdate.Name = user.Name;
            userToUpdate.LastName = user.LastName;
            userToUpdate.Mail = user.Mail;
            userToUpdate.Password = user.Password;
            _context.SaveChanges();
        }
    }

    public void DeleteUsuario(int id)
    {
        UserEntity? userToDelete = GetOneUser(id);
        if (userToDelete != null)
        {
            _context.Users.Remove(userToDelete);
            _context.SaveChanges();
        }
    }
}
