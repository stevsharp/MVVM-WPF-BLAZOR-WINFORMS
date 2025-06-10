using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;

using WpfAppCommunityMVVM.Repository;
using WpfAppCommunityMVVM.ViewModel;

namespace WpfAppCommunityMVVM;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    public static  IHost AppHost { get; private set; } = null!;

    public App()
    {
        AppHost = Host.CreateDefaultBuilder()
                       .ConfigureServices((context, services) =>
                       {
                           // Register services
                           services.AddSingleton<ICustomerRepository, InMemoryCustomerRepository>();

                           // Register viewmodels
                           services.AddTransient<CustomerGridViewModel>();

                           // Register windows
                           services.AddTransient<MainWindow>();
                       })
                       .Build();
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
        AppHost.Start();
        
        // Resolve and show the main window
        var mainWindow = AppHost.Services.GetRequiredService<MainWindow>();
        mainWindow.Show();
    }

    protected override void OnExit(ExitEventArgs e)
    {
        base.OnExit(e);
        AppHost.StopAsync().GetAwaiter().GetResult();
        AppHost.Dispose();
    }
}


