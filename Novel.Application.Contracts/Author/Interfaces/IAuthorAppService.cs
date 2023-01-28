using Volo.Abp.Application.Services;
using Novel.Application.Contracts.Author.Dtos;
using Volo.Abp.Application.Dtos;

namespace Novel.Application.Contracts.Author.Interfaces;

public interface IAuthorAppService : IApplicationService
{
    Task<AuthorDto> CreateAsync(AuthorCreateDto inputDto);

    Task<AuthorDto> GetAsync(Guid id);

    Task UpdateAsync(Guid id, AuthorDto inputDto);

    Task DeleteAsync(Guid id);

    Task<PagedResultDto<AuthorDto>> GetListAsync(PagedAndSortedResultRequestDto pagedAndSortedDto);
}