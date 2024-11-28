using System.Linq.Expressions;


namespace MovieSystem.Application.Repository.Interface
{
    public interface IBaseRepository<TEntity> where TEntity : class
    {

        // GET ALL
        IEnumerable<TEntity> GetAll();
        Task<IEnumerable<TEntity>> GetAllAsync();
        // GET BY
        TEntity GetById(int id);
        Task<TEntity> GetByIdAsync(int id);


        // GET BY with criteria
        TEntity GetBy(Expression<Func<TEntity, bool>> criteria, string[]? includes = null);
        // GET   with includes
        public Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>>? criteria =null,
                    List<Expression<Func<TEntity, object>>>? includeProperties = null
                    );
        public Task<TEntity> GetEntityAsync(Expression<Func<TEntity, bool>>? criteria = null,
            List<Expression<Func<TEntity, object>>>? includeProperties = null
            );



        Task<TEntity> GetByAsync(Expression<Func<TEntity, bool>>? criteria, string[]? includes = null);
        //TEntity Find(Expression<Func<TEntity, bool>> criteria, string[] includes = null);
        // Add
        void Add(TEntity entity);
        Task AddAsync(TEntity entity);
        Task<TEntity> AddAsyncAndRetrieve(TEntity entity);
        // Add Range
        IEnumerable<TEntity> AddRange(IEnumerable<TEntity> entities);
        Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities);
        // Update
        void Update(TEntity entity);
        //Task UpdateAsync(TEntity entity);
        TEntity UpdateAndRetrieve(TEntity entity);
        // Delete
        void Delete(TEntity entity);
        //Task DeleteRange;
        void DeleteRange(IEnumerable<TEntity> entities);

    }
}
