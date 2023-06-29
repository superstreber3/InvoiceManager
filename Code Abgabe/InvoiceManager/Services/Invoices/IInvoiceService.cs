using System.Collections.Generic;
using InvoiceManager.DataAccess.Entities;

namespace InvoiceManager.Services.Invoices;

public interface IInvoiceService
{
    void CreateInvoice(Invoice invoice);
    void UpdateInvoice(Invoice invoice);
    void DeleteInvoice(int id);
    Invoice ReadInvoice(int id);
    List<Invoice> ReadInvoices();
}