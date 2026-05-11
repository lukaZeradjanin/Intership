using Microsoft.EntityFrameworkCore;
using Zadatak.Data;
using Zadatak.Interfaces;
using Zadatak.Models;
using Zadatak.Models.Entities;

namespace Zadatak.Services
{
    public class CandidateService : ICandidateService
    {
        private readonly ApplicationDbContext dbContext;

        public CandidateService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public List<CandidateDto> GetAllCandidates()
        {
            return dbContext.Candidates
                .Select(c => new CandidateDto
                {
                    Id = c.Id,
                    FullName = c.FullName,
                    DateOfBirth = c.DateOfBirth,
                    ContactNumber = c.ContactNumber,
                    Email = c.Email,
                    Skills = c.CandidateSkills.Select(cs => cs.Skill.Name).ToList()
                })
                .ToList();
        }

        public CandidateDto? GetCandidateById(int id)
        {
            var candidate = dbContext.Candidates
                .FirstOrDefault(c => c.Id == id);

            if (candidate == null)
                return null;

            return new CandidateDto
            {
                Id = candidate.Id,
                FullName = candidate.FullName,
                DateOfBirth = candidate.DateOfBirth,
                ContactNumber = candidate.ContactNumber,
                Email = candidate.Email,
                Skills = candidate.CandidateSkills.Select(cs => cs.Skill.Name).ToList()
            };
        }

        public CandidateDto? AddCandidate(AddCandidateDto dto)
        {
            var emailExists = dbContext.Candidates
                .Any(c => c.Email.ToLower() == dto.Email.ToLower());

            if (emailExists)
                return null;

            var skillIds = dto.SkillIds.Distinct().ToList();
            var existingSkillIds = dbContext.Skills
                .Where(s => skillIds.Contains(s.Id))
                .Select(s => s.Id)
                .ToList();

            if (skillIds.Count != existingSkillIds.Count)
                return null;

            var candidate = new Candidate
            {
                FullName = dto.FullName,
                DateOfBirth = dto.DateOfBirth,
                ContactNumber = dto.ContactNumber,
                Email = dto.Email,
                CandidateSkills = skillIds.Select(skillId => new CandidateSkill
                {
                    SkillId = skillId
                }).ToList()
            };

            dbContext.Candidates.Add(candidate);
            dbContext.SaveChanges();

            return GetCandidateById(candidate.Id);
        }

        public CandidateDto? UpdateCandidate(int id, UpdateCandidateDto dto)
        {
            var candidate = dbContext.Candidates
                .FirstOrDefault(c => c.Id == id);

            if (candidate == null)
                return null;

            var emailTaken = dbContext.Candidates
                .Any(c => c.Id != id && c.Email.ToLower() == dto.Email.ToLower());

            if (emailTaken)
                return null;

            var newSkillIds = dto.SkillIds.Distinct().ToList();
            var existingSkillIds = dbContext.Skills
                .Where(s => newSkillIds.Contains(s.Id))
                .Select(s => s.Id)
                .ToList();

            if (newSkillIds.Count != existingSkillIds.Count)
                return null;

            candidate.FullName = dto.FullName;
            candidate.DateOfBirth = dto.DateOfBirth;
            candidate.ContactNumber = dto.ContactNumber;
            candidate.Email = dto.Email;

            dbContext.CandidateSkills.RemoveRange(candidate.CandidateSkills);
            candidate.CandidateSkills = newSkillIds.Select(skillId => new CandidateSkill
            {
                CandidateId = candidate.Id,
                SkillId = skillId
            }).ToList();

            dbContext.SaveChanges();

            return GetCandidateById(id);
        }

        public bool DeleteCandidate(int id)
        {
            var candidate = dbContext.Candidates.Find(id);

            if (candidate == null)
                return false;

            dbContext.Candidates.Remove(candidate);
            dbContext.SaveChanges();

            return true;
        }

        public bool AddSkillByName(int id, string skillName)
        {
            if (string.IsNullOrWhiteSpace(skillName))
                return false;

            var candidate = dbContext.Candidates.Find(id);
            if (candidate == null)
                return false;

            var skill = dbContext.Skills
                .FirstOrDefault(s => s.Name.ToLower() == skillName.ToLower());

            if (skill == null)
                return false;

            var alreadyHasSkill = dbContext.CandidateSkills
                .Any(cs => cs.CandidateId == id && cs.SkillId == skill.Id);

            if (alreadyHasSkill)
                return false;

            dbContext.CandidateSkills.Add(new CandidateSkill
            {
                CandidateId = id,
                SkillId = skill.Id
            });

            dbContext.SaveChanges();

            return true;
        }

        public bool RemoveSkill(int id, int skillId)
        {
            var candidateSkill = dbContext.CandidateSkills
                .FirstOrDefault(cs => cs.CandidateId == id && cs.SkillId == skillId);

            if (candidateSkill == null)
                return false;

            dbContext.CandidateSkills.Remove(candidateSkill);
            dbContext.SaveChanges();

            return true;
        }

        public List<CandidateDto> SearchCandidates(string? name, string? skillName)
        {
            var query = dbContext.Candidates
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(name))
                query = query.Where(c => c.FullName.ToLower().Contains(name.ToLower()));

            if (!string.IsNullOrWhiteSpace(skillName))
                query = query.Where(c => c.CandidateSkills
                    .Any(cs => cs.Skill.Name.ToLower() == skillName.ToLower()));

            return query.Select(c => new CandidateDto
            {
                Id = c.Id,
                FullName = c.FullName,
                DateOfBirth = c.DateOfBirth,
                ContactNumber = c.ContactNumber,
                Email = c.Email,
                Skills = c.CandidateSkills.Select(cs => cs.Skill.Name).ToList()
            }).ToList();
        }
    }
}