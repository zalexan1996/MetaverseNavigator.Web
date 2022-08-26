using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MN.Domain;

namespace MN.Data.EntityConfigurations
{
    public class RangedWeaponTypeEntityConfiguration : IEntityTypeConfiguration<RangedWeaponType>
    {
        public void Configure(EntityTypeBuilder<RangedWeaponType> builder)
        {
            builder.Property(x => x.Id).IsRequired().HasAnnotation("SqlServer:Identity", "1, 1");
        }
    }
}
