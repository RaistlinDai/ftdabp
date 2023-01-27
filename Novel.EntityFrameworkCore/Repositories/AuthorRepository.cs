using Novel.Domain.Author.Entities;
using Novel.Domain.Author.Repository;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace Novel.EntityFrameworkCore.Repositories;

/// <summary>
/// 继承EfCoreRepository,封装了各种CRUD方法
/// </summary>
public class AuthorRepository : EfCoreRepository<NovelDbContext, Author, Guid>, IAuthorRepository
{
    public AuthorRepository(IDbContextProvider<NovelDbContext> dbContextProvider) : base(dbContextProvider)
    {
    }
}