using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MN.Domain;

namespace MN.Data.EntityConfigurations
{
    public class GameItemEntityConfiguration : IEntityTypeConfiguration<GameItem>
    {
        public void Configure(EntityTypeBuilder<GameItem> builder)
        {
            builder.Property(x => x.Id).IsRequired().HasAnnotation("SqlServer:Identity", "1, 1");
        }
    }
}
