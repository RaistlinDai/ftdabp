using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;

namespace Novel.Application.Contracts.Book.Dtos;

public class ChapterDto : EntityDto, IHasCreationTime
{
    public Guid VolumeId { get; set; }

    public virtual VolumeDto Volume { get; set; }

    public string Title { get; set; }

    public int WordsNumber { get; set; }

    public ChapterTextDto ChapterText { get; set; }
    
    public DateTime CreationTime { get; }
}