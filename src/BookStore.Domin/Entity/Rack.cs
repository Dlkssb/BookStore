using BookStore.Domin.Commen;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Domin.Entity
{
    // Rack entity
    public class Rack
    {
        [Key]
        public int Id { get; set; }
        public int Code { get; set; }
        public  ICollection<Shelf> Shelves { get; set; }
    }
}
