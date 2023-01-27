using Volo.Abp.Application.Dtos;

namespace Novel.Application.Contracts.Dtos.Book;

public class ChapterDto : EntityDto
{
    public Guid VolumeId { get; set; }

    public virtual VolumeDto Volume { get; set; }

    public string Title { get; set; }

    public int WordsNumber { get; set; }

    public ChapterTextDto ChapterText { get; set; }
}