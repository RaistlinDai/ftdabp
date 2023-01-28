using AutoMapper;
using Novel.Application.Contracts.Book.Dtos;
using Volo.Abp.AutoMapper;

namespace Novel.Application.Book.Profiles;

public class BookProfile : Profile
{
    public BookProfile()
    {
        CreateMap<Domain.Book.Entities.Book, BookDto>();
        CreateMap<BookCreateDto, Domain.Book.Entities.Book>()
            .Ignore(book => book.Id)
            .Ignore(book => book.CreationTime);
        
        CreateMap<Domain.Book.Entities.Volume, VolumeDto>();
        CreateMap<Domain.Book.Entities.Chapter, ChapterDto>();
        
        CreateMap<Domain.Book.Entities.ChapterText, ChapterTextDto>();
        CreateMap<ChapterTextDto, Domain.Book.Entities.ChapterText>()
            .Ignore(chap => chap.Id);
    }
}