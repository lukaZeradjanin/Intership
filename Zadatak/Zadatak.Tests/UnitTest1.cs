using Microsoft.EntityFrameworkCore;
using Zadatak.Data;
using Zadatak.Models;
using Zadatak.Models.Entities;
using Zadatak.Services;

namespace Zadatak.Tests;

public class CandidateServiceTests
{
    [Fact]
    public void AddCandidate_ReturnsNull_WhenEmailAlreadyExists()
    {
        using var context = CreateContext(nameof(AddCandidate_ReturnsNull_WhenEmailAlreadyExists));
        context.Skills.Add(new Skill { Id = 1, Name = "C#" });
        context.Candidates.Add(new Candidate
        {
            Id = 1,
            FullName = "Postojeci Kandidat",
            DateOfBirth = new DateTime(2000, 1, 1),
            ContactNumber = "0600000000",
            Email = "test@mail.com"
        });
        context.SaveChanges();

        var service = new CandidateService(context);
        var dto = new AddCandidateDto
        {
            FullName = "Novi Kandidat",
            DateOfBirth = new DateTime(2001, 2, 2),
            ContactNumber = "0611111111",
            Email = "TEST@mail.com",
            SkillIds = new List<int> { 1 }
        };

        var result = service.AddCandidate(dto);

        Assert.Null(result);
    }

    [Fact]
    public void SearchCandidates_ReturnsCandidate_WhenNameMatches()
    {
        using var context = CreateContext(nameof(SearchCandidates_ReturnsCandidate_WhenNameMatches));
        var skill = new Skill { Id = 1, Name = "C#" };
        var candidate = new Candidate
        {
            Id = 1,
            FullName = "Marko Markovic",
            DateOfBirth = new DateTime(1999, 5, 15),
            ContactNumber = "0622222222",
            Email = "marko@mail.com"
        };
        var candidateSkill = new CandidateSkill
        {
            CandidateId = 1,
            SkillId = 1,
            Candidate = candidate,
            Skill = skill
        };
        candidate.CandidateSkills.Add(candidateSkill);

        context.Skills.Add(skill);
        context.Candidates.Add(candidate);
        context.CandidateSkills.Add(candidateSkill);
        context.SaveChanges();

        var service = new CandidateService(context);

        var result = service.SearchCandidates("Marko", null);

        Assert.Single(result);
        Assert.Equal("Marko Markovic", result[0].FullName);
    }

    private static ApplicationDbContext CreateContext(string dbName)
    {
        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseInMemoryDatabase(databaseName: dbName)
            .Options;

        return new ApplicationDbContext(options);
    }
}
