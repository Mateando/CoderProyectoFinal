using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaGestionData.Context;
using SistemaGestionEntities;

namespace SistemaGestionData.DataAccess;

public class ProductDataAccess
{
    private CoderHouseContext _context;

    public ProductDataAccess(CoderHouseContext context)
    {
        _context = context;
    }

    public List<Product> GetProducts()
    {
        return _context.Products.ToList();
    }

    public List<Product> GetProductsBy(string filtro)
    {
        return _context.Products.Where(product => product.Category.Contains(filtro)).ToList();
    }

    public Product? GetOneProduct(int id)
    {
        return _context.Products.FirstOrDefault(product => product.Id == id);
    }

    public void UpdateProduct(int id, Product product)
    {
        Product? productToEdit = GetOneProduct(id);
        if (productToEdit != null)
        {
            productToEdit.Description = product.Description;
            productToEdit.Category = product.Category;
            productToEdit.Stock = product.Stock;
            productToEdit.BuyPrice = product.BuyPrice;
            productToEdit.SellValue = product.SellValue;
            productToEdit.TotalPrice = product.TotalPrice;

            _context.SaveChanges();
        }
    }
    public void InsertProduct(Product product)
    {
        _context.Products.Add(product);
        _context.SaveChanges();
    }

    public void DeleteProduct(int id)
    {
        Product? productToDelete= GetOneProduct(id);
        if (productToDelete != null)
        {
            _context.Products.Remove(productToDelete);
            _context.SaveChanges();
        }
    }

    public void UpdateTotalPrice(int id)
    {
        Product? product = GetOneProduct(id);
        if (product != null)
        {
            product.TotalPrice = product.Stock * product.SellValue;
            _context.SaveChanges();
        }
    }

    public void UpdateTotalProducts()
    {
        var products = GetProducts();
        foreach (var product in products)
        {
            product.TotalPrice = product.Stock * product.SellValue;
            _context.SaveChanges();
        }
    }
}