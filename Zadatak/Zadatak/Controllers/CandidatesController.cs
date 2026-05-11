using Microsoft.AspNetCore.Mvc;
using Zadatak.Interfaces;
using Zadatak.Models;

namespace Zadatak.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidatesController : ControllerBase
    {
        private readonly ICandidateService candidateService;

        public CandidatesController(ICandidateService candidateService)
        {
            this.candidateService = candidateService;
        }

        [HttpGet]
        public IActionResult GetAllCandidates()
        {
            var candidates = candidateService.GetAllCandidates();
            return Ok(candidates);
        }

        [HttpGet("{id}")]
        public IActionResult GetCandidateById(int id)
        {
            var candidate = candidateService.GetCandidateById(id);
            if (candidate == null)
                return NotFound(new { Message = "Candidate not found" });

            return Ok(candidate);
        }

        [HttpPost]
        public IActionResult AddCandidate(AddCandidateDto dto)
        {
            var candidate = candidateService.AddCandidate(dto);
            if (candidate == null)
                return BadRequest(new { Message = "Candidate could not be created." });

            return CreatedAtAction(nameof(GetCandidateById), new { id = candidate.Id }, candidate);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateCandidate(int id, UpdateCandidateDto dto)
        {
            var candidate = candidateService.UpdateCandidate(id, dto);
            if (candidate == null)
                return BadRequest(new { Message = "Candidate could not be updated." });

            return Ok(candidate);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteCandidate(int id)
        {
            var deleted = candidateService.DeleteCandidate(id);
            if (!deleted)
                return NotFound(new { Message = "Candidate not found" });

            return NoContent();
        }

        [HttpPost("{id}/skills/byname")]
        public IActionResult AddSkillByName(int id, [FromBody] string skillName)
        {
            var added = candidateService.AddSkillByName(id, skillName);
            if (!added)
                return BadRequest(new { Message = "Skill could not be added." });

            return Ok(new { Message = "Skill added successfully" });
        }

        [HttpDelete("{id}/skills/{skillId}")]
        public IActionResult RemoveSkill(int id, int skillId)
        {
            var removed = candidateService.RemoveSkill(id, skillId);
            if (!removed)
                return NotFound(new { Message = "Candidate does not have this skill" });

            return NoContent();
        }

        [HttpGet("search")]
        public IActionResult SearchCandidates([FromQuery] string? name, [FromQuery] string? skillName)
        {
            var candidates = candidateService.SearchCandidates(name, skillName);
            return Ok(candidates);
        }
    }
}