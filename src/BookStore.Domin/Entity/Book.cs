
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domin.Entity
{
    public class Book
    {
        [Key]
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public bool IsAvailable { get; set; }
        public decimal Price { get; set; }
       
        public int ShelfId { get; set; }
        public  Shelf Shelf { get; set; }
    }
}
