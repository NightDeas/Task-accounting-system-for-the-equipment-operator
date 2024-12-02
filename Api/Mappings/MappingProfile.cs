using Api.Models.Entities;
using Api.Models.Requests;
using Api.Models.Responses;
using AutoMapper;

namespace Api.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Models.Entities.User, UserDTO>().ReverseMap();
            CreateMap<RegisterDTO, User>();
        }
    }
}
