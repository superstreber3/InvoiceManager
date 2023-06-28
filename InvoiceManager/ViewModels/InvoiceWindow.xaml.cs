using System;
using System.Windows;
using System.Windows.Input;
using InvoiceManager.Services.Products;

namespace InvoiceManager.ViewModels;

/// <summary>
///     Interaction logic for InvoiceWindow.xaml
/// </summary>
public partial class InvoiceWindow : Window
{
    private readonly IProductService _productService;

    public InvoiceWindow(IProductService productService)
    {
        _productService = productService;
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
        throw new NotImplementedException();
    }

    private void Close_Button_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }
}