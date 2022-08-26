using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MN.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MN.Data.EntityConfigurations
{
    public class ConfidantEntityConfiguration : IEntityTypeConfiguration<Confidant>
    {
        public void Configure(EntityTypeBuilder<Confidant> builder)
        {
            builder.Property(x => x.Id).IsRequired().HasAnnotation("SqlServer:Identity", "1, 1");
            builder.HasOne(c=>c.GameCharacter).WithOne().OnDelete(DeleteBehavior.NoAction);
            builder.HasIndex(c=>c.Name).IsUnique();
        }
    }
}
