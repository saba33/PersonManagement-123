using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PersonManagement.Domain.POCO;
using PersonManagement.PersistanceDB.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonManagement.PersistanceDB.Seed
{
    public static class PersonManagementSeed
    {

        public static void Initialize(IServiceProvider serviceProvider)
        {

            using var scope = serviceProvider.CreateScope();
            var database = scope.ServiceProvider.GetRequiredService<PersonManagementContext>();

            Migrate(database);
            SeedEverything(database);
        }

        private static void SeedEverything(PersonManagementContext context)
        {
            var seeded = false;

            SeedPersons(context, ref seeded);

            SeedUsers(context, ref seeded);

            if (seeded)
                context.SaveChanges();
        }

        private static void Migrate(PersonManagementContext context)
        {
            context.Database.Migrate(); 
        }

        private static void SeedPersons(PersonManagementContext context, ref bool seeded)
        {
            var persons = new List<Person>()
            {
                new Person()
                {
                    FirstName = "Lasha",
                    LastName = "LaDaushvilisha",
                    BirthDate = DateTime.Now.AddYears(-30),
                    Identifier = "01005248745",
                    Gender = true
                },
                   new Person()
                {
                        FirstName = "beqa",
                    LastName = "Ghvaberidze",
                    BirthDate = DateTime.Now.AddYears(-29),
                    Identifier = "01005248749",
                    Gender = true
                }
            };

            foreach (var person in persons)
            {
                if (context.Persons.AnyAsync(x => x.Identifier == person.Identifier).Result) continue;

                context.Persons.Add(person);
                seeded = true;
            }
        }

        private static void SeedUsers(PersonManagementContext context, ref bool seeded)
        {
            var users = new List<User>()
            {
                new User()
                {
                    UserName = "admin",
                    FirstNam = "Lasha",
                    LastName = "LaDaushvilisha",
                    Password="123"

                },
                   new User()
                {
                      UserName = "user",
                    FirstNam = "beqa",
                    LastName = "ghvaberidze",
                    Password="1234"

                }
            };

            foreach (var user in users)
            {
                if (context.Users.AnyAsync(x => x.UserName == user.UserName).Result) continue;

                context.Users.Add(user);
                seeded = true;
            }
        }
    }
}
