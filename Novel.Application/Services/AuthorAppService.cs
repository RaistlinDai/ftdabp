using Novel.Application.Contracts.Dtos.Author;
using Novel.Application.Contracts.Interfaces;
using Novel.Domain.Author.Entities;
using Novel.Domain.Author.Repository;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace Novel.Application.Services;

public class AuthorAppService : ApplicationService, IAuthorAppService
{
    private readonly IAuthorRepository _authorRepository;

    public AuthorAppService(IAuthorRepository authorRepository)
    {
        _authorRepository = authorRepository;
    }
    
    public async Task CreateAsync(AuthorCreateDto inputDto)
    {
        var author = ObjectMapper.Map<AuthorCreateDto, Author>(inputDto);
        await _authorRepository.InsertAsync(author);
    }

    public async Task<AuthorDto> GetByIdAsync(Guid id)
    {
        var author = await _authorRepository.GetAsync(id);
        return ObjectMapper.Map<Author, AuthorDto>(author);
    }

    public async Task<PagedResultDto<AuthorDto>> GetPagedListAsync(PagedAndSortedResultRequestDto pagedAndSortedDto)
    {
        var count = await _authorRepository.CountAsync();
        var list = await _authorRepository.GetPagedListAsync(
            pagedAndSortedDto.SkipCount,
            pagedAndSortedDto.MaxResultCount,
            pagedAndSortedDto.Sorting,
            false);

        return new PagedResultDto<AuthorDto>
        {
            TotalCount = count,
            Items = ObjectMapper.Map<List<Author>, List<AuthorDto>>(list)
        };
    }
}