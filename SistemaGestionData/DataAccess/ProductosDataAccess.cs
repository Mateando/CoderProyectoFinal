using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaGestionData.Context;
using SistemaGestionEntities;

namespace SistemaGestionData.DataAccess;

public class ProductosDataAccess
{
    private CoderHouseContext _context;

    public ProductosDataAccess(CoderHouseContext context)
    {
        _context = context;
    }

    public List<Producto> GetProductos()
    {
        return _context.Productos.ToList();
    }

    public List<Producto> GetProductosBy(string filtro)
    {
        return _context.Productos.Where(producto => producto.Category.Contains(filtro)).ToList();
    }

    public Producto? GetOneProducto(int id)
    {
        return _context.Productos.FirstOrDefault(producto => producto.Id == id);
    }

    public void UpdateProducto(int id, Producto producto)
    {
        Producto? productoAEditar = GetOneProducto(id);
        if (productoAEditar != null)
        {
            productoAEditar.Description = producto.Description;
            productoAEditar.Category = producto.Category;
            productoAEditar.Stock = producto.Stock;
            productoAEditar.BuyPrice = producto.BuyPrice;
            productoAEditar.SellValue = producto.SellValue;
            productoAEditar.TotalPrice = producto.TotalPrice;

            _context.SaveChanges();
        }
    }
    public void InsertProducto(Producto producto)
    {
        _context.Productos.Add(producto);
        _context.SaveChanges();
    }

    public void DeleteProducto(int id)
    {
        Producto? productoAEliminar = GetOneProducto(id);
        if (productoAEliminar != null)
        {
            _context.Productos.Remove(productoAEliminar);
            _context.SaveChanges();
        }
    }

    public void UpdateTotalPrice(int id)
    {
        Producto? producto = GetOneProducto(id);
        if (producto != null)
        {
            producto.TotalPrice = producto.Stock * producto.SellValue;
            _context.SaveChanges();
        }
    }

    public void UpdateTotalProductos()
    {
        var productos = GetProductos();
        foreach (var producto in productos)
        {
            producto.TotalPrice = producto.Stock * producto.SellValue;
            _context.SaveChanges();
        }
    }
}