using SistemaGestionData.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaGestionEntities;
using SistemaGestionData.Context;

namespace SistemaGestionBussiness.Services;

public class ProductoVendidoServices
{
    private CoderHouseContext _context;

    public ProductoVendidoServices(CoderHouseContext context)
    {
        _context = context;
    }

    public List<ProductoVendido> GetProductosVendidos()
    {
        return _context.ProductosVendidos.ToList();
    }

    public List<ProductoVendido> GetProductosVendidosBy(string filtro)
    {
        return _context.ProductosVendidos.Where(p => p.IdProducto.ToString().Contains(filtro)).ToList();
    }

    public ProductoVendido? GetOneProductoVendido(int id)
    {
        return _context.ProductosVendidos.Find(id);
    }

    public void InsertProductoVendido(ProductoVendido productoVendido)
    {
        _context.ProductosVendidos.Add(productoVendido);
        _context.SaveChanges();
    }

    public void UpdateProductoVendido(int id, ProductoVendido productoVendido)
    {
        ProductoVendido? productoVendidoToUpdate = GetOneProductoVendido(id);
        if (productoVendidoToUpdate != null)
        {
            productoVendidoToUpdate.IdProducto = productoVendido.IdProducto;
            productoVendidoToUpdate.Stock = productoVendido.Stock;
            productoVendidoToUpdate.IdVenta = productoVendido.IdVenta;
            _context.SaveChanges();
        }
    }

    public void DeleteProductoVendido(int id)
    {
        ProductoVendido? productoVendidoToDelete = GetOneProductoVendido(id);
        if (productoVendidoToDelete != null)
        {
            _context.ProductosVendidos.Remove(productoVendidoToDelete);
            _context.SaveChanges();
        }
    }
}