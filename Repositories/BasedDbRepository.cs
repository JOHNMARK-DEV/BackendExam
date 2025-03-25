
using BackendExam.Contracts;
using BackendExam.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System.Reflection;

namespace BackendExam.Repositories
{

    public class BasedDbRepository<T> : IBasedDbRepository<T> where T : class, new()
    { 
        private ApplicationDbContext _context;  

        public BasedDbRepository(ApplicationDbContext dbContext)
        {

            _context = dbContext;
        }


        public virtual T Add(T entity)
        {
            _context.Set<T>().Add(entity); 

            return entity;

        }


        public virtual T Update(T entity)
        {

            _context.Set<T>().Update(entity); 

            return entity;
        }


        public virtual T Delete(Guid id)
        {
             
            var entity = _context.Set<T>().Find(id);

            if (entity == null)
            {
                return null;  
            }
             
            _context.Set<T>().Remove(entity);

            return entity;
        }


        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return (IEnumerable<T>)await _context.Set<T>().ToListAsync();
        }

        public virtual async Task<T> GetOne(Guid id)
        {
            T data =  await _context.Set<T>().FindAsync(id);
            return data;
        }
    }
}
