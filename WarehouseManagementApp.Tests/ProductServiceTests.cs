using Moq;
using WarehouseManagementApp.BLL;
using WarehouseManagementApp.DAL;
using WarehouseManagementApp.Models;
using Xunit;
using System.Collections.Generic;

namespace WarehouseManagementApp.Tests
{
    public class ProductServiceTests
    {
        private readonly Mock<IProductsRepository> _mockRepository;
        private readonly ProductService _productService;

        public ProductServiceTests()
        {
            _mockRepository = new Mock<IProductsRepository>();
            _productService = new ProductService(_mockRepository.Object);
        }

        [Fact]
        public void GetProductById_ReturnsProduct()
        {
            // Arrange
            var productId = 1;
            var expectedProduct = new Product { ProductId = productId, Name = "Test Product", Quantity = 10 };
            _mockRepository.Setup(repo => repo.GetProductById(productId)).Returns(expectedProduct);

            // Act
            var result = _productService.GetProductById(productId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedProduct.ProductId, result.ProductId);
            Assert.Equal(expectedProduct.Name, result.Name);
        }

        [Fact]
        public void GetAllProducts_ReturnsListOfProducts()
        {
            // Arrange
            var expectedProducts = new List<Product>
            {
                new Product { ProductId = 1, Name = "Product1", Quantity = 5 },
                new Product { ProductId = 2, Name = "Product2", Quantity = 10 }
            };
            _mockRepository.Setup(repo => repo.GetAll()).Returns(expectedProducts);

            // Act
            var result = _productService.GetAllProducts();

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedProducts.Count, result.Count);
        }
    }
}
