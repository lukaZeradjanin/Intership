using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Zadatak.Migrations
{
    /// <inheritdoc />
    public partial class SeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Candidates",
                columns: new[] { "Id", "ContactNumber", "DateOfBirth", "Email", "FullName" },
                values: new object[,]
                {
                    { 1, "0611234567", new DateTime(1998, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "marko.markovic@gmail.com", "Marko Markovic" },
                    { 2, "0627654321", new DateTime(1996, 11, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "jelena.ilic@gmail.com", "Jelena Ilic" },
                    { 3, "0639876543", new DateTime(2000, 1, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "nikola.petrovic@gmail.com", "Nikola Petrovic" }
                });

            migrationBuilder.InsertData(
                table: "Skills",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "C#" },
                    { 2, "Java" },
                    { 3, "SQL" },
                    { 4, "English" },
                    { 5, "React" },
                    { 6, "Angular" },
                    { 7, "Python" },
                    { 8, "Docker" },
                    { 9, "Problem solving" },
                    { 10, "Communication" }
                });

            migrationBuilder.InsertData(
                table: "CandidateSkills",
                columns: new[] { "CandidateId", "SkillId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 1, 2 },
                    { 1, 3 },
                    { 1, 6 },
                    { 1, 8 },
                    { 2, 2 },
                    { 2, 4 },
                    { 2, 5 },
                    { 2, 7 },
                    { 2, 9 },
                    { 3, 1 },
                    { 3, 3 },
                    { 3, 4 },
                    { 3, 8 },
                    { 3, 10 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CandidateSkills",
                keyColumns: new[] { "CandidateId", "SkillId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "CandidateSkills",
                keyColumns: new[] { "CandidateId", "SkillId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "CandidateSkills",
                keyColumns: new[] { "CandidateId", "SkillId" },
                keyValues: new object[] { 1, 3 });

            migrationBuilder.DeleteData(
                table: "CandidateSkills",
                keyColumns: new[] { "CandidateId", "SkillId" },
                keyValues: new object[] { 1, 6 });

            migrationBuilder.DeleteData(
                table: "CandidateSkills",
                keyColumns: new[] { "CandidateId", "SkillId" },
                keyValues: new object[] { 1, 8 });

            migrationBuilder.DeleteData(
                table: "CandidateSkills",
                keyColumns: new[] { "CandidateId", "SkillId" },
                keyValues: new object[] { 2, 2 });

            migrationBuilder.DeleteData(
                table: "CandidateSkills",
                keyColumns: new[] { "CandidateId", "SkillId" },
                keyValues: new object[] { 2, 4 });

            migrationBuilder.DeleteData(
                table: "CandidateSkills",
                keyColumns: new[] { "CandidateId", "SkillId" },
                keyValues: new object[] { 2, 5 });

            migrationBuilder.DeleteData(
                table: "CandidateSkills",
                keyColumns: new[] { "CandidateId", "SkillId" },
                keyValues: new object[] { 2, 7 });

            migrationBuilder.DeleteData(
                table: "CandidateSkills",
                keyColumns: new[] { "CandidateId", "SkillId" },
                keyValues: new object[] { 2, 9 });

            migrationBuilder.DeleteData(
                table: "CandidateSkills",
                keyColumns: new[] { "CandidateId", "SkillId" },
                keyValues: new object[] { 3, 1 });

            migrationBuilder.DeleteData(
                table: "CandidateSkills",
                keyColumns: new[] { "CandidateId", "SkillId" },
                keyValues: new object[] { 3, 3 });

            migrationBuilder.DeleteData(
                table: "CandidateSkills",
                keyColumns: new[] { "CandidateId", "SkillId" },
                keyValues: new object[] { 3, 4 });

            migrationBuilder.DeleteData(
                table: "CandidateSkills",
                keyColumns: new[] { "CandidateId", "SkillId" },
                keyValues: new object[] { 3, 8 });

            migrationBuilder.DeleteData(
                table: "CandidateSkills",
                keyColumns: new[] { "CandidateId", "SkillId" },
                keyValues: new object[] { 3, 10 });

            migrationBuilder.DeleteData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Candidates",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Skills",
                keyColumn: "Id",
                keyValue: 10);
        }
    }
}
