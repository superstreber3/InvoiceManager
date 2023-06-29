namespace InvoiceManager.Services.Analytics.Dto;

public class AnalyticDto
{
    public string MostSoldProduct { get; set; } = string.Empty;
    public string NewestInvoice { get; set; } = string.Empty;
    public string OutOfStockProduct { get; set; } = string.Empty;
    public int MostProductsInOneInvoice { get; set; } = 0;
}