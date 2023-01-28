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
        BookGetListDto listDto = new BookGetListDto();
        
        var result = await _bookAppService.GetListAsync(listDto);
        
        // Assert
        result.TotalCount.ShouldBe(2);
        result.Items[0].Name.ShouldBe("马保国大师传");
        result.Items[1].Name.ShouldBe("深入理解JVM");
    }
    
}