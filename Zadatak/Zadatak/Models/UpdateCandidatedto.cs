using System.ComponentModel.DataAnnotations;

namespace Zadatak.Models
{
    public class UpdateCandidateDto
    {
        [Required]
        [MaxLength(150)]
        public string FullName { get; set; } = null!;

        public DateTime DateOfBirth { get; set; }

        [Required]
        [Phone]
        public string ContactNumber { get; set; } = null!;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        public List<int> SkillIds { get; set; } = new List<int>();
    }
}
