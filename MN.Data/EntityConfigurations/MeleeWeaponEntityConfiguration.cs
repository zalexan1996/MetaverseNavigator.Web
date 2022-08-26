using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MN.Domain;

namespace MN.Data.EntityConfigurations
{
    public class MeleeWeaponEntityConfiguration : IEntityTypeConfiguration<MeleeWeapon>
    {
        public void Configure(EntityTypeBuilder<MeleeWeapon> builder)
        {
            builder.Property(x => x.Id).IsRequired().HasAnnotation("SqlServer:Identity", "1, 1");

            builder.HasOne(x => x.MeleeWeaponType).WithMany().IsRequired();
        }
    }
}
