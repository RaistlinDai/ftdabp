using Volo.Abp.Application.Dtos;

namespace Novel.Application.Contracts.Book.Dtos;

public class ChapterTextCreateDto : EntityDto
{
    public Guid ChapterId { get; set; }
    
    public string Content { get; set; }
    
    public string? AuthorMessage { get; set; }
}