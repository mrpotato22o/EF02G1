namespace ReadMoreBooks.Entities;

public class Author
{
    public int Id { get; set; }                      // PK 
    public string FirstName { get; set; } = null!;   //  NOT NULL
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Biography { get; set; } = null!;
    public DateOnly DateOfBirth { get; set; }       

    // One author has many books
    public ICollection<Book> Books { get; set; } = new List<Book>();
}