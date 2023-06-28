using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace InvoiceManager.DataAccess.Entities;

public class Invoice
{
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    [Key]
    [Column(Order = 0)]
    public int Id { get; set; }

    public DateTime Date { get; set; }
    public virtual List<Product> Products { get; set; } = new();
    public virtual List<InvoiceProduct> InvoiceProducts { get; set; } = new();
}