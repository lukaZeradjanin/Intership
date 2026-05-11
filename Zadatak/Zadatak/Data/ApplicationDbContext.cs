using Microsoft.EntityFrameworkCore;
using Zadatak.Models.Entities;

namespace Zadatak.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Candidate> Candidates { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<CandidateSkill> CandidateSkills { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<CandidateSkill>()
                .HasKey(cs => new { cs.CandidateId, cs.SkillId });

            modelBuilder.Entity<Candidate>()
                .HasIndex(c => c.Email)
                .IsUnique();

            modelBuilder.Entity<Skill>()
                .HasIndex(s => s.Name)
                .IsUnique();

            modelBuilder.Entity<Candidate>()
                .Property(c => c.FullName)
                .HasMaxLength(150)
                .IsRequired();

            modelBuilder.Entity<Candidate>()
                .Property(c => c.ContactNumber)
                .HasMaxLength(30)
                .IsRequired();

            modelBuilder.Entity<Candidate>()
                .Property(c => c.Email)
                .HasMaxLength(150)
                .IsRequired();

            modelBuilder.Entity<Skill>()
                .Property(s => s.Name)
                .HasMaxLength(100)
                .IsRequired();

            modelBuilder.Entity<Models.Entities.Candidate>().HasData(
                new Candidate
                {
                    Id = 1,
                    FullName = "Marko Markovic",
                    DateOfBirth = new DateTime(1998, 4, 12),
                    ContactNumber = "0611234567",
                    Email = "marko.markovic@gmail.com"
                },
                new Candidate
                {
                    Id = 2,
                    FullName = "Jelena Ilic",
                    DateOfBirth = new DateTime(1996, 11, 3),
                    ContactNumber = "0627654321",
                    Email = "jelena.ilic@gmail.com"
                },
                new Candidate
                {
                    Id = 3,
                    FullName = "Nikola Petrovic",
                    DateOfBirth = new DateTime(2000, 1, 25),
                    ContactNumber = "0639876543",
                    Email = "nikola.petrovic@gmail.com"
                }
            );

            modelBuilder.Entity<Models.Entities.Skill>().HasData(
                new Skill { Id = 1, Name = "C#" },
                new Skill { Id = 2, Name = "Java" },
                new Skill { Id = 3, Name = "SQL" },
                new Skill { Id = 4, Name = "English" },
                new Skill { Id = 5, Name = "React" },
                new Skill { Id = 6, Name = "Angular" },
                new Skill { Id = 7, Name = "Python" },
                new Skill { Id = 8, Name = "Docker" },
                new Skill { Id = 9, Name = "Problem solving" },
                new Skill { Id = 10, Name = "Communication" }
            );

            modelBuilder.Entity<Models.Entities.CandidateSkill>().HasData(
                new CandidateSkill { CandidateId = 1, SkillId = 1 },
                new CandidateSkill { CandidateId = 1, SkillId = 2 },
                new CandidateSkill { CandidateId = 1, SkillId = 3 },
                new CandidateSkill { CandidateId = 1, SkillId = 6 },
                new CandidateSkill { CandidateId = 1, SkillId = 8 },
                new CandidateSkill { CandidateId = 2, SkillId = 2 },
                new CandidateSkill { CandidateId = 2, SkillId = 4 },
                new CandidateSkill { CandidateId = 2, SkillId = 5 },
                new CandidateSkill { CandidateId = 2, SkillId = 7 },
                new CandidateSkill { CandidateId = 2, SkillId = 9 },
                new CandidateSkill { CandidateId = 3, SkillId = 1 },
                new CandidateSkill { CandidateId = 3, SkillId = 3 },
                new CandidateSkill { CandidateId = 3, SkillId = 4 },
                new CandidateSkill { CandidateId = 3, SkillId = 8 },
                new CandidateSkill { CandidateId = 3, SkillId = 10 }
            );
        }
    }
}