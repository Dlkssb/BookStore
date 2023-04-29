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
    public class RackRepository : Repository<Rack>, IRackRepository
    {
        public RackRepository(BookDbContext context) : base(context)
        {
        }

        public async Task<List<Rack>> GetRacksByShelf(int Code)
        {
            return await _dbSet.Where(r => r.Code == Code).ToListAsync();
        }
    }
}
