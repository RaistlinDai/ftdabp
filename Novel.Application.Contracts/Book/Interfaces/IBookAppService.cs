using Novel.Application.Contracts.Book.Dtos;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Novel.Application.Contracts.Book.Interfaces;

public interface IBookAppService : IApplicationService
{
    Task<PagedResultDto<BookDto>> GetListAsync(BookGetListDto bookGetListDto);
}