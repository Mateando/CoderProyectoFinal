using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SistemaGestionEntities;
using SistemaGestionData.DataAccess;


namespace SistemaGestionBussiness.Services;

public class ProductsServices
{
    private readonly ProductDataAccess _productosDataAccess;

    public ProductsServices(ProductDataAccess productosDataAccess)
    {
        _productosDataAccess = productosDataAccess;
    }

    public List<Product> GetProducts()
    {
        return _productosDataAccess.GetProducts();
    }

    public List<Product> GetProductBy(string filtro)
    {
        return _productosDataAccess.GetProductsBy(filtro);
    }

    public Product? GetOneProduct(int id)
    {
        return _productosDataAccess.GetOneProduct(id);
    }

    public void InsertProduct(Product product)
    {
        _productosDataAccess.InsertProduct(product);
    }

    public void UpdateProduct(int id, Product product)
    {
        _productosDataAccess.UpdateProduct(id, product);
    }

    public void DeleteProduct(int id)
    {
        _productosDataAccess.DeleteProduct(id);
    }

    public void UpdateTotalPrice(int id)
    {

        Product? product = GetOneProduct(id);
        if (product != null)
        {
            product.TotalPrice = product.Stock * product.SellValue;
            _productosDataAccess.UpdateProduct(id, product);
        }
    }

    public void UpdateTotalProducts()
    {
        var products = GetProducts();
        foreach (var product in products)
        {
            product.TotalPrice = product.Stock * product.SellValue;
            _productosDataAccess.UpdateProduct(product.Id, product);
        }

    }
}
