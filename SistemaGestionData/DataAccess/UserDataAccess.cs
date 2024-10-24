using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaGestionData.Context;
using SistemaGestionEntities;

namespace SistemaGestionData.DataAccess;

// Esta clase se encarga de gestionar los datos de la entidad Usuario.
public class UserDataAccess
{
    private CoderHouseContext _context;

    public UserDataAccess(CoderHouseContext context)
    {
        _context = context;
    }

    public List<UserEntity> GetUsers()
    {
        // Código para obtener todos los usuarios de la base de datos
        return _context.Users
            .AsQueryable()
            .ToList();
    }

    public List<UserEntity> GetUserBy(string filtro)
    {
        // Código para obtener todos los usuarios de la base de datos que cumplan con el filtro
        return _context.Users
               .AsQueryable()
               .Where(u => u.Name.Contains(filtro))
               .ToList();
    }

    public UserEntity? GetOneUser(int id)
    {
        // Código para obtener un usuario de la base de datos
        return _context.Users.Find(id);
    }

    public void UserInsert(UserEntity user)
    {
        // Código para insertar un usuario en la base de datos
        //  valido que el usuario no exista
        if (_context.Users.Any(u => u.Mail == user.Mail))
        {
            throw new Exception("El usuario ya existe");
        }
        _context.Users.Add(user);
        _context.SaveChanges();
    }

    public void UserUpdate(int id, UserEntity user)
    {
        // Código para actualizar un usuario en la base de datos
        //  valido que el usuario exista
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
        // Código para eliminar un usuario de la base de datos
        //  valido que el usuario exista
        UserEntity? userToDelete = GetOneUser(id);
        if (userToDelete != null)
        {
            _context.Users.Remove(userToDelete);
            _context.SaveChanges();
        }
    }
}
