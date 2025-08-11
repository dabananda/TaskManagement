using TaskManagement.API.Models.Enums;

namespace TaskManagement.API.DTOs.User
{
    public class UserUpdateDto
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public Role Role { get; set; }
    }
}
