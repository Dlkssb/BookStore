using BookStore.Application.Persistence;
using BookStore.Infrastructrue.Presistince;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Infrastructrue.Repositories
{
    // Repository implementation
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly BookDbContext _context;
        protected readonly DbSet<T> _dbSet;

        public Repository(BookDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task< IEnumerable<T> >GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task <T> GetById(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task  Add(T entity)
        {
           await _dbSet.AddAsync(entity);
            _context.SaveChanges();
        }

        public async Task  Update(T entity)
        {
            _dbSet.Update(entity);
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public async Task  Delete(T entity)
        {
            _dbSet.Remove(entity);
            _context.SaveChanges();
        }
    }
}
