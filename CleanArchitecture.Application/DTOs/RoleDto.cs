namespace CleanArchitecture.Application.DTOs
{
    public class RoleDto
    {
        public short Id { get; set; }
        public string? RoleName { get; set; }
        public string? Description { get; set; }
        public bool IsActive { get; set; }
    }
}