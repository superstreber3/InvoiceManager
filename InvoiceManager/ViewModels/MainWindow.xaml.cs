using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using InvoiceManager.DataAccess;
using InvoiceManager.DataAccess.Entities;
using InvoiceManager.Services.Invoices;

namespace InvoiceManager.ViewModels;

/// <summary>
///     Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private readonly IInvoiceService _invoiceService;

    public MainWindow(IInvoiceService invoiceService, InvoiceManagerDbContext context)
    {
        DbInitializer.Initialize(context);
        _invoiceService = invoiceService;
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
        if (item is not null)
        {
            var invoiceViewWindow = new InvoiceViewWindow((Invoice)item);
            invoiceViewWindow.Show();
        }
    }
}