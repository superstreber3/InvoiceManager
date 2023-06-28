using System;
using System.IO;
using System.Windows;
using InvoiceManager.DataAccess;
using InvoiceManager.Services.Analytics;
using InvoiceManager.Services.Invoices;
using InvoiceManager.Services.Products;
using InvoiceManager.ViewModels;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace InvoiceManager;

public partial class App : Application
{
    public App()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", false, true);

        Configuration = builder.Build();

        var services = new ServiceCollection();
        ConfigureServices(services);
        ServiceProvider = services.BuildServiceProvider();
    }

    public IServiceProvider ServiceProvider { get; }

    public IConfiguration Configuration { get; }

    private void OnStartup(object sender, StartupEventArgs e)
    {
        var mainWindow = ServiceProvider.GetService<MainWindow>();
        mainWindow.Show();
    }

    private void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<InvoiceManagerDbContext>();
        services.AddHostedService<MigrationHostedService>();
        services.AddScoped<IProductService, ProductService>();
        services.AddScoped<IInvoiceService, InvoiceService>();
        services.AddScoped<IAnalyticService, AnalyticService>();
        services.AddSingleton<MainWindow>();
    }
}