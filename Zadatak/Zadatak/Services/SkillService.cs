using Zadatak.Data;
using Zadatak.Interfaces;
using Zadatak.Models;
using Zadatak.Models.Entities;

namespace Zadatak.Services
{
    public class SkillService : ISkillService
    {
        private readonly ApplicationDbContext dbContext;

        public SkillService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<Skill> GetAllSkills()
        {
            return dbContext.Skills.ToList();
        }

        public Skill? AddSkill(AddSkillDto dto)
        {
            var skillName = dto.Name.Trim();
            var skillNameLower = skillName.ToLower();

            var alreadyExists = dbContext.Skills.Any(s => s.Name.ToLower() == skillNameLower);
            if (alreadyExists)
                return null;

            var skill = new Skill
            {
                Name = skillName
            };

            dbContext.Skills.Add(skill);
            dbContext.SaveChanges();

            return skill;
        }
    }
}
