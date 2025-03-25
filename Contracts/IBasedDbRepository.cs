namespace BackendExam.Contracts
{
    public interface IBasedDbRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetOne(Guid id);
        T Add(T entity);
        T Update(T entity);
        T Delete(Guid entity);
    }
}
