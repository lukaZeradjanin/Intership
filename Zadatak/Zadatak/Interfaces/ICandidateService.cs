using Zadatak.Models;

namespace Zadatak.Interfaces
{
    public interface ICandidateService
    {
        List<CandidateDto> GetAllCandidates();
        CandidateDto? GetCandidateById(int id);
        CandidateDto? AddCandidate(AddCandidateDto dto);
        CandidateDto? UpdateCandidate(int id, UpdateCandidateDto dto);
        bool DeleteCandidate(int id);
        bool AddSkillByName(int id, string skillName);
        bool RemoveSkill(int id, int skillId);
        List<CandidateDto> SearchCandidates(string? name, string? skillName);
    }
}