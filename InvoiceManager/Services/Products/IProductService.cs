using System.Collections.Generic;
using InvoiceManager.DataAccess.Entities;

namespace InvoiceManager.Services.Products;

public interface IProductService
{
    void CreateProduct(Product product);
    List<Product> ReadProducts();
    Product ReadProduct(int id);
    void UpdateProduct(Product product);
    void DeleteProduct(int id);
}