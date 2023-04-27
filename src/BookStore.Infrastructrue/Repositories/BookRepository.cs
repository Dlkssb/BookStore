using BookStore.Application.Persistence;
using BookStore.Domin.Entity;
using BookStore.Infrastructrue.Presistince;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;

namespace BookStore.Infrastructrue.Repositories
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(BookDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Book>> GetAvailableBooks()
        {
            return  _dbSet.Where(b => b.IsAvailable);
        }
    }

}
