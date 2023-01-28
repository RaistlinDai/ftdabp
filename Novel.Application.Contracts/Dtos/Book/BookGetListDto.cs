using Volo.Abp.Application.Dtos;

namespace Novel.Application.Contracts.Dtos.Book;

public class BookGetListDto : PagedAndSortedResultRequestDto
{
    public string Filter { get; set; }
}