using Volo.Abp.Application.Dtos;

namespace Novel.Application.Contracts.Dtos.Category;

public class CategoryDto : EntityDto<Guid>
{
    public string Name { get; set; }
}