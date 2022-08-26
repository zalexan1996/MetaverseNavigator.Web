using MN.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MN.Data.EntityConfigurations
{
    public class UserEntityConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.Property(u=>u.Id).IsRequired().HasAnnotation("SqlServer:Identity", "1,1");
            builder.Property(u=>u.Username).IsRequired();
            builder.Property(u=>u.Password).IsRequired();

            builder.HasOne(u=>u.UserType).WithMany(t=>t.Users);
            builder.HasMany(u=>u.UserHistories).WithOne(h=>h.User);
        }
    }
}