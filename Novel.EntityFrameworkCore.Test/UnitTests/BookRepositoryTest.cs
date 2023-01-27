using Novel.Domain.Book.Entities;
using Shouldly;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Guids;

namespace Novel.EntityFrameworkCore.Test.UnitTests;

public sealed class BookRepositoryTest : NovelEntityFrameworkCoreTestBase
{
    private readonly IRepository<Book, Guid> _bookRepository;

    private readonly IGuidGenerator _guidGenerator;

    public BookRepositoryTest()
    {
        _bookRepository = GetRequiredService<IRepository<Book, Guid>>();
        _guidGenerator = GetRequiredService<IGuidGenerator>();
    }

    [Fact]
    public async Task Should_Insert_A_Valid_Book()
    {
        var result = await WithUnitOfWorkAsync(
            async () =>
            {
                var book = new Book(
                    _guidGenerator.Create(),
                    "三体",
                    "星云奖巨著",
                    _guidGenerator.Create(),
                    "刘慈欣",
                    _guidGenerator.Create(),
                    "科幻"
                );
                return await _bookRepository.InsertAsync(book);
            });
        result.Name.ShouldBe("三体");
        result.CreationTime.ShouldNotBe(DateTime.Today);
    }

    [Fact]
    public async Task Should_Insert_A_Valid_Volume()
    {
        var result = await WithUnitOfWorkAsync(
            async () =>
            {
                var book = await _bookRepository.GetAsync(b => b.Name == "马保国大师传");
                book.AddVolume(new Volume("不讲武德", "马大师被扁"));
                return await _bookRepository.UpdateAsync(book);
            });
        // result.Volumes.Count.ShouldBe(2);
        result.Name.ShouldBe("马保国大师传");
        result.Volumes.Count.ShouldBe(2);
    }
    

    [Fact]
    public async Task Should_Insert_A_Valid_Chapter()
    {
        var result = await WithUnitOfWorkAsync(
            async () =>
            {
                var book = await _bookRepository.GetAsync(b => b.Name == "马保国大师传");
                book.Volumes[0].AddChapter(new Chapter("Chapter 2", "实战八枪", null));
                return await _bookRepository.UpdateAsync(book);
            });
        result.Volumes[0].Chapters.Count.ShouldBe(2);
    }

    [Fact]
    public async Task Should_Get_List_Of_Books()
    {
        var result = await WithUnitOfWorkAsync(
            async () => await _bookRepository.GetListAsync());
        result.Count.ShouldBe(2);
    }

    [Fact]
    public async Task Should_Delete_A_Book()
    {
        var result = await WithUnitOfWorkAsync(
            async () =>
            {
                var book = await _bookRepository.GetAsync(b => b.Name == "马保国大师传");
                await _bookRepository.DeleteAsync(book, true);
                return await _bookRepository.GetListAsync();
            });
        result.Count.ShouldBe(1);
    }

    [Fact]
    public async Task Should_Get_Page_Of_Books()
    {
        var result = await WithUnitOfWorkAsync(
            async () =>
            {
                return await _bookRepository.GetPagedListAsync(
                    0,
                    5,
                    "Name ASC",
                    false);
            });
        result[0].Name.ShouldBe("深入理解JVM");
        result.Count.ShouldBe(2);
    }
}