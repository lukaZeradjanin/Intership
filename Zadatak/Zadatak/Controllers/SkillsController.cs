using Microsoft.AspNetCore.Mvc;
using Zadatak.Interfaces;
using Zadatak.Models;

namespace Zadatak.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillsController : ControllerBase
    {
        private readonly ISkillService skillService;

        public SkillsController(ISkillService skillService)
        {
            this.skillService = skillService;
        }

        [HttpGet]
        public IActionResult GetAllSkills()
        {
            var skills = skillService.GetAllSkills();
            return Ok(skills);
        }

        [HttpPost]
        public IActionResult AddSkill(AddSkillDto addSkillDto)
        {
            var skill = skillService.AddSkill(addSkillDto);
            if (skill == null)
                return Conflict(new { Message = "Skill with the same name already exists." });

            return CreatedAtAction(nameof(GetAllSkills), new { id = skill.Id }, skill);
        }
    }
}