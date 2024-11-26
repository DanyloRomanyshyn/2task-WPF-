using System.Collections.ObjectModel;
using System.Windows.Input;
using WarehouseManagementApp.BLL;
using WarehouseManagementApp.Models;

namespace WarehouseManagementApp.ViewModels
{
    public class OrdersViewModel : BaseViewModel
    {
        private readonly IOrderService _orderService;
        private Order _selectedOrder;

        public ObservableCollection<Order> Orders { get; set; }
        public Order SelectedOrder
        {
            get => _selectedOrder;
            set
            {
                _selectedOrder = value;
                OnPropertyChanged(nameof(SelectedOrder));
            }
        }

        public ICommand AddOrderCommand { get; }
        public ICommand UpdateOrderCommand { get; }
        public ICommand DeleteOrderCommand { get; }

        public OrdersViewModel(IOrderService orderService)
        {
            _orderService = orderService;

            Orders = new ObservableCollection<Order>(_orderService.GetAllOrders());

            AddOrderCommand = new RelayCommand(AddOrder);
            UpdateOrderCommand = new RelayCommand(UpdateOrder, CanModifyOrder);
            DeleteOrderCommand = new RelayCommand(DeleteOrder, CanModifyOrder);
        }

        private void AddOrder()
        {
            var newOrder = new Order
            {
                ProductId = 0, // Replace with actual product ID
                SupplierId = 0, // Replace with actual supplier ID
                Quantity = 1,
                Status = "New"
            };
            _orderService.AddOrder(newOrder);
            Orders.Add(newOrder);
        }

        private void UpdateOrder()
        {
            _orderService.UpdateOrder(SelectedOrder);
            // Refresh list if needed
        }

        private void DeleteOrder()
        {
            _orderService.DeleteOrder(SelectedOrder.OrderId);
            Orders.Remove(SelectedOrder);
        }

        private bool CanModifyOrder()
        {
            return SelectedOrder != null;
        }
    }
}
