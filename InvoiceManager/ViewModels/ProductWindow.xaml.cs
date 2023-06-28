using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using InvoiceManager.DataAccess.Entities;
using InvoiceManager.Services.Products;

namespace InvoiceManager.ViewModels;

/// <summary>
///     Interaction logic for ProductWindow.xaml
/// </summary>
public partial class ProductWindow : Window
{
    private readonly IProductService _productService;
    private readonly Product? _selectedProduct;

    public ProductWindow(IProductService productService, Product? selectedProduct)
    {
        InitializeComponent();
        _productService = productService;
        _selectedProduct = selectedProduct;
        if (_selectedProduct != null)
        {
            NameInput.Text = _selectedProduct.Name;
            DescriptionInput.Text = _selectedProduct.Description;
            PriceInput.Text = _selectedProduct.Price.ToString();
            StockInput.Text = _selectedProduct.Stock.ToString();
        }
    }

    private void DecimalValidationTextBox(object sender, TextCompositionEventArgs e)
    {
        var regex = new Regex("[^0-9]+");
        if (regex.IsMatch(e.Text) && e.Text != ".")
        {
            e.Handled = true;
        }
        else if (e.Text == "." && ((TextBox)sender).Text.Contains("."))
        {
            e.Handled = true;
        }
    }

    private void DecimalTextChanged(object sender, TextChangedEventArgs e)
    {
        var textBox = (TextBox)sender;
        if (!string.IsNullOrEmpty(textBox.Text) && double.TryParse(textBox.Text, out var num) &&
            textBox.Text.Contains("."))
        {
            textBox.Text = num.ToString("F2");
            textBox.CaretIndex = textBox.Text.Length;
        }
    }


    private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
    {
        var regex = new Regex("[^0-9]+"); //regex that matches disallowed text
        e.Handled = regex.IsMatch(e.Text);
    }


    private void OnSubmitClick(object sender, RoutedEventArgs e)
    {
        var product = new Product
        {
            Name = NameInput.Text,
            Description = DescriptionInput.Text,
            Price = decimal.Parse(PriceInput.Text),
            Stock = int.Parse(StockInput.Text)
        };
        if (_selectedProduct != null)
        {
            product.Id = _selectedProduct.Id;
            _productService.UpdateProduct(product);
            Close();
            return;
        }
        _productService.CreateProduct(product);
        Close();
    }
}