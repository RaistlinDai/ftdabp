using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace Novel.Domain.Author.Entities;

public class Author : Entity<Guid>
{
    public string Name { get; set; }

    public string Description { get; set; }

    protected Author()
    {
    }

    public Author(Guid guid, [NotNull] string name, [CanBeNull]string description)
    {
        Id = guid;
        Name = Check.NotNullOrWhiteSpace(name, nameof(name));
        Description = description;
    }
}