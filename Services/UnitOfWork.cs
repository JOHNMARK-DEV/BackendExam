
using BackendExam.Contracts;
using BackendExam.Data; 
using Microsoft.EntityFrameworkCore.Storage; 

namespace BackendExam.Services
{
    public class UnitOfWork :  RepositoryServices, IUnitOfWork
    {

        public ApplicationDbContext _dbContext;
        private IDbContextTransaction _transaction;

        public UnitOfWork(ApplicationDbContext dbContext) :base(dbContext) {

            _dbContext = dbContext;
            _transaction = _dbContext.Database.BeginTransaction();
        } 
        public Boolean SaveChanges()
        { 
            try
            {  
                _dbContext.SaveChanges();
                _transaction.Commit();  

                return true;
            }
            catch (Exception ex)
            {
                _transaction.Rollback();

                return false;  
            }
             
        }

    }
}
