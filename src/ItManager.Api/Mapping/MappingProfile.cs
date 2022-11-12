using AutoMapper;
using ItManager.Api.Resources;
using ItManager.Core.Models;
using ItManager.Core.Models.Auth;
using ItManager.Data.Repositories;

namespace ItManager.Api.Mapping;

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