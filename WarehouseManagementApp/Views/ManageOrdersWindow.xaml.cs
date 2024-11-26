using System.Windows;
using WarehouseManagementApp.ViewModels;
using WarehouseManagementApp.BLL;

namespace WarehouseManagementApp.Views
{
    public partial class ManageOrdersWindow : Window
    {
        public ManageOrdersWindow(IOrderService orderService)
        {
            InitializeComponent();
            DataContext = new OrdersViewModel(orderService);
        }
    }
}
