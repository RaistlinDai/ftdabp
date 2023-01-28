using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;

namespace Novel.Application.Contracts.Book.Dtos;

public class VolumeDto : EntityDto<Guid>, IHasCreationTime
{
    public virtual BookDto Book { get; set; }
    
    public Guid BookId { get; set; }
    
    public string Title { get; set; }

    public string Description { get; set; }
    
    public virtual List<ChapterDto> Chapters { get; set; }
    
    public DateTime CreationTime { get; }
}