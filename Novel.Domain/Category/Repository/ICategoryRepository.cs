using Volo.Abp.Domain.Repositories;

namespace Novel.Domain.Category.Repository;

public interface ICategoryRepository : IRepository<Entities.Category, Guid>
{
    
}