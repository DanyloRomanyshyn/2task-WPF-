using System.Collections.Generic;
using WarehouseManagementApp.DAL;
using WarehouseManagementApp.Models;

namespace WarehouseManagementApp.BLL
{
    public class OrderService : IOrderService
    {
        private readonly OrdersRepository _ordersRepository;

        public OrderService(string connectionString)
        {
            _ordersRepository = new OrdersRepository(connectionString);
        }

        public IEnumerable<Order> GetAllOrders()
        {
            return _ordersRepository.GetAllOrders();
        }

        public Order GetOrderById(int orderId)
        {
            return _ordersRepository.GetOrderById(orderId);
        }

        public void AddOrder(Order order)
        {
            _ordersRepository.AddOrder(order.OrderId, order.ProductId, order.SupplierId, order.Quantity, order.Status);
        }

        public void UpdateOrder(Order order)
        {
            _ordersRepository.UpdateOrder(order.OrderId, order.ProductId, order.SupplierId, order.Quantity, order.Status);
        }

        public void DeleteOrder(int orderId)
        {
            _ordersRepository.DeleteOrder(orderId);
        }
    }
}
