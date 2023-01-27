using Novel.Domain.Author.Entities;
using Shouldly;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Guids;

namespace Novel.EntityFrameworkCore.Test.UnitTests;

public sealed class AuthorRepositoryTest : NovelEntityFrameworkCoreTestBase
{
    private readonly IRepository<Author, Guid> _authorRepository;

    private readonly IGuidGenerator _guidGenerator;

    public AuthorRepositoryTest()
    {
        _authorRepository = GetRequiredService<IRepository<Author, Guid>>();
        _guidGenerator = GetRequiredService<IGuidGenerator>();
    }

    [Fact]
    public async Task Should_Insert_A_Valid_Author()
    {
        await WithUnitOfWorkAsync(
            async() =>
            {
                var result = await _authorRepository.InsertAsync(
                    new Author(
                        _guidGenerator.Create(),
                        "ftd",
                        "Genius writer"));
                result.Id.ShouldNotBe(Guid.Empty);
            });
    }

    [Fact]
    public async Task Should_Get_List_Of_Authors()
    {
        await WithUnitOfWorkAsync(
            async () =>
            {
                var result = await _authorRepository.GetListAsync();
                result.Count.ShouldBeGreaterThan(0);
            });
    }
}