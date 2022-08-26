using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MN.Domain;

namespace MN.Data.EntityConfigurations
{
    public class MeleeWeaponTypeEntityConfiguration : IEntityTypeConfiguration<MeleeWeaponType>
    {
        public void Configure(EntityTypeBuilder<MeleeWeaponType> builder)
        {
            builder.Property(x => x.Id).IsRequired().HasAnnotation("SqlServer:Identity", "1, 1");
        }
    }
}
