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
        CreateMap<VolumeCreateDto, Domain.Book.Entities.Volume>().
            Ignore(volume => volume.Id)
            .Ignore(volume => volume.CreationTime)
            .Ignore(volume => volume.Book);
        
        CreateMap<Domain.Book.Entities.Chapter, ChapterDto>();
        CreateMap<ChapterCreateDto, Domain.Book.Entities.Chapter>()
            .Ignore(chapter => chapter.Id)
            .Ignore(chapter => chapter.CreationTime)
            .Ignore(chapter => chapter.Volume);
        
        CreateMap<Domain.Book.Entities.ChapterText, ChapterTextDto>();
        CreateMap<ChapterTextCreateDto, Domain.Book.Entities.ChapterText>()
            .Ignore(text => text.Id)
            .Ignore(text => text.Chapter);
    }
}