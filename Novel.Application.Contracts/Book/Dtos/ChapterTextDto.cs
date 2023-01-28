using Volo.Abp.Application.Dtos;

namespace Novel.Application.Contracts.Book.Dtos;

public class ChapterTextDto : EntityDto<Guid>
{
    public Guid ChapterId { get; set; }
    
    public virtual ChapterDto Chapter { get; set; }
    
    public string Content { get; set; }
    
    public string? AuthorMessage { get; set; }
}