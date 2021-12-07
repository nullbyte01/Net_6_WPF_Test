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
            _host = Host.CreateDefaultBuilder().ConfigureServices(services =>
            {
                Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NTI1OTAxQDMxMzkyZTMzMmUzMFNYc2NqblNlR0M2eU1nSjFNajhyK0JCdTkya0VlblRkSzFpODM2NEdsQms9;NTI1OTAyQDMxMzkyZTMzMmUzMFE3TVdDN3J3TTRjMk1nTUZRamI0d214Q3RhTHFKbnllaEczSnI4SjZzdnM9;NTI1OTAzQDMxMzkyZTMzMmUzMElTMFYzdWU3TWVvWnRpZmlxUWJlQ0wwTnFGYXBSMEtaNUlqUTlQWDZvaUk9;NTI1OTA0QDMxMzkyZTMzMmUzMGZlUjFjOElIekRINmllWUQrbFhZVmpYQms1YU5XSld4Vk1tU0p5U25Cb2s9;NTI1OTA1QDMxMzkyZTMzMmUzMGRsNmpzM0tJWGtSY3UvdDRxYWk3ZHNLK0UxRUtKU3ZaKzRCS3BvaER6QUE9;NTI1OTA2QDMxMzkyZTMzMmUzME1nVldDT0Q3SmpBY2cvNThrZFY5NzdJR2tERTdOVkppdGp6Wlh6L3hpaTg9;NTI1OTA3QDMxMzkyZTMzMmUzMENuTXYrOFZZb0hWUjd3TVhKN0ZKeXVnejNsbXlESERJOFg5aUF1Mm9OK1U9;NTI1OTA4QDMxMzkyZTMzMmUzMERFWk43MVNZc3V6RGlrejBpS1I0TlQrVGIrZ0pXeFcwZmtUQUZkVDNMY289;NTI1OTA5QDMxMzkyZTMzMmUzMGJoVkNuUE9HZ1BHd3RCQ0ZWS1MxdXVnMFZ1S3RjU3JGZ1lBcU52enl0L1E9;NTI1OTEwQDMxMzkyZTMzMmUzMEVZeEE4RnVvSmNoT1ZjOTBiYnJoR3hFbUpWK0MyalhTekR1aDZ2QUJXZWs9;NTI1OTExQDMxMzkyZTMzMmUzMEUrYmpVakpydkJvZ3hSTzdZV2M0ZG5XQ2dJR0h0M0VuZjErSEZLbUJkV2M9");
               
                services.AddSingleton<MainViewModel>();
                services.AddHttpClient<ITestService, TestService>(client =>
                {
                    client.BaseAddress = new Uri("https://localhost:7226");
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
