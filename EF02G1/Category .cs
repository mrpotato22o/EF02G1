namespace ReadMoreBooks.Entities;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Description { get; set; } = null!;
    public bool IsActive { get; set; }

    // One category has many books
    public ICollection<Book> Books { get; set; } = new List<Book>();
}