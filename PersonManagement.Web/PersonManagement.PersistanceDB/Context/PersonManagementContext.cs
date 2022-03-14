using Microsoft.EntityFrameworkCore;
using PersonManagement.Domain.POCO;

namespace PersonManagement.PersistanceDB.Context
{
    public class PersonManagementContext : DbContext
    {
        #region Ctor

        public PersonManagementContext(DbContextOptions<PersonManagementContext> options) : base(options)
        {

        }

        #endregion

        #region DbSets

        public DbSet<Person> Persons { get; set; }

        public DbSet<User> Users { get; set; }

        #endregion

        #region Configurations

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PersonManagementContext).Assembly);
        }

        #endregion
    }
}
