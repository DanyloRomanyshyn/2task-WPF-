using Microsoft.Extensions.DependencyInjection;
using System.Collections.Generic;
using WarehouseManagementApp.BLL;
using WarehouseManagementApp.DAL;
using WarehouseManagementApp.Models;

namespace WarehouseManagementApp.ViewModels
{
    public class ProductsViewModel
    {
        private readonly IProductService _productService;

        public ProductsViewModel()
        {
            _productService = (IProductService)App.ServiceProvider.GetService(typeof(IProductService));
        }

        public IEnumerable<Product> Products => _productService.GetAllProducts();

        public void AddProduct(string name, int quantity)
        {
            _productService.AddProduct(name, quantity);
        }

        public void UpdateProduct(int productId, string name, int quantity)
        {
            _productService.UpdateProduct(productId, name, quantity);
        }

        public void DeleteProduct(int productId)
        {
            _productService.DeleteProduct(productId);
        }
    }
}
