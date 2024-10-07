using SistemaGestionData.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SistemaGestionEntities;

namespace SistemaGestionData.DataAccess;

public class UsuariosDataAccess
{
    private CoderHouseContext _context;

    public UsuariosDataAccess(CoderHouseContext context)
    {
        _context = context;
    }

    public List<Usuario> GetUsuarios()
    {
        return _context.Usuarios.ToList();
    }

    public List<Usuario> GetUsuariosBy(string filtro)
    {
        return _context.Usuarios.Where(u => u.Name.Contains(filtro)).ToList();
    }

    public Usuario? GetOneUsuario(int id)
    {
        return _context.Usuarios.Find(id);
    }

    public void InsertUsuario(Usuario usuario)
    {
        _context.Usuarios.Add(usuario);
        _context.SaveChanges();
    }

    public void UpdateUsuario(int id, Usuario usuario)
    {
        Usuario? usuarioToUpdate = GetOneUsuario(id);
        if (usuarioToUpdate != null)
        {
            usuarioToUpdate.Name = usuario.Name;
            usuarioToUpdate.LastName = usuario.LastName;
            usuarioToUpdate.Mail = usuario.Mail;
            usuarioToUpdate.Password = usuario.Password;
            _context.SaveChanges();
        }
    }

    public void DeleteUsuario(int id)
    {
        Usuario? usuarioToDelete = GetOneUsuario(id);
        if (usuarioToDelete != null)
        {
            _context.Usuarios.Remove(usuarioToDelete);
            _context.SaveChanges();
        }
    }
}
