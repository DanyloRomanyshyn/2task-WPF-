using WarehouseManagementApp.DAL;
using WarehouseManagementApp.Models;
using System.Collections.Generic;

namespace WarehouseManagementApp.BLL
{
    public class ProductService : IProductService
    {
        private readonly ProductsRepository _repository;

        public IEnumerable<Product> GetAllProducts()
        {
            return _repository.GetAll();
        }


        public ProductService(ProductsRepository repository)
        {
            _repository = repository;
        }

        public void AddProduct(string name, int quantity)
        {
            _repository.Add(name, quantity);
        }

        public void UpdateProduct(int productId, string name, int quantity)
        {
            _repository.Update(productId, name, quantity);
        }

        public void DeleteProduct(int productId)
        {
            _repository.Delete(productId);
        }

        public Product GetProductById(int productId)
        {
            return _repository.GetById(productId);
        }
    }

}
