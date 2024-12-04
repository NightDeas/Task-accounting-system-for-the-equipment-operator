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
            #region User

            CreateMap<Models.Entities.User, UserDTO>().ReverseMap();
            CreateMap<RegisterDTORequest, User>();

            #endregion

            #region Employee

            CreateMap<Models.Entities.Employee, EmployeeDTO>().ReverseMap();
            CreateMap<EmployeeRequest, Employee>();

            #endregion



        }
    }
}
