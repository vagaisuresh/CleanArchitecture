using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.Application.DTOs
{
    public class UserSaveDto
    {
        [Required]
        [StringLength(100)]
        public string? FullName { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string? EmailAddress { get; set; }

        [Required]
        public string? PasswordHash { get; set; }

        [Required]
        public short RoleId { get; set; }

        [Required]
        [StringLength(15)]
        public string? MobileNumber { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [StringLength(50)]
        public string? ProfilePicture { get; set; }

        public bool IsActive { get; set; }
    }
}