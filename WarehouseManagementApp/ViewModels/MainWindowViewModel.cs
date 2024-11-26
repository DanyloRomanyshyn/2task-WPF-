using System;
using WarehouseManagementApp.BLL;

namespace WarehouseManagementApp.ViewModels
{
    public class MainWindowViewModel
    {
        public IProductService ProductService { get; }
        public ISupplierService SupplierService { get; }
        public IOrderService OrderService { get; }

        public MainWindowViewModel(IProductService productService, ISupplierService supplierService, IOrderService orderService)
        {
            ProductService = productService ?? throw new ArgumentNullException(nameof(productService));
            SupplierService = supplierService ?? throw new ArgumentNullException(nameof(supplierService));
            OrderService = orderService ?? throw new ArgumentNullException(nameof(orderService));
        }
    }
}
