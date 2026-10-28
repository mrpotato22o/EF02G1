using Microsoft.EntityFrameworkCore;
using ReadMoreBooks.Entities;

namespace ReadMoreBooks.Data;

public class BookstoreContext : DbContext
{
    // Each DbSet<T> becomes a table (Books, Authors, Categories)
    public DbSet<Book> Books => Set<Book>();
    public DbSet<Author> Authors => Set<Author>();
    public DbSet<Category> Categories => Set<Category>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // SQL Server LocalDB 
        optionsBuilder.UseSqlServer(
            @"Server=(localdb)\MSSQLLocalDB;Database=ReadMoreBooksDb;Trusted_Connection=True;TrustServerCertificate=True;");
    }

    
}