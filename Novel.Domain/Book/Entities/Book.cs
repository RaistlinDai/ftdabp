using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Auditing;
using Volo.Abp.Domain.Entities;

namespace Novel.Domain.Book.Entities;

/// <summary>
/// 书籍
/// </summary>
public class Book : Entity<Guid>, IHasCreationTime
{
    public string Name { get; set; }
    
    public string Description { get; set; }
    
    public Guid AuthorId { get; set; }
    
    public string? AuthorName { get; set; }
    
    public Guid CategoryId { get; set; }
    
    public string? CategoryName { get; set; }
    
    public List<Volume> Volumes { get; protected set; }

    public DateTime CreationTime { get; set; }

    protected Book()
    {
    }

    public Book(
        Guid bookId, 
        [NotNull]string name, 
        [NotNull]string description,
        Guid authorId, 
        [CanBeNull]string? authorName,
        Guid categoryId,
        [CanBeNull]string? categoryName)
    {
        Id = bookId;
        Name = Check.NotNullOrWhiteSpace(name, nameof(name));
        Description = Check.NotNullOrWhiteSpace(description, nameof(description));;
        AuthorId = authorId;
        AuthorName = authorName;
        CategoryId = categoryId;
        CategoryName = categoryName;
        
        Volumes = new List<Volume>();
    }

    public void AddVolume(Volume volume)
    {
        if (Volumes.Count != 0 && Volumes.Any(v => v.Title == volume.Title))
            return;
        
        Volumes.Add(volume);
    }
}