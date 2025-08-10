using AutoMapper;
using TaskManagement.API.DTOs;
using TaskManagement.API.DTOs.TaskItem;
using TaskManagement.API.Models;

namespace TaskManagement.API.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<TaskItem, TaskItemReadDto>()
                .ForMember(dest => dest.AssignedUsers,
                    opt => opt.MapFrom(src => src.TaskAssignments
                        .Select(a => new DTOs.UserDto
                        {
                            Id = a.User.Id,
                            Name = a.User.Name,
                            Email = a.User.Email
                        })));

            CreateMap<TaskItemCreateDto, TaskItem>()
                .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(_ => DateTime.UtcNow))
                .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(_ => DateTime.UtcNow))
                .ForMember(dest => dest.TaskAssignments, opt => opt.Ignore());

            CreateMap<TaskItemUpdateDto, TaskItem>()
                .ForMember(dest => dest.UpdatedAt, opt => opt.MapFrom(_ => DateTime.UtcNow))
                .ForMember(dest => dest.TaskAssignments, opt => opt.Ignore());
        }
    }
}
