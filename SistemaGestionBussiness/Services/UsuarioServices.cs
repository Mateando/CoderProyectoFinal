using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SistemaGestionEntities;
using SistemaGestionData.DataAccess;

namespace SistemaGestionBussiness.Services;

public class UsuarioServices
{
    private UsuariosDataAccess _usuarioDataAccess;

    public UsuarioServices(UsuariosDataAccess usuarioDataAccess)
    {
        _usuarioDataAccess = usuarioDataAccess;
    }

    public List<Usuario> GetUsuarios()
    {
        return _usuarioDataAccess.GetUsuarios();
    }

    public List<Usuario> GetUsuariosBy(string filtro)
    {
        return _usuarioDataAccess.GetUsuariosBy(filtro);
    }

    public Usuario? GetOneUsuario(int id)
    {
        return _usuarioDataAccess.GetOneUsuario(id);
    }

    public void InsertUsuario(Usuario usuario)
    {
        _usuarioDataAccess.InsertUsuario(usuario);
    }

    public void UpdateUsuario(int id, Usuario usuario)
    {
        _usuarioDataAccess.UpdateUsuario(id, usuario);
    }

}
