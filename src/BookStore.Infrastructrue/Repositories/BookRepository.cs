using BookStore.Application.Persistence;
using BookStore.Domin.Entity;
using BookStore.Infrastructrue.Presistince;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;

namespace BookStore.Infrastructrue.Repositories
{
    public class BookRepository : IRepository<Book>, IBookRepository
    {
        BookDbContext _context;
        public BookRepository(BookDbContext context) 
        {
            _context = context;
        }

        public async Task Add(Book entity)
        {
             _context.Books.FromSqlInterpolated($"EXEC [dbo].[AddBook] @Name = {entity.Name}, @Author = {entity.Author}, @IsAvailable = {entity.IsAvailable}, @Price = {entity.Price}, @ShelfId = {entity.ShelfId}");
            _context.SaveChangesAsync();
        }

        public async Task Delete(Book entity)
        {
            _context.Books.FromSqlInterpolated($"EXEC  [dbo].[IsAvailable_statue] @Id = {entity.Id}");
            _context.SaveChanges();
        }

        public async Task<List<Book>> GetAll()
        {
           var Books=await   _context.Books.FromSqlInterpolated($"EXEC [dbo].[GetAllBooks]").ToListAsync();
            return  Books;
        }

        public async Task<List<Book>> GetAvailableBooks()
        {
            
                return await _context.Books.Where(r => r.IsAvailable == true).ToListAsync();
            
        }

        public async Task<Book> GetById(int id)
        {
          var book= await  _context.Books.FromSqlInterpolated($"EXEC  [dbo].[GetBookById] @Id = {id}").ToListAsync();
            return  book.FirstOrDefault();
            
        }

        public async Task Update(Book entity)
        {
         _context.Books.FromSqlInterpolated($"EXEC [dbo].[UpdateBookById] @Id = {entity.Id}, @Name = {entity.Name}, @Author = {entity.Author}, @IsAvailable = {entity.IsAvailable}, @Price = {entity.Price}, @ShelfId = {entity.ShelfId}");
            _context.SaveChanges();
        }
    }

}
