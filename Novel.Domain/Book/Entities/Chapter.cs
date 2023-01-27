using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;

namespace Novel.Domain.Book.Entities;

public class Chapter : Entity<Guid>, IHasCreationTime
{
    public Guid VolumeId { get; set; }

    public virtual Volume Volume { get; set; }
    
    public string Title { get; set; }
    
    public int WordsNumber { get; set; }
    
    public ChapterText ChapterText { get; set; }
    
    public DateTime CreationTime { get; }

    protected Chapter()
    {
        
    }

    public Chapter(
        [NotNull] string title,
        [NotNull] string content,
        [CanBeNull] string? authorMessage
        )
    {
        Title = Check.NotNullOrWhiteSpace(title, nameof(title));
        WordsNumber = content.Length;
        ChapterText = new ChapterText(content, authorMessage);
    }
}