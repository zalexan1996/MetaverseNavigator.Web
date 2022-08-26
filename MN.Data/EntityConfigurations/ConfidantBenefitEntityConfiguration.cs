using MN.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MN.Data.EntityConfigurations
{
    public class ConfidantBenefitEntityConfiguration : IEntityTypeConfiguration<ConfidantBenefit>
    {
        public void Configure(EntityTypeBuilder<ConfidantBenefit> builder)
        {
            builder.Property(x => x.Id).IsRequired().HasAnnotation("SqlServer:Identity", "1, 1");
            
            builder.HasOne(x => x.Confidant).WithMany();
            builder.Property(x => x.RankUnlocked).IsRequired();
            builder.Property(x=>x.AdditionalRequirement).IsRequired(false);
        }
    }
}
