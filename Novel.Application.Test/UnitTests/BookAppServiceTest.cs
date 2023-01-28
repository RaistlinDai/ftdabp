using Novel.Application.Contracts.Book.Dtos;
using Novel.Application.Contracts.Book.Interfaces;
using Shouldly;

namespace Novel.Application.Test.UnitTests;

public class BookAppServiceTest: NovelApplicationTestBase
{
    private readonly IBookAppService _bookAppService;
    
    public BookAppServiceTest()
    {
        _bookAppService = GetRequiredService<IBookAppService>();
    }

    [Fact]
    public async Task Should_Get_List_Of_Books()
    {
        var result = await _bookAppService.GetListAsync
        (
            new BookGetListDto()
        );
        
        // Assert
        result.TotalCount.ShouldBe(2);
        result.Items.ShouldContain(a => a.Name == "马保国大师传");
    }
    
}