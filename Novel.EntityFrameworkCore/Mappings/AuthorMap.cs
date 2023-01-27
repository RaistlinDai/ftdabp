using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Novel.Domain.Author.Entities;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace Novel.EntityFrameworkCore.Mappings;

public class AuthorMap : IEntityTypeConfiguration<Author>
{
    public void Configure(EntityTypeBuilder<Author> builder)
    {
        builder.ToTable(nameof(Author));
        builder.ConfigureByConvention();
        builder.Property(author => author.Name)
            .IsRequired()
            .HasMaxLength(20);
    }
}