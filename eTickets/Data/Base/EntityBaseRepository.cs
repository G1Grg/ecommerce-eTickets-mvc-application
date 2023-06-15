using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace eTickets.Data.Base
{
    // this is an actual base repository. It is a generic one

    public class EntityBaseRepository<T> : IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        // inject AppDbContext
        private readonly AppDbContext _context;
        public EntityBaseRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _context.Set<T>().FirstOrDefaultAsync(n => n.Id == id);
#pragma warning disable CS8604 // Possible null reference argument.
            EntityEntry entityEntry = _context.Entry<T>(entity);
#pragma warning restore CS8604 // Possible null reference argument.
            entityEntry.State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<T>> GetAllAsync() => await _context.Set<T>().ToListAsync();

        public async Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();
            query = includeProperties.Aggregate(query, (current, includeProperties) => current.Include(includeProperties));
            return await query.ToListAsync();
        }

#pragma warning disable CS8603 // Possible null reference return.
        public async Task<T> GetByIdAsync(int id)=>await _context.Set<T>().FirstOrDefaultAsync(n => n.Id == id);
#pragma warning restore CS8603 // Possible null reference return.

        public async Task UpdateAsync(int id, T entity)
        {
            EntityEntry entityEntry = _context.Entry<T>(entity);
            entityEntry.State = EntityState.Modified;

            await _context.SaveChangesAsync();

        }
    }
}
