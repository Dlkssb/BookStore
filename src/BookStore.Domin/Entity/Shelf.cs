
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domin.Entity
{
    // Shelf entity
    public class Shelf
    {
        [Key]
        public int Id { get; set; }
        public int Code { get; set; }
        
        public int RackId { get; set; }
        public  Rack Rack { get; set; }
        public  ICollection<Book> Books { get; set; }
    }
}
