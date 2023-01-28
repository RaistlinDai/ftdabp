using AutoMapper;
using Novel.Application.Contracts.Author.Dtos;
using Volo.Abp.AutoMapper;

namespace Novel.Application.Author.Profiles;

public class AuthorProfile : Profile
{
    public AuthorProfile()
    {
        CreateMap<Domain.Author.Entities.Author, AuthorDto>();
        CreateMap<AuthorDto, Domain.Author.Entities.Author>();
        CreateMap<AuthorCreateDto, Domain.Author.Entities.Author>()
            .Ignore(author => author.Id);
    }
}