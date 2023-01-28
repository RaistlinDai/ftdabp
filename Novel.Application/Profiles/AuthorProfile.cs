using AutoMapper;
using Novel.Application.Contracts.Dtos.Author;
using Novel.Domain.Author.Entities;
using Volo.Abp.AutoMapper;

namespace Novel.Application.Profiles;

public class AuthorProfile : Profile
{
    public AuthorProfile()
    {
        CreateMap<Author, AuthorDto>();
        CreateMap<AuthorDto, Author>();
        CreateMap<AuthorCreateDto, Author>()
            .Ignore(author => author.Id);
    }
}