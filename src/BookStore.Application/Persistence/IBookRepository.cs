using BookStore.Domin.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.Persistence
{
    public interface IBookRepository : IRepository<Book>
    {
       Task< IEnumerable<Book>> GetAvailableBooks();
    }
}
