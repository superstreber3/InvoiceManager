using System;
using System.Collections.Generic;
using System.Linq;
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

    public Invoice ReadInvoice(int id)
    {
        return _context.Invoices.Find(id) ?? throw new InvalidOperationException();
    }

    public List<Invoice> ReadInvoices()
    {
        return _context.Invoices.ToList();
    }

    public void CreateInvoice(Invoice invoice)
    {
        _context.Invoices.Add(invoice);
        _context.SaveChanges();
    }

    public void UpdateInvoice(Invoice invoice)
    {
        _context.Invoices.Update(invoice);
        _context.SaveChanges();
    }

    public void DeleteInvoice(int id)
    {
        var invoice = _context.Invoices.Find(id);
        if (invoice is not null)
        {
            _context.Invoices.Remove(invoice);
        }

        _context.SaveChanges();
    }
}