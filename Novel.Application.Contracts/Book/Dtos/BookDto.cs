using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;

namespace Novel.Application.Contracts.Book.Dtos;

public class BookDto : EntityDto<Guid>, IHasCreationTime
{
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public Guid AuthorId { get; set; }
    
    public string? AuthorName { get; set; }
    
    public Guid CategoryId { get; set; }
    
    public string? CategoryName { get; set; }
    
    public List<VolumeDto> Volumes { get; protected set; }
    
    public DateTime CreationTime { get; }
}