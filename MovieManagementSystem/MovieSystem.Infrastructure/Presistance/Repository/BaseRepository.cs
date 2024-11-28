using Microsoft.EntityFrameworkCore;
using MovieSystem.Application.Repository.Interface;
using MovieSystem.Infrastructure.Presistance.Data;
using System.Linq.Expressions;
 
namespace MovieSystem.Infrastructure.Presistance.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        protected readonly MovieContext _context;

        protected readonly DbSet<TEntity> _dbSet;

        public BaseRepository(MovieContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public IEnumerable<TEntity> GetAll() => _dbSet.AsNoTracking().ToList();
        
        public async Task<IEnumerable<TEntity>> GetAllAsync() => await _dbSet.AsNoTracking().ToListAsync();

        public TEntity GetById(int id)  
        {
            var Result =_dbSet.Find(id);
            _dbSet.Entry(Result).State = EntityState.Detached;
            return Result;
        }

        public async Task<TEntity> GetByIdAsync(int id)=> await _dbSet.FindAsync(id);

        public async Task<IEnumerable<TEntity>> GetAsync(
            Expression<Func<TEntity, bool>>? criteria =null,
            List<Expression<Func<TEntity, object>>>? includes = null)
        {
            //_context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            IQueryable<TEntity> query = _dbSet.AsNoTracking().AsQueryable();
            if (includes != null)
                foreach (var incluse in includes)
                    query = query.Include(incluse);
            if (criteria != null)
                return await query.Where(criteria).AsNoTracking().ToListAsync();

            return await query.AsNoTracking().ToListAsync();
        }

        public async Task<TEntity> GetEntityAsync(
            Expression<Func<TEntity, bool>>? criteria = null,
            List<Expression<Func<TEntity, object>>>? includes = null
            )
        {
        //  _context.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            IQueryable<TEntity> query = _dbSet.AsNoTracking().AsQueryable();
            if (includes != null)
                foreach (var incluse in includes)
                    query = query.Include(incluse);
            if (criteria != null)
                return await query.Where(criteria).AsNoTracking().FirstOrDefaultAsync();

                return await query.AsNoTracking().FirstOrDefaultAsync(); 
        }

        public TEntity GetBy(
            Expression<Func<TEntity, bool>> criteria, 
            string[]? includes = null)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> GetByAsync(Expression<Func<TEntity, bool>>? criteria, string[]? includes = null)
        {
            throw new NotImplementedException();
        }

        public void Add(TEntity entity)=> _context.Set<TEntity>().Add(entity);
 
        public async Task AddAsync(TEntity entity) => await _context.Set<TEntity>().AddAsync(entity);
  
        public async Task<TEntity> AddAsyncAndRetrieve(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            return entity;
        }

        public IEnumerable<TEntity> AddRange(IEnumerable<TEntity> entities)
        {
            _dbSet.AddRangeAsync(entities);
            return entities;
        }

        public async Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await _dbSet.AddRangeAsync(entities);
            return entities;
        }

        public void Delete(TEntity entity)=> _dbSet.Remove(entity);
 
        public void DeleteRange(IEnumerable<TEntity> entities)=> _dbSet.RemoveRange(entities);

        public void Update(TEntity entity) => _dbSet.Update(entity);
 
        public TEntity UpdateAndRetrieve(TEntity entity)
        {
            _dbSet.Update(entity);
            return entity;
        }

    }
}
