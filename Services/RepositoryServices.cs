using BackendExam.Data;
using BackendExam.Models;
using BackendExam.Repositories;  

namespace BackendExam.Services
{
    public class RepositoryServices
    {

        private ApplicationDbContext _context;
        public RepositoryServices(ApplicationDbContext context)
        {
            _context = context;
        }

        public BasedDbRepository<ProductModel> ProductRepository => new BasedDbRepository<ProductModel>(_context);
         

    }
}
