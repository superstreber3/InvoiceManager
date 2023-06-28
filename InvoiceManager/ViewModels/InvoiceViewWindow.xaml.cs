using System.Windows;
using InvoiceManager.DataAccess.Entities;

namespace InvoiceManager.ViewModels;

/// <summary>
///     Interaction logic for InvoiceViewWindow.xaml
/// </summary>
public partial class InvoiceViewWindow : Window
{
    private readonly Invoice _invoice;

    public InvoiceViewWindow(Invoice invoice)
    {
        _invoice = invoice;
        InitializeComponent();
        GetInvoice();
    }

    private void GetInvoice()
    {
        InvoiceViewBinding.ItemsSource = _invoice.Products;
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }
}