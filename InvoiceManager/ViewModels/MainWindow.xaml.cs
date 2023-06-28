using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using InvoiceManager.DataAccess;
using InvoiceManager.DataAccess.Entities;
using InvoiceManager.Services.Analytics;
using InvoiceManager.Services.Invoices;
using InvoiceManager.Services.Products;

namespace InvoiceManager.ViewModels;

/// <summary>
///     Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private readonly IInvoiceService _invoiceService;
    private readonly IProductService _productService;
    private readonly IAnalyticService _analyticService;

    public MainWindow(IInvoiceService invoiceService, IProductService productService, IAnalyticService analyticService, InvoiceManagerDbContext context)
    {
        DbInitializer.Initialize(context);
        _invoiceService = invoiceService;
        _productService = productService;
        _analyticService = analyticService;
        InitializeComponent();
        GetInvoices();
    }

    private void GetInvoices()
    {
        var invoices = _invoiceService.ReadInvoices();
        InvoiceBinding.ItemsSource = invoices;
    }

    private void invoiceView_Click(object sender, MouseButtonEventArgs e)
    {
        var item = (sender as ListView)?.SelectedItem;
        if (item is null)
        {
            return;
        }

        var invoiceViewWindow = new InvoiceViewWindow((Invoice)item);
        invoiceViewWindow.Show();
    }

    private void CreateInvoice(object sender, RoutedEventArgs e)
    {
        var invoiceWindow = new InvoiceWindow(_productService, _invoiceService);
        invoiceWindow.Show();
        invoiceWindow.Closed += (o, args) => { GetInvoices(); };
    }

    private void RemoveInvoice(object sender, RoutedEventArgs e)
    {
        foreach (var selectedItem in InvoiceBinding.SelectedItems)
        {
            _invoiceService.DeleteInvoice(((Invoice)selectedItem).Id);
        }

        GetInvoices();
    }

    private void CreateProduct(object sender, RoutedEventArgs e)
    {
        var productWindow = new ProductWindow(_productService, null);
        productWindow.Show();
    }

    private void ViewProducts(object sender, RoutedEventArgs e)
    {
        var productViewWindow = new ProductViewWindow(_productService);
        productViewWindow.Show();
    }

    private void ViewAnalytics(object sender, RoutedEventArgs e)
    {
        var analyticWindow = new AnalyticWindow(_analyticService);
        analyticWindow.Show();
    }
}