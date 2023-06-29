using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using InvoiceManager.DataAccess.Entities;
using InvoiceManager.Services.Products;

namespace InvoiceManager.ViewModels;

/// <summary>
///     Interaction logic for ProductViewWindow.xaml
/// </summary>
public partial class ProductViewWindow
{
    private readonly IProductService _productService;

    public ProductViewWindow(IProductService productService)
    {
        InitializeComponent();
        _productService = productService;
        GetProducts();
    }

    private void GetProducts()
    {
        var products = _productService.ReadProducts();
        ProductViewBinding.ItemsSource = products;
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }

    private void OpenProduct(object sender, MouseButtonEventArgs e)
    {
        var item = (sender as ListView)?.SelectedItem;
        if (item is null)
        {
            return;
        }

        var productWindow = new ProductWindow(_productService, (Product)item);
        productWindow.Show();
        productWindow.Closed += (_, _) => { GetProducts(); };
    }

    private void RemoveProduct(object sender, RoutedEventArgs e)
    {
        foreach (var selectedItem in ProductViewBinding.SelectedItems)
        {
            _productService.DeleteProduct(((Product)selectedItem).Id);
        }

        GetProducts();
    }
}