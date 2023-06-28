using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InvoiceManager.DataAccess;
using InvoiceManager.DataAccess.Entities;

namespace InvoiceManager.Services.Invoices;

public class InvoiceService : IInvoiceService
{
    private readonly InvoiceManagerDbContext _context;

    public InvoiceService(InvoiceManagerDbContext context)
    {
        _context = context;
    }

    public async Task InitDatabase()
    {
        await _context.Database.EnsureCreatedAsync();
    }

    public async Task CreateInvoiceAsync(Invoice invoice)
    {
        _context.Invoices.Add(invoice);
        await _context.SaveChangesAsync();
    }

    public async Task<Invoice> ReadInvoiceAsync(int id)
    {
        return await _context.Invoices.FindAsync(id);
    }

    public List<Invoice> ReadInvoices()
    {
        return _context.Invoices.ToList();
    }

    public async Task UpdateInvoiceAsync(Invoice invoice)
    {
        _context.Invoices.Update(invoice);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteInvoiceAsync(int id)
    {
        var invoice = await _context.Invoices.FindAsync(id);
        if (invoice != null)
        {
            _context.Invoices.Remove(invoice);
            await _context.SaveChangesAsync();
        }
    }
}