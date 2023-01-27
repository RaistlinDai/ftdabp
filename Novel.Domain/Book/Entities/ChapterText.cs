using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace Novel.Domain.Book.Entities;

public class ChapterText : Entity<Guid>
{
    public Guid ChapterId { get; set; }
    public virtual Chapter Chapter { get; set; }
    
    public string Content { get; set; }
    
    public string? AuthorMessage { get; set; }

    protected ChapterText()
    {
        
    }

    public ChapterText(
        [NotNull] string content,
        [CanBeNull]string? authorMessage)
    {
        Content = Check.NotNullOrWhiteSpace(content, nameof(content));
        AuthorMessage = authorMessage;
    }
}