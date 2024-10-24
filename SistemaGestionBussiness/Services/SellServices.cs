using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SistemaGestionEntities;
using SistemaGestionData.DataAccess;

namespace SistemaGestionBussiness.Services;

public class SellServices
{
    private SellDataAccess _ventaDataAccess;

    public SellServices(SellDataAccess ventaDataAccess)
    {
        _ventaDataAccess = ventaDataAccess;
    }

    public void SellInsert(SellEntity sell)
    {
        _ventaDataAccess.SellInsert(sell);
    }

    public void SellUpdate(int sellId, SellEntity sell)
    {
        _ventaDataAccess.SellUpdate(sellId, sell);
    }

    public void SellDelete(int sellId)
    {
        _ventaDataAccess.SellDelete(sellId);
    }

    public List<SellEntity> GetSells()
    {
        return _ventaDataAccess.GetSells();
    }

    public SellEntity? SellGetOne(int sellId)
    {
        return _ventaDataAccess.SellGetOne(sellId);
    }

    public SellEntity SellsByFilter(string filter)
    {
        return new SellEntity();
    }

}