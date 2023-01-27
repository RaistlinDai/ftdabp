using Volo.Abp.Application.Services;
using Novel.Application.Contracts.Dtos.Author;
using Volo.Abp.Application.Dtos;

namespace Novel.Application.Contracts.Interfaces;

public interface IAuthorAppService : IApplicationService
{
    Task CreateAsync(AuthorCreateDto inputDto);

    Task<AuthorDto> GetByIdAsync(Guid id);

    Task<PagedResultDto<AuthorDto>> GetPagedListAsync(PagedAndSortedResultRequestDto pagedAndSortedDto);
}