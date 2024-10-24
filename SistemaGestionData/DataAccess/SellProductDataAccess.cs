using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaGestionData.Context;
using SistemaGestionEntities;

namespace SistemaGestionData.DataAccess;

// Esta clase se encarga de gestionar los datos de la entidad ProductoVendido.
public class SellProductDataAccess
{

    private CoderHouseContext _context;

    public SellProductDataAccess(CoderHouseContext context)
    {
        _context = context;
    }

    public void SellProductInsert(SellProductEntity sellProduct)
    {
        // Código para insertar un producto vendido en la base de datos
        if(_context.SellProducts.Any(s => s.Id == sellProduct.Id))
        {
            throw new Exception("El producto vendido ya existe");
        }
        _context.SellProducts.Add(sellProduct);
        _context.SaveChanges();

    }

    public void SellProductUpdate(SellProductEntity sellProduct)
    {
        // Código para actualizar un producto vendido en la base de datos
        // valido que el producto vendido exista
        SellProductEntity? sellProductToUpdate = _context.SellProducts.Find(sellProduct.Id);
        if (sellProductToUpdate != null)
        {
            sellProductToUpdate.Id = sellProduct.Id;
            sellProductToUpdate.ProductId = sellProduct.ProductId;
            sellProductToUpdate.Stock = sellProduct.Stock;
            sellProductToUpdate.SellId = sellProduct.SellId;
            _context.SaveChanges();
        }
    }

    public void SellProductDelete(int sellProductId)
    {
        // Código para eliminar un producto vendido de la base de datos
        // valido que el producto vendido exista
        SellProductEntity? sellProductToDelete = _context.SellProducts.Find(sellProductId);
        if (sellProductToDelete != null)
        {
            _context.SellProducts.Remove(sellProductToDelete);
            _context.SaveChanges();
        }
    }

    //public ProductoVendido ObtenerProductoVendido(int idProductoVendido)
    //{
    //    // Código para obtener un producto vendido de la base de datos
    //}

    //public List<ProductoVendido> ObtenerProductosVendidos()
    //{
    //    // Código para obtener todos los productos vendidos de la base de datos
    //}
}