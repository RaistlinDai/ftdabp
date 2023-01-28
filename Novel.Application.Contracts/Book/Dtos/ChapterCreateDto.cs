using Volo.Abp.Application.Dtos;

namespace Novel.Application.Contracts.Book.Dtos;

public class ChapterCreateDto : EntityDto
{
    public Guid VolumeId { get; set; }

    public string Title { get; set; }

    public int WordsNumber { get; set; }

    public ChapterTextCreateDto ChapterText { get; set; }
}