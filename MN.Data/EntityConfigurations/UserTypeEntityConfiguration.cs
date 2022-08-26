using MN.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MN.Data.EntityConfigurations
{
    public class UserTypeEntityConfiguration : IEntityTypeConfiguration<UserType>
    {
        public void Configure(EntityTypeBuilder<UserType> builder)
        {
            builder.Property(u=>u.Id).IsRequired().HasAnnotation("SqlServer:Identity", "1,1");
            builder.Property(t=>t.TypeName).IsRequired();
            
            builder.HasMany(t=>t.Users).WithOne(u=>u.UserType);
        }
    }
}