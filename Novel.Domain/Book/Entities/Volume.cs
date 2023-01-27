using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;

namespace Novel.Domain.Book.Entities;

public class Volume : Entity<Guid>, IHasCreationTime
{
    public virtual Book book { get; set; }
    
    public Guid BookId { get; set; }
    
    public string Title { get; set; }

    public string Description { get; set; }
    
    public virtual List<Chapter> Chapters{ get; set; }

    public DateTime CreationTime { get; set; }
    
    protected Volume()
    {
    }

    public Volume([NotNull]string title, [CanBeNull]string description)
    {
        Title = Check.NotNullOrWhiteSpace(title, nameof(title));
        Description = description;
        Chapters = new List<Chapter>();
    }

    public void AddChapter(Chapter chapter)
    {
        if (Chapters.Count != 0 && Chapters.Any(v => v.Title == chapter.Title))
        {
            return;
        }
        Chapters.Add(chapter);
    }
}