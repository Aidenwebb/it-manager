using AutoMapper;
using JsgItManager.Api.Resources;
using JsgItManager.Core.Models;
using JsgItManager.Core.Models.Auth;
using JsgItManager.Data.Repositories;

namespace JsgItManager.Api.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        // Domain to Resource
        CreateMap<Institution, InstitutionResource>();
        
        
        // Resource to Domain
        CreateMap<InstitutionResource, Institution>();
        CreateMap<SaveInstitutionResource, Institution>();
        
        CreateMap<UserRegisterResource, ApplicationUser>().ForMember(u => u.UserName, opt => opt.MapFrom(ur => ur.Email));
        
    }
}