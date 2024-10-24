using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SistemaGestionData.Context;
using SistemaGestionEntities;

namespace SistemaGestionData.DataAccess;

// Esta clase se encarga de gestionar los datos de la entidad Producto.
public class ProductDataAccess
{
    private CoderHouseContext _context;

    public ProductDataAccess(CoderHouseContext context)
    {
        _context = context;
    }

    public List<Product> GetProducts()
    {
        // Código para obtener todos los productos de la base de datos
        return _context.Products
            .AsQueryable()
            .ToList();
    }

    public List<Product> GetProductsBy(string filtro)
    {
        // Código para obtener los productos que coincidan con el filtro
        return _context.Products
            .AsQueryable()
            .Where(product => product.Category.Contains(filtro))
            .ToList();
    }

    public Product? GetOneProduct(int id)
    {
        // Código para obtener un producto de la base de datos
        return _context.Products.FirstOrDefault(product => product.Id == id);
    }

    public void UpdateProduct(int id, Product product)
    {
        // Código para actualizar un producto en la base de datos
        //valido que el producto exista
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
        // Código para insertar un producto en la base de datos
        //valido que el producto no exista
        if (_context.Products.Any(p => p.Id == product.Id))
        {
            throw new Exception("El producto ya existe");
        }
        _context.Products.Add(product);
        _context.SaveChanges();
    }

    public void DeleteProduct(int id)
    {
        // Código para eliminar un producto de la base de datos
        //valido que el producto exista
        Product? productToDelete= GetOneProduct(id);
        if (productToDelete != null)
        {
            _context.Products.Remove(productToDelete);
            _context.SaveChanges();
        }
    }

    public void UpdateTotalPrice(int id)
    {
        // Código para actualizar el precio total de un producto
        //valido que el producto exista
        Product? product = GetOneProduct(id);
        if (product != null)
        {
            product.TotalPrice = product.Stock * product.SellValue;
            _context.SaveChanges();
        }
    }

    public void UpdateTotalProducts()
    {
        // Código para actualizar el precio total de todos los productos
        //obtengo todos los productos
        var products = GetProducts();
        foreach (var product in products)
        {
            product.TotalPrice = product.Stock * product.SellValue;
            _context.SaveChanges();
        }
    }
}