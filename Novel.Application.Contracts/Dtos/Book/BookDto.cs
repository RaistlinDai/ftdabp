namespace Novel.Application.Contracts.Dtos.Book;

public class BookDto
{
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public Guid AuthorId { get; set; }
    
    public string? AuthorName { get; set; }
    
    public Guid CategoryId { get; set; }
    
    public string? CategoryName { get; set; }
    
    public List<VolumeDto> Volumes { get; protected set; }
}