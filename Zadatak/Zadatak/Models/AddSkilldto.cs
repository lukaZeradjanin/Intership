using System.ComponentModel.DataAnnotations;

namespace Zadatak.Models
{
    public class AddSkillDto
    {
        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = null!;
    }
}