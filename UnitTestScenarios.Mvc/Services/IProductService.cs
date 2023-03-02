﻿using UnitTestScenarios.Mvc.Entity;

namespace UnitTestScenarios.Mvc.Services
{
    public interface IProductService
    {
        Task<List<Product>> GetAllAsync();

        Task<Product> GetAsync(long id);

        Product Add(Product entity);

        void Update(Product entity);

        void Delete(Product entity);

    }
}
