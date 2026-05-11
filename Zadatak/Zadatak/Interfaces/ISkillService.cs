using Zadatak.Models;
using Zadatak.Models.Entities;

namespace Zadatak.Interfaces
{
    public interface ISkillService
    {
        List<Skill> GetAllSkills();
        Skill? AddSkill(AddSkillDto dto);
    }
}
