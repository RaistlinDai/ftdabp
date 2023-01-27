using Novel.Domain.Author.Entities;
using Novel.Domain.Book.Entities;
using Novel.Domain.Category.Entities;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Guids;
using Volo.Abp.Uow;

namespace Novel.TestBase.Test;

/// <summary>
/// 数据种子，为UnitTest准备
/// IDataSeedContributor会被框架自动加载注入
/// </summary>
public class NovelDataSeedContributor : IDataSeedContributor, ITransientDependency
{
    private readonly IRepository<Author, Guid> _authorRepository;
    private readonly IRepository<Book, Guid> _bookRepository;
    private readonly IRepository<Category, Guid> _categoryRepository;
    private readonly List<Guid> _guids;

    public NovelDataSeedContributor(
        IRepository<Author, Guid> authorRepository,
        IRepository<Book, Guid> bookRepository,
        IRepository<Category, Guid> categoryRepository,
        IGuidGenerator guidGenerator)
    {
        _authorRepository = authorRepository;
        _bookRepository = bookRepository;
        _categoryRepository = categoryRepository;
        _guids = new List<Guid>();

        for (int i = 0; i < 4; i++)
        {
            _guids.Add(guidGenerator.Create());
        }
    }

    [UnitOfWork]
    public async Task SeedAsync(DataSeedContext context)
    {
        Console.WriteLine("11");
        await CreateAuthorAsync();
        await CreateCategoryAsync();
        await CreateBookAsync();
    }

    private async Task CreateAuthorAsync()
    {
        var author = new Author(
            _guids[0],
            "zal",
            "Aaron Luo"
            );
        await _authorRepository.InsertAsync(author);
    }

    private async Task CreateCategoryAsync()
    {
        var category = new Category(
            _guids[1],
            "History"
        );
        await _categoryRepository.InsertAsync(category);
    }

    private async Task CreateBookAsync()
    {
        Book book01 = new Book(
            _guids[2],
            "马保国大师传",
            "马保国大师野史",
            _guids[0],
            "马保国",
            _guids[1],
            "武侠"
        );
        book01.AddVolume(new Volume("闪电五连鞭", "马大师最著名招式"));
        book01.Volumes[0].AddChapter(new Chapter("Chapter 1", "结化发", null));
        
        Book book02 = new Book(
            _guids[3],
            "深入理解JVM",
            "Java丛书",
            _guids[0],
            "某人",
            _guids[1],
            "科技"
        );
        book02.AddVolume(new Volume("Java内存模型", "Java运行时的JVM内存模型"));
        book02.Volumes[0].AddChapter(new Chapter("Chapter 1", "程序计数器", null));

        await _bookRepository.InsertAsync(book01, true);
        await _bookRepository.InsertAsync(book02, true);
    }

}