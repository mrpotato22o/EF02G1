namespace ReadMoreBooks.Entities;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public string ISBN { get; set; } = null!;
    public decimal Price { get; set; }
    public int NumberOfPages { get; set; }
    public int YearPublished { get; set; }
    public bool InStock { get; set; }

    
    public int AuthorId { get; set; }
    public Author Author { get; set; } = null!;

    public int CategoryId { get; set; }
    public Category Category { get; set; } = null!;
}