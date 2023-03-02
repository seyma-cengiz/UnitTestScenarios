namespace UnitTestScenarios.Mvc
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ProductDbContext _context;

        public UnitOfWork(ProductDbContext context)
        {
            _context = context;
        }

        public void Commit()
        {
            _context.SaveChanges();
        }
    }
}