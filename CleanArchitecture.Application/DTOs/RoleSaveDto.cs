using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.Application.DTOs
{
    public class RoleSaveDto
    {
        [Required]
        [StringLength(20)]
        public string? RoleName { get; set; }

        [Required]
        [StringLength(200)]
        public string? Description { get; set; }

        public bool IsActive { get; set; }
    }
}