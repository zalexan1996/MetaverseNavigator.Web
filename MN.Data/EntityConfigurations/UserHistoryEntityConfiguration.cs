using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

using MN.Domain;

namespace MN.Data.EntityConfigurations
{
    public class UserHistoryEntityConfiguration : IEntityTypeConfiguration<UserHistory>
    {
        public void Configure(EntityTypeBuilder<UserHistory> builder)
        {
            builder.Property(h=>h.Id).IsRequired().HasAnnotation("SqlServer:Identity", "1,1");
            builder.Property(h=>h.UserId).IsRequired();

            builder.HasOne(h=>h.User).WithMany(u=>u.UserHistories);
        }
    }
}