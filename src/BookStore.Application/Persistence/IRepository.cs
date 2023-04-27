using BookStore.Domin.Commen;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace BookStore.Application.Persistence
{
    // IRepository interface
    // IRepository interface
    public interface IRepository<T> where T : class
    {
       Task<IEnumerable<T>> GetAll();
       Task< T >GetById(int id);
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(T entity);
    }
}
