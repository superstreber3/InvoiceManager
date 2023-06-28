using System.Threading.Tasks;
using InvoiceManager.DataAccess;
using InvoiceManager.DataAccess.Entities;

namespace InvoiceManager.Services.Products;

public class ProductService : IProductService
{
    private readonly InvoiceManagerDbContext _context;

    public ProductService(InvoiceManagerDbContext context)
    {
        _context = context;
    }

    public async Task CreateProductAsync(Product product)
    {
        _context.Products.Add(product);
        await _context.SaveChangesAsync();
    }

    public async Task<Product> ReadProductAsync(int id)
    {
        return await _context.Products.FindAsync(id);
    }

    public async Task UpdateProductAsync(Product product)
    {
        _context.Products.Update(product);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteProductAsync(int id)
    {
        var product = await _context.Products.FindAsync(id);
        if (product != null)
        {
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
        }
    }
}