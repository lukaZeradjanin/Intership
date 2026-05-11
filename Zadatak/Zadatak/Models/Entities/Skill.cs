using System.ComponentModel.DataAnnotations;

namespace Zadatak.Models.Entities
{
    public class Skill
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = null!;

        public ICollection<CandidateSkill> CandidateSkills { get; set; } = new List<CandidateSkill>();
    }
}
