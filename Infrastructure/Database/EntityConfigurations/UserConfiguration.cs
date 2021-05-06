using Database.Extensions;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.EntityConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.DefaultConfiguration("Users");

            builder
                .Property(x => x.Email)
                .IsRequired()
                .HasMaxLength(50);

            builder
                .Property(x => x.Password)
                .IsRequired();

            builder
                .Property(x => x.Name)
                .HasMaxLength(20);

            builder
                .Property(x => x.Surname)
                .HasMaxLength(30);

            builder
                .HasMany(x => x.Posts)
                .WithOne(y => y.Author)
                .HasForeignKey(y => y.AuthorId);
        }
    }
}