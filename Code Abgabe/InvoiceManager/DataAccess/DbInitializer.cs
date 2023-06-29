using System;
using System.Linq;
using InvoiceManager.DataAccess.Entities;

namespace InvoiceManager.DataAccess;

public static class DbInitializer
{
    public static void Initialize(InvoiceManagerDbContext context)
    {
        context.Database.EnsureCreated();

        // Look for any students.
        if (context.Invoices.Any())
        {
            return; // DB has been seeded
        }

        context.Database.EnsureCreated();

        var invoices = new Invoice[]
        {
            new() { Date = DateTime.Parse("2021-01-01") },
            new() { Date = DateTime.Parse("2021-02-01") },
            new() { Date = DateTime.Parse("2021-03-01") },
            new() { Date = DateTime.Parse("2021-04-01") }
        };
        foreach (var invoice in invoices)
        {
            context.Invoices.Add(invoice);
        }

        context.SaveChanges();

        var products = new Product[]
        {
            new() { Name = "Product 1", Description = "Description 1", Price = 1.0m, Stock = 1 },
            new() { Name = "Product 2", Description = "Description 2", Price = 2.0m, Stock = 2 },
            new() { Name = "Product 3", Description = "Description 3", Price = 3.0m, Stock = 3 },
            new() { Name = "Product 4", Description = "Description 4", Price = 4.0m, Stock = 4 }
        };

        foreach (var product in products)
        {
            context.Products.Add(product);
        }

        context.SaveChanges();

        var invoiceProducts = new InvoiceProduct[]
        {
            new() { InvoiceId = 1, ProductId = 1 },
            new() { InvoiceId = 1, ProductId = 2 },
            new() { InvoiceId = 2, ProductId = 2 },
            new() { InvoiceId = 2, ProductId = 3 },
            new() { InvoiceId = 3, ProductId = 3 },
            new() { InvoiceId = 3, ProductId = 4 },
            new() { InvoiceId = 4, ProductId = 4 },
            new() { InvoiceId = 4, ProductId = 1 }
        };

        foreach (var invoiceProduct in invoiceProducts)
        {
            context.InvoiceProducts.Add(invoiceProduct);
        }

        context.SaveChanges();
    }
}