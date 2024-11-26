using Microsoft.Extensions.DependencyInjection;
using System;
using System.Windows;

namespace WarehouseManagementApp
{
    public partial class App : Application
    {

        public static ServiceProvider ServiceProvider { get; private set; }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            string connectionString = "Host=localhost;Port=5432;Database=WarehouseDB;Username=postgres;Password=Wdhjkopz1!";
            ServiceProvider = ServiceLocator.ConfigureServices(connectionString);


        }
    }
}
