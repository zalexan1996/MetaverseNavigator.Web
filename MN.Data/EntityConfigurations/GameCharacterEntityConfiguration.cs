using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using MN.Domain;

namespace MN.Data.EntityConfigurations
{
    public class GameCharacterEntityConfiguration : IEntityTypeConfiguration<GameCharacter>
    {
        public void Configure(EntityTypeBuilder<GameCharacter> builder)
        {
            builder.Property(x => x.Id).IsRequired().HasAnnotation("SqlServer:Identity", "1, 1");
            
        }
    }
}
