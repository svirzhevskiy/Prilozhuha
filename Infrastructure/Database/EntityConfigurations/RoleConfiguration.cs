using Database.Extensions;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.EntityConfigurations
{
    public class RoleConfiguration : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.DefaultConfiguration("Roles");

            builder
                .Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(10);

            builder
                .HasMany(x => x.Users)
                .WithOne(y => y.Role)
                .HasForeignKey(y => y.RoleId);
        }
    }
}