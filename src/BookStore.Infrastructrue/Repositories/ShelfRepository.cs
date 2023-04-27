using BookStore.Application.Persistence;
using BookStore.Domin.Entity;
using BookStore.Infrastructrue.Presistince;
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

        public async Task<IEnumerable<Shelf>> GetShelvesByRack(int rackId)
        {
            return _dbSet.Where(s => s.RackId == rackId);
        }
    }
}
