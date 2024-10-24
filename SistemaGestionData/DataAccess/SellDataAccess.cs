using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaGestionEntities;
using SistemaGestionData.Context;



namespace SistemaGestionData.DataAccess;

public class SellDataAccess
{
    private CoderHouseContext _context;

    public SellDataAccess(CoderHouseContext context)
    {
        _context = context;
    }

    public List<SellEntity> GetSells()
    {
        return _context.Sells.ToList();
    }
    public SellEntity? GetOneSell(int id)
    {
        return _context.Sells.Find(id);
    }

    public void SellInsert(SellEntity sell)
    {
        _context.Sells.Add(sell);
        _context.SaveChanges();
    }

    public void SellUpdate(int id, SellEntity sell)
    {
        SellEntity? sellToUpdate = GetOneSell(id);
        if (sellToUpdate != null)
        {
            sellToUpdate.Comments = sell.Comments;
            _context.SaveChanges();
        }
    }

    public void SellDelete(int sellId)
    {
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