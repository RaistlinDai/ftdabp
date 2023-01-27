using Volo.Abp.Domain.Repositories;

namespace Novel.Domain.Author.Repository;

public interface IAuthorRepository: IRepository<Entities.Author, Guid>
{
    
}