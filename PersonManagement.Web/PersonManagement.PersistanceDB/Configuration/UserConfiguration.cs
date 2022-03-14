using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PersonManagement.Domain.POCO;
using System;
using System.Collections.Generic;
using System.Text;

namespace PersonManagement.PersistanceDB.Configuration
{
    class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            //builder.ToTable("Person");

            builder.HasIndex(x => new { x.UserName }).IsUnique();

            builder.HasKey(x => x.Id); 

            builder.Property(x => x.UserName).IsUnicode(false).IsRequired().HasMaxLength(50);
           

            builder.Property(x => x.FirstNam).IsRequired().HasMaxLength(50);
            builder.Property(x => x.LastName).IsRequired().HasMaxLength(50);

            builder.Property(x => x.Password).IsUnicode(false).IsRequired().HasMaxLength(15);
        }
    }

}
