using Novel.Application.Contracts.Book.Dtos;
using Novel.Application.Contracts.Book.Interfaces;
using Novel.Domain.Author.Repository;
using Novel.Domain.Book.Repository;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace Novel.Application.Book.Services;

public class BookAppService : 
    CrudAppService<
        Domain.Book.Entities.Book,
        BookDto,
        Guid,
        PagedAndSortedResultRequestDto,
        BookCreateDto>,
    IBookAppService
{
    private readonly IBookRepository _bookRepository;
    private readonly IAuthorRepository _authorRepository;
    
    public BookAppService(IBookRepository bookRepository, IAuthorRepository authorRepository) : base(bookRepository)
    {
        _bookRepository = bookRepository;
        _authorRepository = authorRepository;
    }

    public async Task<PagedResultDto<BookDto>> GetListAsync(BookGetListDto bookGetListDto)
    {
        //Get the IQueryable<Book> from the repository
        var queryable = await Repository.GetQueryableAsync();
        
        //Prepare a query to join book and authors
        var query = from books in queryable
            join authors in await _authorRepository.GetQueryableAsync() on books.AuthorId equals authors.Id
            orderby NormalizeSorting(bookGetListDto.Sorting)
            select new { books, authors };
        
        //Paging
        query = query
            .Skip(bookGetListDto.SkipCount)
            .Take(bookGetListDto.MaxResultCount);
        
        //Execute the query and get a list
        var queryResult = await AsyncExecuter.ToListAsync(query);
        
        //Convert the query result to a list of BookDto objects
        var bookDtos = queryResult.Select(
            b =>
            {
                var bookDto = ObjectMapper.Map<Domain.Book.Entities.Book, BookDto>(b.books);
                bookDto.AuthorName = b.authors.Name;
                return bookDto;
            }).ToList();
        
        //Get the total count with author query
        var totalCount = await Repository.GetCountAsync();

        return new PagedResultDto<BookDto>(totalCount, bookDtos);
    }
    
    private static string NormalizeSorting(string sorting)
    {
        if (sorting.IsNullOrEmpty())
        {
            return $"books.{nameof(Domain.Book.Entities.Book.Name)}";
        }

        if (sorting.Contains("authorName", StringComparison.OrdinalIgnoreCase))
        {
            return sorting.Replace(
                "authorName",
                "authors.Name",
                StringComparison.OrdinalIgnoreCase
            );
        }

        return $"books.{sorting}";
    }
}