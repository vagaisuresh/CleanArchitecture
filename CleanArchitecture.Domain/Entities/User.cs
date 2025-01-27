namespace CleanArchitecture.Domain.Entities
{
    public class User
    {
        public short Id { get; set; }
        public string? FullName { get; set; }
        public string? EmailAddress { get; set; }
        public string? PasswordHash { get; set; }
        public short RoleId { get; set; }
        public string? MobileNumber { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string? ProfilePicture { get; set; }
        public bool IsActive { get; set; }
        public bool IsRemoved { get; set; }
        public DateTime CreatedDate { get; set; }

        public Role? Role { get; set; }
    }
}