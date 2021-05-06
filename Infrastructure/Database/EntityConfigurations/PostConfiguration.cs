using Database.Extensions;
using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Database.EntityConfigurations
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.DefaultConfiguration("Posts");

            builder
                .Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(100);

            builder
                .Property(x => x.Content)
                .IsRequired();

            builder
                .Property(x => x.PublishDate)
                .IsRequired();
        }
    }
}