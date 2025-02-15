using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using VirtualLibrary.Application.Persistence.Repositories;
using VirtualLibrary.Persistence.Contexts;

namespace VirtualLibrary.Persistence.Repositories
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly VirtualLibraryDbContext _context;
        protected DbSet<T> _dbSet;

        public GenericRepository(VirtualLibraryDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> All()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T?> GetById(int id)
        {
            var result = await _dbSet.FindAsync(id);
            return result;
        }

        public async Task<T> Add(T entity)
        {
            EntityEntry<T> result = await _dbSet.AddAsync(entity);
            return result.Entity;
        }

        public async Task<bool> Delete(int id)
        {
            T? entity = await GetById(id);

            if (entity == null) return false;

            _dbSet.Remove(entity);

            return true;
        }

        public void Update(T entity)
        {
            _dbSet.Update(entity);
        }
    }
}
