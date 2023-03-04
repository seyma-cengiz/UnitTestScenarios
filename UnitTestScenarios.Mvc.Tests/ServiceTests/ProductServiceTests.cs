using Moq;
using UnitTestScenarios.Mvc.Entity;
using UnitTestScenarios.Mvc.Repositories;
using UnitTestScenarios.Mvc.Services;
using UnitTestScenarios.Mvc.Tests.Mocks;

namespace UnitTestScenarios.Mvc.Tests.ServiceTests
{
    [TestFixture]
    public class ProductServiceTests
    {
        private Product expectedResult;
        private List<Product> products;
        private IProductService _productService;
        private Mock<IProductRepository> _mockProductRepository;

        [SetUp]
        public void SetUp()
        {
            //Arrange
            products = new List<Product>()
            {
                new Product()
                {
                    Id = 1,
                    Name = "Test Product 1",
                    Price= 1
                },
                new Product()
                {
                    Id = 2,
                    Name = "Test Product 2",
                    Price= 2
                },
                new Product()
                {
                    Id = 3,
                    Name = "Test Product 3",
                    Price= 3
                }
            };

            expectedResult = new Product()
            {
                Id = 1,
                Name = "Test Product 1",
                Price = 1
            };

            var mockContext = new Mock<ProductDbContext>();
            var unitOfWork = new UnitOfWork(mockContext.Object);
            _mockProductRepository = ProductRepositoryMock.GetMock(products, expectedResult);

            _productService = new ProductService(_mockProductRepository.Object, unitOfWork);
        }

        [Test]
        public async Task GetAllAsync_WhenCalled_ReturnsAllProducts()
        {
            //Act
            var result = await _productService.GetAllAsync();
            //Assert
            _mockProductRepository.Verify(t => t.GetAllAsync(), Times.AtLeastOnce);
            Assert.That(result.Count, Is.EqualTo(products.Count));
        }

        [Test]
        public async Task GetAsync_WhenCalled_ReturnsSingleProduct()
        {
            //Act
            var result = await _productService.GetAsync(expectedResult.Id);
            //Assert
            _mockProductRepository.Verify(t => t.GetAsync(It.IsAny<int>()), Times.AtLeastOnce);
            Assert.That(result.Id, Is.EqualTo(expectedResult.Id));
            Assert.That(result.Name, Is.EqualTo(expectedResult.Name));
        }

        [Test]
        public void Add_WhenCalled_AddsProduct()
        {
            //Act
            var result = _productService.Add(expectedResult);
            //Assert
            _mockProductRepository.Verify(t => t.Add(It.IsAny<Product>()), Times.Once);
            Assert.That(result.Id, Is.EqualTo(expectedResult.Id));
            Assert.That(result.Name, Is.EqualTo(expectedResult.Name));
        }

        [Test]
        public void Update_WhenCalled_UpdatesProduct()
        {
            //Act
            _productService.Update(expectedResult);
            //Assert
            _mockProductRepository.Verify(t => t.Update(It.IsAny<Product>()), Times.AtLeastOnce);
        }

        [Test]
        public void Delete_WhenCalled_DeletesProduct()
        {
            //Act
            _productService.Delete(expectedResult);
            //Assert
            _mockProductRepository.Verify(t => t.Delete(It.IsAny<Product>()), Times.AtLeastOnce);
        }
    }
}
