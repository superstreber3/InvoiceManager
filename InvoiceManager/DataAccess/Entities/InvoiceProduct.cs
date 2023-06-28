namespace InvoiceManager.DataAccess.Entities;

public class InvoiceProduct
{
    public int InvoiceId { get; set; }
    public virtual Invoice Invoice { get; set; } = null!;
    public int ProductId { get; set; }
    public virtual Product Product { get; set; } = null!;
}