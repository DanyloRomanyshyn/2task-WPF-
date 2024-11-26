using System.Collections.Generic;
using WarehouseManagementApp.DAL;
using WarehouseManagementApp.Models;


namespace WarehouseManagementApp.BLL
{
    public interface IProductService
    {
        IEnumerable<Product> GetAllProducts();

        void AddProduct(string name, int quantity);
        void UpdateProduct(int productId, string name, int quantity);
        void DeleteProduct(int productId);
        Product GetProductById(int productId);
    }


}
