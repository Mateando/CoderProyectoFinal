using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaGestionEntities;
using SistemaGestionData.Context;



namespace SistemaGestionData.DataAccess;

// Esta clase se encarga de gestionar los datos de la entidad Venta.
public class SellDataAccess
{
    private CoderHouseContext _context;

    public SellDataAccess(CoderHouseContext context)
    {
        _context = context;
    }

    public List<SellEntity> GetSells()
    {
        // Código para obtener todas las ventas de la base de datos
        return _context.Sells
            .AsQueryable()
            .ToList();
    }
    public SellEntity? GetOneSell(int id)
    {
        // Código para obtener una venta de la base de datos
        return _context.Sells.Find(id);
    }

    public void SellInsert(SellEntity sell)
    {
        // Código para insertar una venta en la base de datos
        //valido que la venta no exista
        if (_context.Sells.Any(s => s.Id == sell.Id))
        {
            throw new Exception("La venta ya existe");
        }
        _context.Sells.Add(sell);
        _context.SaveChanges();
    }

    public void SellUpdate(int id, SellEntity sell)
    {
        // Código para actualizar una venta en la base de datos
        //valido que la venta exista
        SellEntity? sellToUpdate = GetOneSell(id);
        if (sellToUpdate != null)
        {
            sellToUpdate.Comments = sell.Comments;
            _context.SaveChanges();
        }
    }

    public void SellDelete(int sellId)
    {
        //valido que la venta exista
        SellEntity? sellToDelete = GetOneSell(sellId);
        if (sellToDelete != null)
        {
            _context.Sells.Remove(sellToDelete);
            _context.SaveChanges();
        }
    }

    public SellEntity? SellGetOne(int id)
    {
        return _context.Sells.Find(id);
    }

}