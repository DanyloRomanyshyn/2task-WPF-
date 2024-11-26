using System.Collections.Generic;
using WarehouseManagementApp.DAL;
using WarehouseManagementApp.Models;

namespace WarehouseManagementApp.BLL
{
    public interface IOrderService 
    {
        IEnumerable<Order> GetAllOrders();
        Order GetOrderById(int orderId);
        void AddOrder(Order order);
        void UpdateOrder(Order order);
        void DeleteOrder(int orderId);
    }
}
