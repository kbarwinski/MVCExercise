using Bogus;
using Microsoft.EntityFrameworkCore.Migrations;
using MVCExercise.Persistence.Repositories.Person;

#nullable disable

namespace MVCExercise.Persistence.Migrations
{
    public partial class SeedingMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var fakeEmails = new Faker<Domain.Entities.Email>()
                .RuleFor(o => o.Address, f => f.Internet.Email())
                .Generate(100);

            var fakePersons = new Faker<Domain.Entities.Person>()
                .RuleFor(o => o.FirstName, f => f.Name.FirstName())
                .RuleFor(o => o.LastName, f => f.Name.LastName())
                .RuleFor(o => o.Description, f => f.Lorem.Sentence())
                .Generate(100);

            for (int i = 0; i < 100; i++)
            {
                var email = fakeEmails.ElementAt(i);
                var person = fakePersons.ElementAt(i);

                var personId = Guid.NewGuid();
                var emailId = Guid.NewGuid();

                migrationBuilder.InsertData(
                    table: "Persons",
                    columns: new[] { "Id", "CreatedAt", "UpdatedAt", "FirstName", "LastName", "Description" },
                    values: new object[] { personId, DateTime.UtcNow, DateTime.UtcNow, person.FirstName, person.LastName, person.Description });

                migrationBuilder.InsertData(
                    table: "Email",
                    columns: new[] { "Id", "CreatedAt", "UpdatedAt", "PersonId", "Address" },
                    values: new object[] { emailId, DateTime.UtcNow, DateTime.UtcNow, personId, email.Address });
            }
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
        }
    }
}
