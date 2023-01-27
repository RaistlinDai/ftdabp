using Volo.Abp.Application.Dtos;

namespace Novel.Application.Contracts.Dtos.Author;

public class AuthorCreateDto : EntityDto
{
    public string Name { get; set; }
    
    public string Description { get; set; }
}