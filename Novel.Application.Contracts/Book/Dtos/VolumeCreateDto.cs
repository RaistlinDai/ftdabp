using Volo.Abp.Application.Dtos;

namespace Novel.Application.Contracts.Book.Dtos;

public class VolumeCreateDto : EntityDto
{
    public Guid BookId { get; set; }
    
    public string Title { get; set; }

    public string Description { get; set; }
    
    public virtual List<ChapterCreateDto> Chapters { get; set; }
}