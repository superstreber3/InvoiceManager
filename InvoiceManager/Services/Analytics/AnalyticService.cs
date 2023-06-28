using InvoiceManager.DataAccess;
using InvoiceManager.Services.Analytics.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManager.Services.Analytics
{
    public class AnalyticService : IAnalyticService
    {
        private readonly InvoiceManagerDbContext _context;

        public AnalyticService(InvoiceManagerDbContext context)
        {
            _context = context;
        }

        public AnalyticDto GetAnalytic()
        {
            var analytic = new AnalyticDto();
            //get most sold product
            var mostSoldProduct = _context.InvoiceProducts.AsEnumerable().GroupBy(x => x.ProductId).OrderByDescending(x => x.Count()).FirstOrDefault();

            if (mostSoldProduct is not null)
            {
                analytic.MostSoldProduct = _context.Products.Find(mostSoldProduct.Key).Name;
            }

            var newestInvoice = _context.Invoices
                .OrderByDescending(x => x.Date)
                .FirstOrDefault();
            if (newestInvoice is not null)
            {
                analytic.NewestInvoice = newestInvoice.Date.ToString("dd/MM/yyyy");
            }

            var outOfStockProduct = _context.Products
                .Where(x => x.Stock == 0).ToList();
            if (outOfStockProduct is not null)
            {
                foreach (var product in outOfStockProduct)
                {
                    analytic.OutOfStockProduct += product.Name + ", ";
                }
            }

            var mostProductsInOneInvoice = _context.InvoiceProducts.AsEnumerable()
                .GroupBy(x => x.InvoiceId)
                .OrderByDescending(x => x.Count())
                .FirstOrDefault();
            if (mostProductsInOneInvoice is not null)
            {
                analytic.MostProductsInOneInvoice = mostProductsInOneInvoice.Count();
            }

            return analytic;
        }
    }
}
