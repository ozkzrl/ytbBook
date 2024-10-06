using Microsoft.EntityFrameworkCore;

namespace ytBookStore.Models.Domain
{
    public class DatabaseContext:DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            
        }

        public DbSet<Genre> Genre { set; get; }

        public DbSet<Author> Author { set; get; }

        public DbSet<Publisher> Publisher { set; get; }
        public DbSet<Book> Books { set; get; }




    }
}
