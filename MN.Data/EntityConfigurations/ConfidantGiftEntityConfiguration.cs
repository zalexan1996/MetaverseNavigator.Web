using MN.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MN.Data.EntityConfigurations
{
    public class ConfidantGiftEntityConfiguration : IEntityTypeConfiguration<ConfidantGift>
    {
        public void Configure(EntityTypeBuilder<ConfidantGift> builder)
        {
            builder.Property(x => x.Id).IsRequired().HasAnnotation("SqlServer:Identity", "1, 1");
            
            builder.HasOne(x => x.Confidant).WithMany().IsRequired();
            builder.HasOne(x => x.GameItem).WithMany().IsRequired();

        }
    }
}
