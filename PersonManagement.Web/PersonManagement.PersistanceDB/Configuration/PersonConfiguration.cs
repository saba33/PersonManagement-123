using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonManagement.Domain.POCO;


namespace PersonManagement.PersistanceDB.Configuration
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            //builder.ToTable("Person");

            builder.HasIndex(x => new { x.Identifier }).IsUnique();

            builder.HasKey(x => x.Id); 

            builder.Property(x => x.Identifier).IsUnicode(false).IsRequired().HasMaxLength(11).IsFixedLength();
          

            builder.Property(x => x.Gender).IsRequired();

            builder.Property(x => x.BirthDate).HasColumnType("datetime");

            builder.Property(x => x.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.BirthDate).IsRequired().HasMaxLength(50);
        }
    }
}
