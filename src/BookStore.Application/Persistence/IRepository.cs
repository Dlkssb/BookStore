using BookStore.Domin.Commen;
using System.Linq.Expressions;

namespace BookStore.Application.Persistence
{
    public interface IRepository<T> where T : EntityBase
    {
        Task<IReadOnlyList<T>> GetAllAsync();

        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate);

        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null,
                                            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                                string includeString = null,
                                                   bool disableTraking = true);

        Task<IReadOnlyList<T>> GetAsync(Expression<Func<T, bool>> predicate = null,
                                        Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                                                List<Expression<Func<T,bool>>> includeString = null,
                                                   bool disableTraking = true);

        Task<T> GetByIdAsync(Guid id);

        Task<T> AddAsync(T Entity);

        Task<T> UpdateAsync(T Entity);

        Task<T> DeleteAsync(T Entity);
    }
}
