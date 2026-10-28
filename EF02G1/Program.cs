using Microsoft.EntityFrameworkCore;
using ReadMoreBooks.Data;
using ReadMoreBooks.Entities;

using var context = new BookstoreContext();

// 1) Create the database 
context.Database.EnsureDeleted();
context.Database.EnsureCreated();
Console.WriteLine("Database created.\n");

// 2) Insert sample data
var fiction = new Category { Name = "Fiction", Description = "Novels and short stories", IsActive = true };
var science = new Category { Name = "Science", Description = "Popular science books", IsActive = false };

var author = new Author
{
    FirstName = "George",
    LastName = "Orwell",
    Email = "george.orwell@example.com",
    Biography = "English novelist and essayist.",
    DateOfBirth = new DateOnly(1903, 6, 25)
};

context.Books.Add(new Book
{
    Title = "1984",
    ISBN = "9780451524935",
    Price = 12.99m,
    NumberOfPages = 328,
    YearPublished = 1949,
    InStock = true,
    Author = author,
    Category = fiction
});
context.Categories.Add(science);
context.SaveChanges();

// 3) Prove the schema
Console.WriteLine("=== Tables & columns in SQL Server ===");
var conn = context.Database.GetDbConnection();
conn.Open();
using (var cmd = conn.CreateCommand())
{
    cmd.CommandText = @"SELECT TABLE_NAME, COLUMN_NAME, DATA_TYPE, IS_NULLABLE
                        FROM INFORMATION_SCHEMA.COLUMNS
                        WHERE TABLE_NAME IN ('Books','Authors','Categories')
                        ORDER BY TABLE_NAME, ORDINAL_POSITION";
    using var reader = cmd.ExecuteReader();
    string current = "";
    while (reader.Read())
    {
        var table = reader.GetString(0);
        if (table != current) { Console.WriteLine($"\n[{table}]"); current = table; }
        Console.WriteLine($"  {reader.GetString(1),-15} {reader.GetString(2),-10} nullable: {reader.GetString(3)}");
    }
}
conn.Close();

// 4) Prove the relationships
Console.WriteLine("\n=== Books (with Author & Category) ===");
foreach (var b in context.Books.Include(b => b.Author).Include(b => b.Category))
{
    Console.WriteLine($"{b.Title} | {b.Author.FirstName} {b.Author.LastName} | {b.Category.Name} | ${b.Price} | In stock: {b.InStock}");
}

Console.WriteLine($"\nCategories: {context.Categories.Count()} | Authors: {context.Authors.Count()} | Books: {context.Books.Count()}");