using Moq;
using UnitTestScenarios.Mvc.Entity;
using UnitTestScenarios.Mvc.Repositories;

namespace UnitTestScenarios.Mvc.Tests.Mocks
{
    public class ProductRepositoryMock
    {
        public static Mock<IProductRepository> GetMock(List<Product> dataList, Product expectedResult)
        {
            var mock = new Mock<IProductRepository>();

            mock.Setup(t => t.GetAllAsync()).ReturnsAsync(() => dataList);
            mock.Setup(t => t.GetAsync(It.IsAny<int>())).ReturnsAsync(() => expectedResult);
            mock.Setup(t => t.Add(It.IsAny<Product>()));
            mock.Setup(t => t.Update(It.IsAny<Product>()));
            mock.Setup(t => t.Delete(It.IsAny<Product>()));

            return mock;
        }
    }
}
