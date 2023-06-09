﻿using BookStore.Domin.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.Persistence
{
    public interface IRackRepository : IRepository<Rack>
    {
        Task<List<Rack>> GetRacksByShelf(int shelfId);
    }
}
