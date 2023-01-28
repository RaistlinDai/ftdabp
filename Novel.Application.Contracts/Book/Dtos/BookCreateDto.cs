using Volo.Abp.Application.Dtos;

namespace Novel.Application.Contracts.Book.Dtos;

public class BookCreateDto : EntityDto
{
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public Guid AuthorId { get; set; }
    
    public string? AuthorName { get; set; }
    
    public Guid CategoryId { get; set; }
    
    public string? CategoryName { get; set; }
    
    public List<VolumeCreateDto> Volumes { get; protected set; } 
}