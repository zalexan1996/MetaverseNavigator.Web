using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MN.Domain;

namespace MN.Data.EntityConfigurations
{
    public class PersonaEntityConfiguration : IEntityTypeConfiguration<Persona>
    {
        public void Configure(EntityTypeBuilder<Persona> builder)
        {
            builder.Property(x => x.Id).IsRequired().HasAnnotation("SqlServer:Identity", "1, 1");
            
            builder.HasOne(x => x.Confidant).WithMany();
        }
    }
}
