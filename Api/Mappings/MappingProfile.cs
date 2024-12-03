using Api.Models.DTO;
using Api.Models.Entities;
using Api.Models.Requests;
using AutoMapper;

namespace Api.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Models.Entities.User, UserDTO>().ReverseMap();
            CreateMap<RegisterDTORequest, User>();
        }
    }
}
