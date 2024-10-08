using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SistemaGestionEntities;
using SistemaGestionData.DataAccess;


namespace SistemaGestionBussiness.Services;

public class ProductosServices
{
    private readonly ProductosDataAccess _productosDataAccess;

    public ProductosServices(ProductosDataAccess productosDataAccess)
    {
        _productosDataAccess = productosDataAccess;
    }

    public List<Producto> GetProductos()
    {
        return _productosDataAccess.GetProductos();
    }

    public List<Producto> GetProductosBy(string filtro)
    {
        return _productosDataAccess.GetProductosBy(filtro);
    }

    public Producto? GetOneProducto(int id)
    {
        return _productosDataAccess.GetOneProducto(id);
    }

    public void InsertProducto(Producto producto)
    {
        _productosDataAccess.InsertProducto(producto);
    }

    public void UpdateProducto(int id, Producto producto)
    {
        _productosDataAccess.UpdateProducto(id, producto);
    }

    public void DeleteProducto(int id)
    {
        _productosDataAccess.DeleteProducto(id);
    }

    public void UpdateTotalPrice(int id)
    {

        Producto? producto = GetOneProducto(id);
        if (producto != null)
        {
            producto.TotalPrice = producto.Stock * producto.SellValue;
            _productosDataAccess.UpdateProducto(id, producto);
        }
    }

    public void UpdateTotalProductos()
    {
        var productos = GetProductos();
        foreach (var producto in productos)
        {
            producto.TotalPrice = producto.Stock * producto.SellValue;
            _productosDataAccess.UpdateProducto(producto.Id, producto);
        }

    }
}
