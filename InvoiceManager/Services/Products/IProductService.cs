﻿using System.Threading.Tasks;
using InvoiceManager.DataAccess.Entities;

namespace InvoiceManager.Services.Products;

public interface IProductService
{
    Task CreateProductAsync(Product product);
    Task<Product> ReadProductAsync(int id);
    Task UpdateProductAsync(Product product);
    Task DeleteProductAsync(int id);
}