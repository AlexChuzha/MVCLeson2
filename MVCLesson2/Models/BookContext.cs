using System.Data.Entity;

    public class BookContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

    }