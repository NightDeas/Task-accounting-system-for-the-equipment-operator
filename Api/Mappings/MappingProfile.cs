using Api.Models.DTO;
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
            #region User

            CreateMap<Models.Entities.User, UserDTO>().ReverseMap();
            CreateMap<RegisterRequest, User>();

            #endregion

            #region Employee

            CreateMap<Models.Entities.Employee, EmployeeDTO>().ReverseMap();
            CreateMap<EmployeeRequest, Employee>();

            #endregion

            #region Task

            CreateMap<Models.Entities.Task, TaskDTO>().ReverseMap();
            CreateMap<TaskRequest, Models.Entities.Task>();
            CreateMap<TaskCreateRequest, Models.Entities.Task>();
            CreateMap<TaskResponse, Models.Entities.Task>();
            CreateMap<TaskResponse, TaskRequest>();

            #endregion



        }
    }
}
