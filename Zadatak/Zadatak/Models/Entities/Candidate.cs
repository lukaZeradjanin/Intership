using System.ComponentModel.DataAnnotations;

namespace Zadatak.Models.Entities
{
    public class Candidate
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string FullName { get; set; } = null!;
        
        public DateTime DateOfBirth { get; set; }

        [Required]
        [MaxLength(30)]
        public string ContactNumber { get; set; } = null!;

        [Required]
        [MaxLength(150)]
        public string Email { get; set; } = null!;

        public ICollection<CandidateSkill> CandidateSkills { get; set; } = new List<CandidateSkill>();

    }
}
