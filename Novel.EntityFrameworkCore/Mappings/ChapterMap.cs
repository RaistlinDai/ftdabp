using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Novel.Domain.Book.Entities;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Novel.EntityFrameworkCore.Mappings;

public class ChapterMap : IEntityTypeConfiguration<Chapter>
{
    public void Configure(EntityTypeBuilder<Chapter> builder)
    {
        builder.ToTable(nameof(Chapter));
        builder.ConfigureByConvention();
        builder.HasOne(chapter => chapter.ChapterText)
            .WithOne(text => text.Chapter)
            .HasForeignKey<ChapterText>(text => text.Id);
    }
}