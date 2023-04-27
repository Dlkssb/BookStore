using BookStore.Domin.Commen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domin.Entity
{
    public class Rack : EntityBase
    {
        public List<Shelf> Shelves { get; set; }
    }
}
