using InvoiceManager.Services.Analytics;

namespace InvoiceManager.ViewModels;

/// <summary>
///     Interaction logic for AnalyticWindow.xaml
/// </summary>
public partial class AnalyticWindow
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