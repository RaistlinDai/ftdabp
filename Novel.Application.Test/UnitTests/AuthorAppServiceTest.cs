using Novel.Application.Contracts.Author.Dtos;
using Novel.Application.Contracts.Author.Interfaces;
using Shouldly;
using Volo.Abp.Application.Dtos;

namespace Novel.Application.Test.UnitTests;

public class AuthorAppServiceTest : NovelApplicationTestBase
{
    private readonly IAuthorAppService _authorAppService;

    public AuthorAppServiceTest()
    {
        _authorAppService = GetRequiredService<IAuthorAppService>();
    }
    
    [Fact]
    public async Task Should_Create_A_Valid_Author()
    {
        var result = await _authorAppService.CreateAsync(
            new AuthorCreateDto
            {
                Name = "ftd",
                Description = "Forrest Dai"
            });
        
        // Assert
        result.Name.ShouldBe("ftd");
        result.Id.ShouldNotBe(Guid.Empty);
    }

    [Fact]
    public async Task Should_Update_A_Valid_Author()
    {
        var authors = await _authorAppService.GetListAsync(new PagedAndSortedResultRequestDto());

        AuthorDto inputDto = new AuthorDto
        {
            Id = authors.Items[0].Id,
            Name = authors.Items[0].Name,
            Description = "Update author"
        };

        await _authorAppService.UpdateAsync(inputDto.Id, inputDto);

        var result = await _authorAppService.GetAsync(inputDto.Id);
        result.Description.ShouldBe("Update author");
    }

    [Fact]
    public async Task Should_Delete_A_Author()
    {
        var authors = await _authorAppService.GetListAsync(new PagedAndSortedResultRequestDto());
        await _authorAppService.DeleteAsync(authors.Items[0].Id);

        var result = await _authorAppService.GetListAsync(new PagedAndSortedResultRequestDto());
        result.TotalCount.ShouldBe(0);
    }

    [Fact]
    public async Task Should_Get_List_Of_Authors()
    {
        var result = await _authorAppService.GetListAsync
        (
            new PagedAndSortedResultRequestDto()
        );
        
        // Assert
        result.TotalCount.ShouldBe(1);
        result.Items.ShouldContain(a => a.Name == "zal");
    }
}