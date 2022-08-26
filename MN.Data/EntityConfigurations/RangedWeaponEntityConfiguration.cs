using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MN.Domain;

namespace MN.Data.EntityConfigurations
{
    public class RangedWeaponEntityConfiguration : IEntityTypeConfiguration<RangedWeapon>
    {
        public void Configure(EntityTypeBuilder<RangedWeapon> builder)
        {
            builder.Property(x => x.Id).IsRequired().HasAnnotation("SqlServer:Identity", "1, 1");

            builder.HasOne(x => x.RangedWeaponType).WithMany();
        }
    }
}
