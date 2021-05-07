using Application.Common;
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
                .HasMaxLength(Constraints.MaxRoleTitleLength);

            builder
                .HasMany(x => x.Users)
                .WithOne(y => y.Role)
                .HasForeignKey(y => y.RoleId);
        }
    }
}