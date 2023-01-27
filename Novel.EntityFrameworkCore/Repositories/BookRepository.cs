using Novel.Domain.Book.Entities;
using Novel.Domain.Book.Repository;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Novel.EntityFrameworkCore.Extensions;

namespace Novel.EntityFrameworkCore.Repositories;

/// <summary>
/// IBookRepository实现类
/// </summary>
public class BookRepository : EfCoreRepository<NovelDbContext, Book, Guid>, IBookRepository
{
    public BookRepository(IDbContextProvider<NovelDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }

    /// <summary>
    /// 异步实现方法 - 根据ID查找Chapter
    /// </summary>
    /// <param name="id"></param>
    /// <param name="include"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public async Task<Chapter> FindChapterByIdAsync(Guid id, bool include = true, CancellationToken cancellationToken = default)
    {
        var result = await DbContext.Chapters
            .IncludeIf(include, chapter => chapter.ChapterText)
            .FirstOrDefaultAsync(
                chapter => chapter.Id == id,
                GetCancellationToken(cancellationToken));
        return result;
    }
}