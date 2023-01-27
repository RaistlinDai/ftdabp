using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Novel.Domain.Author.Entities;
using Novel.Domain.Book.Entities;
using Novel.Domain.Category.Entities;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Novel.EntityFrameworkCore;

/// <summary>
/// 数据上下文
/// </summary>
[ConnectionStringName("Novel")]
public class NovelMigurationDbContext : AbpDbContext<NovelMigurationDbContext>
{
    public DbSet<Author> Authors { get; set; }
    
    public DbSet<Category> Categories { get; set; }
    
    public DbSet<Book> Books { get; set; }
    public DbSet<Volume> Volumes { get; set; }
    public DbSet<Chapter> Chapters { get; set; }
    public DbSet<ChapterText> ChapterTexts { get; set; }

    public NovelMigurationDbContext(DbContextOptions<NovelMigurationDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        // 扫描所有IEntityTypeConfiguration接口实现类
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}