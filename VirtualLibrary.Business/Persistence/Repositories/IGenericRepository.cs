
namespace VirtualLibrary.Application.Persistence.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<IEnumerable<T>> All();
        Task<T> GetById(int id);
        Task<T> Add(T entity);
        Task<bool> Delete(int id);
        void Update(T entity);
    }
}
