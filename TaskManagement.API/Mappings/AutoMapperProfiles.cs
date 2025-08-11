using AutoMapper;
using TaskManagement.API.DTOs;
using TaskManagement.API.DTOs.TaskItem;
using TaskManagement.API.DTOs.User;
using TaskManagement.API.Models;

namespace TaskManagement.API.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            // User mappings
            CreateMap<User, UserReadDto>();
            CreateMap<UserCreateDto, User>();
            CreateMap<UserUpdateDto, User>();

            // TaskItem mappings
            CreateMap<TaskItem, TaskItemReadDto>();
            CreateMap<TaskItemCreateDto, TaskItem>();
            CreateMap<TaskItemUpdateDto, TaskItem>();
        }
    }
}
