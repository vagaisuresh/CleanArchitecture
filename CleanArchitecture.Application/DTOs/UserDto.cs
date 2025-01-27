namespace CleanArchitecture.Application.DTOs
{
    public class UserDto
    {
        public short Id { get; set; }
        public string? FullName { get; set; }
        public string? EmailAddress { get; set; }
        public short RoleId { get; set; }
        public string? MobileNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? ProfilePicture { get; set; }
        public bool IsActive { get; set; }

        public RoleDto? Role { get; set; }
    }
}