using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace InvoiceManager.DataAccess;

public class MigrationHostedService : IHostedService
{
    public MigrationHostedService(IServiceProvider services, IHostApplicationLifetime hostApplicationLifeTime)
    {
        Services = services;
        HostApplicationLifeTime = hostApplicationLifeTime;
    }

    private IServiceProvider Services { get; }
    private IHostApplicationLifetime HostApplicationLifeTime { get; }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        var context = Services.GetRequiredService<InvoiceManagerDbContext>();

        await context.Database.MigrateAsync(cancellationToken);

        HostApplicationLifeTime.StopApplication();
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}