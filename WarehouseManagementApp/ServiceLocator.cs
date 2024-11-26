using Microsoft.Extensions.DependencyInjection;
using WarehouseManagementApp.BLL;
using WarehouseManagementApp.DAL;
using WarehouseManagementApp.ViewModels;
using WarehouseManagementApp.Views;

namespace WarehouseManagementApp
{
    public class ServiceLocator
    {
        private static ServiceProvider _provider;

        public static ServiceProvider ConfigureServices(string connectionString)
        {
            var services = new ServiceCollection();

            // Додати репозиторії з передачею connectionString
            services.AddSingleton<SuppliersRepository>(provider => new SuppliersRepository(connectionString));
            services.AddSingleton<ProductsRepository>(provider => new ProductsRepository(connectionString));
            services.AddSingleton<UsersRepository>(provider => new UsersRepository(connectionString));
            services.AddSingleton<OrdersRepository>(provider => new OrdersRepository(connectionString));

            // Додати сервіси
            services.AddSingleton<ISupplierService, SupplierService>();
            services.AddSingleton<IProductService, ProductService>();
            services.AddSingleton<IOrderService, OrderService>();

            // Додати ViewModels
            services.AddSingleton<OrdersViewModel>();
            services.AddSingleton<ManageOrdersWindow>();

            services.AddSingleton<IOrderService, OrderService>();
            services.AddSingleton(provider => new ManageOrdersWindow(provider.GetService<IOrderService>()));

            services.AddSingleton<SuppliersViewModel>();
            services.AddSingleton<ProductsViewModel>();

            _provider = services.BuildServiceProvider();

            return _provider;
        }

        public static T GetService<T>()
        {
            return _provider.GetService<T>();
        }
    }
}