using BookStore.Application.Persistence;
using BookStore.Domin.Entity;
using BookStore.Infrastructrue.Presistince;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Infrastructrue.Repositories
{
    public class BookRepository : IRepository<Book>
    {
      private readonly  BookDbContext _context;

        public BookRepository(BookDbContext context)
        {
            _context = context;
        }
        public async Task<Book> AddAsync(Book Entity)
        {
            if (Entity != null)
            {
                var name = new SqlParameter("@Name", Entity.Book_Name);
                var author = new SqlParameter("@Author", Entity.Author);
                var isAvailable = new SqlParameter("@IsAvailable", Entity.Is_Available);
                var price = new SqlParameter("@Price", Entity.Price);
                var shelfId = new SqlParameter("@ShelfId", Entity.ShelfId);

                _context.Books.FromSqlInterpolated($"EXECUTE CreateBook {Entity.Book_Name}, {Entity.Author}, {Entity.Is_Available}, {Entity.Price}, {Entity.ShelfId}");
                _context.SaveChanges();
                return Entity;
            }

            else
            {
                throw new Exception("Can't add the book");
            }
        }


        public async Task<Book> DeleteAsync(Book Entity)
        {
            _context.Books.FromSqlInterpolated($"EXECUTE DeleteBook {Entity.Id}");
            _context.SaveChanges();
            return Entity;
        }

        public async Task<IReadOnlyList<Book>> GetAllAsync()
        {
            
            return await  _context.Books.ToListAsync();
        }

       

        public async Task<Book> GetByIdAsync(Guid id)
        {
            return   _context.Books.FromSqlInterpolated($"EXECUTE GetBookById {id}").FirstOrDefault();
        }

        public async Task<Guid> UpdateAsync(Book Entity)
        {
            _context.Books.FromSqlInterpolated($"EXECUTE UpdateBook {Entity.Id}, {Entity.Book_Name}, {Entity.Author}, {Entity.Is_Available}, {Entity.Price}, {Entity.ShelfId}");
            _context.SaveChanges();
            return Entity.Id;
        }
    }
}
