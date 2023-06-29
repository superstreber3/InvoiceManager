using System;
using System.Windows;
using System.Windows.Input;
using InvoiceManager.DataAccess.Entities;
using InvoiceManager.Services.Invoices;
using InvoiceManager.Services.Products;

namespace InvoiceManager.ViewModels;

/// <summary>
///     Interaction logic for InvoiceWindow.xaml
/// </summary>
public partial class InvoiceWindow
{
    private readonly IInvoiceService _invoiceService;
    private readonly IProductService _productService;

    public InvoiceWindow(IProductService productService, IInvoiceService invoiceService)
    {
        _productService = productService;
        _invoiceService = invoiceService;
        InitializeComponent();
        GetProducts();
    }

    private void GetProducts()
    {
        var products = _productService.ReadProducts();
        ProductBinding.ItemsSource = products;
    }

    private void product_Click(object sender, MouseButtonEventArgs e)
    {
    }

    private void Create_Button_Click(object sender, RoutedEventArgs e)
    {
        //parse selectedItems to products
        var products = ProductBinding.SelectedItems;
        var invoice = new Invoice();
        foreach (var product in products)
        {
            invoice.Products.Add((Product)product);
        }

        invoice.Date = DateTime.Now;

        //create invoice
        _invoiceService.CreateInvoice(invoice);
        Close();
    }

    private void Close_Button_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }
}