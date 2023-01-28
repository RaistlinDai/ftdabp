using Volo.Abp.Application.Dtos;

namespace Novel.Application.Contracts.Book.Dtos;

public class BookGetListDto : PagedAndSortedResultRequestDto
{
    public string Filter { get; set; }
}