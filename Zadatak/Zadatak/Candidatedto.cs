namespace Zadatak.Models
{
    public class CandidateDto
    {
        public int Id { get; set; }
        public string FullName { get; set; } = null!;
        public DateTime DateOfBirth { get; set; }
        public string ContactNumber { get; set; } = null!;
        public string Email { get; set; } = null!;
        public List<string> Skills { get; set; } = new List<string>();
    }
}