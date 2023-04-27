using BookStore.Domin.Commen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domin.Entity
{
    public class Book:EntityBase
    {
        public string Book_Name  { get; set; }
        public string Author { get; set; }
        public bool Is_Available { get; set; } 

        public decimal Price { get; set; }
        public Guid ShelfId { get; set; }
        public Shelf Shelf { get; set; }
    }
}
