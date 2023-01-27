using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Entities;

namespace Novel.Domain.Category.Entities;

public class Category : Entity<Guid>
{
    public string Name { get; set; }

    protected Category()
    {
    }

    public Category(
        Guid guid,
        [NotNull] string name)
    {
        Id = guid;
        Name = Check.NotNullOrWhiteSpace(name, nameof(name));
    }
}