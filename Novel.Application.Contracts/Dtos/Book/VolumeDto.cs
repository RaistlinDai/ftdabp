using Volo.Abp.Application.Dtos;

namespace Novel.Application.Contracts.Dtos.Book;

public class VolumeDto : EntityDto
{
    public virtual BookDto book { get; set; }
    
    public Guid BookId { get; set; }
    
    public string Title { get; set; }

    public string Description { get; set; }
    
    public virtual List<ChapterDto> Chapters{ get; set; }
}