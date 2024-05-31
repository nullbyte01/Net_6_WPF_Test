using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TestApp.WPF.Services;
using TestApp.WPF.ViewModels;
using Syncfusion.Windows;

namespace TestApp.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static readonly IHost _host;
        static App()
        {
            var builder = new ConfigurationBuilder().SetBasePath(System.IO.Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            var config = builder.Build();

            string connnectionString = config.GetConnectionString("serviceUrl");

            _host = Host.CreateDefaultBuilder().ConfigureServices(services =>
            {
                Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("YOUR-LICENSE-KEY");


                services.AddSingleton<MainViewModel>();
                services.AddHttpClient<ITestService, TestService>(client =>
                {
                    client.BaseAddress = new Uri(connnectionString);
                });

                services.AddSingleton(s => new MainWindow()
                {
                    DataContext = s.GetRequiredService<MainViewModel>(),
                });

            }).Build();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            _host.Start();
            MainWindow = _host.Services.GetRequiredService<MainWindow>();

            if (MainWindow != null)
                MainWindow.Show();

            base.OnStartup(e);
        }
    }
}
