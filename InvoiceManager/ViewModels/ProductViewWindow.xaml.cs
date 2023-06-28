using InvoiceManager.DataAccess.Entities;
using InvoiceManager.Services.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace InvoiceManager.ViewModels
{
    /// <summary>
    /// Interaction logic for ProductViewWindow.xaml
    /// </summary>
    public partial class ProductViewWindow : Window
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
            productWindow.Closed += (o, args) => { GetProducts(); };
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
}
