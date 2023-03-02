using UnitTestScenarios.Mvc.Entity;
using UnitTestScenarios.Mvc.Repositories;

namespace UnitTestScenarios.Mvc.Services
{
    public class ProductService : IProductService
    {
        public IUnitOfWork _unitOfWork { get; private set; }
        private readonly IProductRepository _repository;
        public ProductService(IProductRepository repository, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _repository = repository;
        }

        public async Task<List<Product>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Product> GetAsync(long id)
        {
            return await _repository.GetAsync(id);
        }

        public Product Add(Product entity)
        {
            _repository.Add(entity);
            _unitOfWork.Commit();

            return entity;
        }

        public void Update(Product entity)
        {
            _repository.Update(entity);
            _unitOfWork.Commit();
        }

        public void Delete(Product entity)
        {
            _repository.Delete(entity);
            _unitOfWork.Commit();
        }
    }
}
