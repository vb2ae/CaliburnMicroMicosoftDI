using Caliburn.Micro;
using CSharpCaliburnMicro1.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows;
using CSharpCaliburnMicro1.Views;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CSharpCaliburnMicro1
{
    public class Bootstrapper : BootstrapperBase
    {
        private IContainer container;
        private FrameAdapter _rootFrame;
        private IServiceCollection _services;

        public static IHost Host { get; private set; }

        public Bootstrapper()
        {
            Host = Microsoft.Extensions.Hosting.Host.CreateDefaultBuilder()
                .ConfigureServices((context, services) =>
                {
                    _services = services;
                    ConfigureServices(services);
                })
                .Build();
            Initialize();

        }

        private void ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddDbContext<ProductDataContext>(options =>
            {
                options.UseSqlServer(
                    "Data Source=localhost; DataBase = WpfEFAppDataBase;User=sa; Password=C@iburn.M1cr0;");
            });
            serviceCollection.AddSingleton<IWindowManager, WindowManager>();
            serviceCollection.AddSingleton<IEventAggregator, EventAggregator>();
            serviceCollection.AddTransient<IScreen, ShellViewModel>();
            serviceCollection.AddSingleton<ShellView>();
            serviceCollection.AddTransient<HomeView>();
            serviceCollection.AddTransient<HomeViewModel>();
            serviceCollection.AddSingleton<ShellViewModel>();

        }


        protected override async void OnStartup(object sender, StartupEventArgs e)
        {
            await DisplayRootViewFor<ShellViewModel>();
        }

        protected override object GetInstance(Type service, string key)
        {
            //if you need use keys here is a example on how to get around
            // microsoft.extensions.dependencyinjection does not support them
            // http://stevetalkscode.co.uk/named-dependencies-part-2

            return Host.Services.GetService(service);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return new List<object>() { Host.Services.GetService(service) };
        }


        protected override void OnExit(object sender, EventArgs e)
        {
            base.OnExit(sender, e);
        }
    }
}
