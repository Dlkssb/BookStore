using BookStore.Domin.Commen;
using System.Linq.Expressions;

namespace BookStore.Application.Persistence
{
    public interface IRepository<T> where T : EntityBase
    {
        Task<IReadOnlyList<T>> GetAllAsync();

        Task<T> GetByIdAsync(Guid id);

        Task<T> AddAsync(T Entity);

        Task<Guid> UpdateAsync(T Entity);

        Task<T> DeleteAsync(T Entity);
    }
}
