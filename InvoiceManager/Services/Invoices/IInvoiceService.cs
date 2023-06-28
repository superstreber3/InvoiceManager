using System.Collections.Generic;
using System.Threading.Tasks;
using InvoiceManager.DataAccess.Entities;

namespace InvoiceManager.Services.Invoices;

public interface IInvoiceService
{
    Task InitDatabase();
    Task CreateInvoiceAsync(Invoice invoice);
    Task<Invoice> ReadInvoiceAsync(int id);
    List<Invoice> ReadInvoices();
    Task UpdateInvoiceAsync(Invoice invoice);
    Task DeleteInvoiceAsync(int id);
}