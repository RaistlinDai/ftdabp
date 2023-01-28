using Volo.Abp.Application.Dtos;

namespace Novel.Application.Contracts.Author.Dtos;

public class AuthorDto : EntityDto<Guid>
{
    public string Name { get; set; }
    
    public string Description { get; set; }
}