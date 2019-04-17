using MBookLibrary.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace MBookLibrary.Data.EF
{
    public class BookContext : DbContext
    {
        public BookContext()
        { }

        public BookContext(DbContextOptions<BookContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Book> Books { get; set; }

    }
}
