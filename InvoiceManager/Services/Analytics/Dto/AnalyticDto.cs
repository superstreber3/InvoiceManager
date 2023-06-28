using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManager.Services.Analytics.Dto
{
    public class AnalyticDto
    {
        public string MostSoldProduct { get; set; }
        public string NewestInvoice { get; set; }
        public string OutOfStockProduct { get; set; }
        public int MostProductsInOneInvoice { get; set; }
    }
}
