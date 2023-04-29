using BookStore.Application.Persistence;
using BookStore.Domin.Entity;
using BookStore.Infrastructrue.Presistince;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Infrastructrue.Repositories
{
    public class ShelfRepository : Repository<Shelf>, IShelfRepository
    {
        public ShelfRepository(BookDbContext context) : base(context)
        {
        }

        public async Task<List<Shelf>> GetShelvesByRack(int rackId)
        {
            return await _dbSet.Where(s => s.RackId == rackId).ToListAsync();
        }
    }
}
