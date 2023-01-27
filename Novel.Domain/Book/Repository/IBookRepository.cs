using Novel.Domain.Book.Entities;
using Volo.Abp.Domain.Repositories;

namespace Novel.Domain.Book.Repository;

/// <summary>
/// IBookRepository扩展实现类
/// </summary>
public interface IBookRepository : IRepository<Entities.Book, Guid>
{
    /// <summary>
    /// 根据ID查找Chapter
    /// </summary>
    /// <param name="id">主键</param>
    /// <param name="include">是否贪婪加载</param>
    /// <param name="cancellationToken"></param>
    /// <returns></returns>
    Task<Chapter> FindChapterByIdAsync(
        Guid id,
        bool include = true,
        CancellationToken cancellationToken = default);
}