using Volo.Abp.Application.Dtos;

namespace Novel.Application.Contracts.Dtos.Book;

public class ChapterTextCreateDto : EntityDto
{
    public virtual ChapterDto Chapter { get; set; }
    
    public string Content { get; set; }
    
    public string? AuthorMessage { get; set; }
}