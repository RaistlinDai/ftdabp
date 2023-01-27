using Volo.Abp.Application.Dtos;

namespace Novel.Application.Contracts.Dtos.Category;

public class CategoryCreateDto : EntityDto
{
    public string Name { get; set; }
}