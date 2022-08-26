using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MN.Domain;

namespace MN.Data.EntityConfigurations
{
    public class ConfidantResponseEntityConfiguration : IEntityTypeConfiguration<ConfidantResponses>
    {

        public void Configure(EntityTypeBuilder<ConfidantResponses> builder)
        {
            builder.Property(x => x.Id).IsRequired().HasAnnotation("SqlServer:Identity", "1, 1");
            
            builder.HasOne(x => x.Confidant).WithMany().IsRequired();

        }
    }
}
