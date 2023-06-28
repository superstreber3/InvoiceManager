using InvoiceManager.Services.Analytics;
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
    /// Interaction logic for AnalyticWindow.xaml
    /// </summary>
    public partial class AnalyticWindow : Window
    {
        private readonly IAnalyticService _analyticService;
        public AnalyticWindow(IAnalyticService analyticService)
        {
            _analyticService = analyticService;
            InitializeComponent();
            GetAnalytics();
        }
        private void GetAnalytics()
        {
            var analytics = _analyticService.GetAnalytic();
            DataContext = analytics;
        }
    }
}
