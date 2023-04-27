using BookStore.Domin.Commen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domin.Entity
{
    public class Shelf :EntityBase
    {
        public Guid RackId { get; set; }
        public  Rack Racks { get; set; }

        public List<Book> Books { get; set; }
    }
}
