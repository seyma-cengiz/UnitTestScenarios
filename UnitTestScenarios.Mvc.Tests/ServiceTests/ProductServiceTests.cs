using Moq;
using UnitTestScenarios.Mvc.Entity;
using UnitTestScenarios.Mvc.Services;
using UnitTestScenarios.Mvc.Tests.Mocks;

namespace UnitTestScenarios.Mvc.Tests.ServiceTests
{
    [TestFixture]
    public class ProductServiceTests
    {
        private List<Product> products;
        private IProductService _productService;

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

            var mockContext = new Mock<ProductDbContext>();
            var unitOfWork = new UnitOfWork(mockContext.Object);
            var mockRepository = ProductRepositoryMock.GetMock(products);

            _productService = new ProductService(mockRepository.Object, unitOfWork);
        }

        [Test]
        public async Task GetAllAsync_Returns_AllProducts()
        {
            //Act
            var result = await _productService.GetAllAsync();
            //Assert
            Assert.That(result.Count, Is.EqualTo(products.Count));
        }
    }
}
