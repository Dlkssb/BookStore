using BookStore.Domin.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Infrastructrue.Presistince
{
    public class BookDbContext :DbContext
    {

        public BookDbContext(DbContextOptions<BookDbContext> options):base(options)
        {

        }

      public  DbSet<Book> Books { get; set; }

        public  DbSet<Shelf> Shelves { get; set; }
        public  DbSet<Rack> Racks { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Shelf>().HasOne(x => x.Rack).WithMany().HasForeignKey(x => x.RackId).IsRequired();


            modelBuilder.Entity<Book>().HasOne(x => x.Shelf).WithMany().HasForeignKey(x => x.ShelfId).IsRequired();

     




        }

    }
}
