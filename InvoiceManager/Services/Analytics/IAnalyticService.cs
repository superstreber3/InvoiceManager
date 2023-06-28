using InvoiceManager.Services.Analytics.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceManager.Services.Analytics
{
    public interface IAnalyticService
    {
        AnalyticDto GetAnalytic();
    }
}
