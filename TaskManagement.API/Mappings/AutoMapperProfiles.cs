using AutoMapper;
using TaskManagement.API.Models.Domain;
using TaskManagement.API.Models.DTO;

namespace TaskManagement.API.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Priority, AddPriorityRequestDto>().ReverseMap();
            CreateMap<Priority, PriorityDto>().ReverseMap();
            CreateMap<Priority, UpdatePriorityRequestDto>().ReverseMap();
        }
    }
}
