using System;
using System.Collections.Generic;
using System.Linq;
using InvoiceManager.DataAccess;
using InvoiceManager.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace InvoiceManager.Services.Products;

public class ProductService : IProductService
{
    private readonly InvoiceManagerDbContext _context;

    public ProductService(InvoiceManagerDbContext context)
    {
        _context = context;
    }

    public void CreateProduct(Product product)
    {
        _context.Products.Add(product);
        _context.SaveChanges();
    }

    public List<Product> ReadProducts()
    {
        return _context.Products.AsNoTracking().ToList();
    }

    public void UpdateProduct(Product product)
    {
        _context.Products.Update(product);
        _context.SaveChanges();
    }

    public void DeleteProduct(int id)
    {
        var product = _context.Products.Find(id);
        if (product is null)
        {
            return;
        }

        _context.Products.Remove(product);
        _context.SaveChanges();
    }

    public Product ReadProduct(int id)
    {
        return _context.Products.Find(id) ?? throw new InvalidOperationException();
    }
}