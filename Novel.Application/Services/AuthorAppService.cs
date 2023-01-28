﻿using Novel.Application.Contracts.Dtos.Author;
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
    
    public async Task<AuthorDto> CreateAsync(AuthorCreateDto inputDto)
    {
        var author = ObjectMapper.Map<AuthorCreateDto, Author>(inputDto);
        await _authorRepository.InsertAsync(author);
        return ObjectMapper.Map<Author, AuthorDto>(author);
    }

    public async Task<AuthorDto> GetAsync(Guid id)
    {
        var author = await _authorRepository.GetAsync(id);
        return ObjectMapper.Map<Author, AuthorDto>(author);
    }

    public async Task UpdateAsync(Guid id, AuthorDto inputDto)
    {
        var author = await _authorRepository.GetAsync(id);
        if (!author.Name.Equals(inputDto.Name))
            author.Name = inputDto.Name;
        author.Description = inputDto.Description;
        
        await _authorRepository.UpdateAsync(author);
    }
    
    public async Task DeleteAsync(Guid id)
    {
        await _authorRepository.DeleteAsync(id);
    }

    public async Task<PagedResultDto<AuthorDto>> GetListAsync(PagedAndSortedResultRequestDto pagedAndSortedDto)
    {
        // 默认sorting
        if (pagedAndSortedDto.Sorting.IsNullOrWhiteSpace())
            pagedAndSortedDto.Sorting = nameof(Author.Name);
        
        var count = await _authorRepository.CountAsync();
        
        var list = await _authorRepository.GetPagedListAsync(
            pagedAndSortedDto.SkipCount,
            pagedAndSortedDto.MaxResultCount,
            pagedAndSortedDto.Sorting);

        return new PagedResultDto<AuthorDto>
        {
            TotalCount = count,
            Items = ObjectMapper.Map<List<Author>, List<AuthorDto>>(list)
        };
    }
}