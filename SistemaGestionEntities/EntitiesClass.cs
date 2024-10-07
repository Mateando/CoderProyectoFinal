using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Diagnostics;
using System.ComponentModel.DataAnnotations;

namespace SistemaGestionEntities;

public class Usuario
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Mail { get; set; }
}


public class ProductoVendido
{
    public int Id { get; set; }
    public int IdProducto { get; set; }
    public int Stock { get; set; }
    public int IdVenta { get; set; }
}

public class Venta
{
    public int Id { get; set; }
    public string Comments { get; set; }
    public int IdUsuario { get; set; }

}
