using Microsoft.EntityFrameworkCore;
using Novel.Domain.Book.Entities;
using Novel.Domain.Book.Repository;
using Volo.Abp.Threading;

namespace Novel.EntityFrameworkCore.Extensions;

public static class BookRepositoryExtension
{
    /// <summary>
    /// 同步实现方法 - 根据ID查找Chapter
    /// </summary>
    /// <param name="repository"></param>
    /// <param name="id"></param>
    /// <param name="include"></param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    public static Chapter FindChapterById(
        this IBookRepository repository, 
        Guid id, 
        bool include = true,
        CancellationToken cancellationToken = default)
    {
        return AsyncHelper.RunSync(
            () => repository.FindChapterByIdAsync(id, include, cancellationToken));
    }
}