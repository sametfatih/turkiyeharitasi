using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using bayi_harita.Models;

namespace bayi_harita
{
    public class BayiRepository
    {
        protected readonly bayiDbContext _context;

        public BayiRepository(bayiDbContext context)
        {
            _context = context;
        }

        public DbSet<Bayi> Table => _context.Set<Bayi>();

        public IQueryable<Bayi> GetAll(bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();
            return query;
        }

        public IQueryable<Bayi> GetWhere(Expression<Func<Bayi, bool>> filter, bool tracking = true)
        {
            var query = Table.Where(filter);
            if (!tracking)
                query = query.AsNoTracking();
            return query;
        }

        public async Task<Bayi> GetSingleAsync(Expression<Func<Bayi, bool>> filter, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = Table.AsNoTracking();
            return await query.FirstOrDefaultAsync(filter);
        }
        public async Task<Bayi> GetByIdAsync(int id, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = Table.AsNoTracking();
            return await query.FirstOrDefaultAsync(e => e.Id == id);
        }
        public async Task<bool> AddAsync(Bayi model)
        {
            EntityEntry<Bayi> entityEntry = await Table.AddAsync(model);
            return entityEntry.State == EntityState.Added;
        }

        public async Task<bool> AddRangeAsync(List<Bayi> models)
        {
            await Table.AddRangeAsync(models);
            return true;
        }

        public bool Remove(Bayi model)
        {
            EntityEntry<Bayi> entityEntry = Table.Remove(model);
            return entityEntry.State == EntityState.Deleted;
        }

        public bool RemoveRange(List<Bayi> models)
        {
            Table.RemoveRange(models);
            return true;
        }

        public async Task<bool> RemoveAsync(int id)
        {
            Bayi model = await Table.FirstOrDefaultAsync(entity => entity.Id == id);
            return Remove(model);
        }

        public bool Update(Bayi model)
        {
            EntityEntry entityEntry = Table.Update(model);
            return entityEntry.State == EntityState.Modified;
        }

        public async Task<int> SaveAsync()
            => await _context.SaveChangesAsync();
    }
}
