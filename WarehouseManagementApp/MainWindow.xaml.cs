using System.Windows;
using WarehouseManagementApp.Views;

namespace WarehouseManagementApp
{
    public partial class MainWindow : Window
    {
        public MainWindow(string role)
        {
            InitializeComponent();
        }

        private void OpenManageProducts(object sender, RoutedEventArgs e)
        {
            var productsWindow = new ManageProductsWindow();
            productsWindow.Show();
        }

        private void OpenManageOrders(object sender, RoutedEventArgs e)
        {
            var ordersWindow = ServiceLocator.GetService<ManageOrdersWindow>();
            ordersWindow.Show();
        }

        private void OpenManageSuppliers(object sender, RoutedEventArgs e)
        {
            var suppliersWindow = new ManageSuppliersWindow();
            suppliersWindow.Show();
        }
    }
}
