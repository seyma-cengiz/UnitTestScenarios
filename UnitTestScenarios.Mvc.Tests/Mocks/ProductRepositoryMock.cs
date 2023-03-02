using Moq;
using UnitTestScenarios.Mvc.Entity;
using UnitTestScenarios.Mvc.Repositories;

namespace UnitTestScenarios.Mvc.Tests.Mocks
{
    public class ProductRepositoryMock
    {
        public static Mock<IProductRepository> GetMock(List<Product> dataList)
        {
            var mock = new Mock<IProductRepository>();

            mock.Setup(t => t.GetAllAsync()).ReturnsAsync(() => dataList);

            return mock;
        }
    }
}
