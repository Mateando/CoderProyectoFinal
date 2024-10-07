using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SistemaGestionEntities;

namespace SistemaGestionBussiness.Services;

public class VentaServices
{
    public void InsertarVenta(Venta venta)
    {
        // Código para insertar una venta en la base de datos
    }

    public void ActualizarVenta(int idVenta, Venta venta)
    {
        // Código para actualizar una venta en la base de datos
    }

    public void EliminarVenta(int idVenta)
    {
        // Código para eliminar una venta de la base de datos
    }

    public List<Venta> ObtenerVentas()
    {
        // Código para obtener todas las ventas de la base de datos
        return new List<Venta>();
    }

    public Venta ObtenerVentaPorId(int idVenta)
    {
        // Código para obtener una venta por su ID de la base de datos
        return new Venta();
    }

    public Venta ObtenerVentasBy(string filter)
    {
        // Código para obtener una venta por filtros de la base de datos
        return new Venta();
    }

}