using AutoMapper;
using InterviewServer.DAO.Entities;

namespace InterviewServer.Mapping;

/// <summary>
/// Mapping Profile entities
/// </summary>
internal class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserResponse>();
    }
}
