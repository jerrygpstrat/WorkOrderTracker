using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using WebOrderTracker.DataLayer.Repositories.Interfaces;

namespace WebOrderTracker.DataLayer.Repositories
{
    // Generic Repository Implementation
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly DbContext Context;

        public Repository(DbContext context)
        {
            Context = context;
        }

        public async Task<TEntity?> GetByIdAsync(Guid id) => await Context.Set<TEntity>().FindAsync(id);

        public async Task<IEnumerable<TEntity>> GetAllAsync() => await Context.Set<TEntity>().ToListAsync();

        public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate) =>
            await Context.Set<TEntity>().Where(predicate).ToListAsync();

        public async Task AddAsync(TEntity entity) => await Context.Set<TEntity>().AddAsync(entity);

        public void Remove(TEntity entity) => Context.Set<TEntity>().Remove(entity);
    }
}
