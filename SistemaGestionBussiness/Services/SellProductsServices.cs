using SistemaGestionData.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaGestionEntities;
using SistemaGestionData.Context;

namespace SistemaGestionBussiness.Services;

public class SellProductsServices
{
    private CoderHouseContext _context;

    public SellProductsServices(CoderHouseContext context)
    {
        _context = context;
    }

    public List<SellProductEntity> GetSellProducts()
    {
        return _context.SellProducts
            .AsQueryable()
            .ToList();
    }

    public List<SellProductEntity> GetSellProductBy(string filtro)
    {

        return _context.SellProducts
                .AsQueryable()
                .Where(p => p.ProductId.ToString().Contains(filtro))
                .ToList();
    }

    public SellProductEntity? GetOneSellProduct(int id)
    {
        return _context.SellProducts.Find(id);
    }

    public void SellProductInsert(SellProductEntity sellProduct)
    {
        _context.SellProducts.Add(sellProduct);
        _context.SaveChanges();
    }

    public void sellProductUpdate(int id, SellProductEntity sellProduct)
    {
        SellProductEntity? productoVendidoToUpdate = GetOneSellProduct(id);
        if (productoVendidoToUpdate != null)
        {
            productoVendidoToUpdate.ProductId = sellProduct.ProductId;
            productoVendidoToUpdate.Stock = sellProduct.Stock;
            productoVendidoToUpdate.SellId = sellProduct.SellId;
            _context.SaveChanges();
        }
    }

    public void DeleteSellProduct(int id)
    {
        SellProductEntity? sellProductToDelete = GetOneSellProduct(id);
        if (sellProductToDelete != null)
        {
            _context.SellProducts.Remove(sellProductToDelete);
            _context.SaveChanges();
        }
    }
}