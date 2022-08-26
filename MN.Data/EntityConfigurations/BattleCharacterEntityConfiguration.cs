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
    public class BattleCharacterEntityConfiguration : IEntityTypeConfiguration<BattleCharacter>
    {
        public void Configure(EntityTypeBuilder<BattleCharacter> builder)
        {
            builder.Property(x => x.Id).IsRequired().HasAnnotation("SqlServer:Identity", "1, 1");
            
            builder.HasOne(x => x.MeleeWeaponType).WithMany();
            builder.HasOne(x => x.RangedWeaponType).WithMany();
            builder.HasOne(x => x.GameCharacter).WithMany().OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.AwakenedPersona).WithMany().OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(x => x.BasePersona).WithMany().OnDelete(DeleteBehavior.NoAction);
        }
    }
}
