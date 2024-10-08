using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaGestionEntities;
using SistemaGestionData.Context;



namespace SistemaGestionData.DataAccess;

public class VentaDataAccess
{
    private CoderHouseContext _context;

    public VentaDataAccess(CoderHouseContext context)
    {
        _context = context;
    }

    public void InsertarVenta(Venta venta)
    {
        // Código para insertar una venta en la base de datos
    }

    public void ActualizarVenta(Venta venta)
    {
        // Código para actualizar una venta en la base de datos
    }

    public void EliminarVenta(int idVenta)
    {
        // Código para eliminar una venta de la base de datos
    }

    public Venta? GetOneVenta(int id)
    {
        return _context.Ventas.Find(id);
    }

}