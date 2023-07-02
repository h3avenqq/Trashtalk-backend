using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trashtalk.Domain;

namespace Trashtalk.Persistence.EntityTypeConfigurations
{
    public class NewsConfiguration : IEntityTypeConfiguration<News>
    {
        public void Configure(EntityTypeBuilder<News> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Id).IsUnique();
            builder.Property(x => x.Title).HasMaxLength(128).IsRequired();
            builder.Property(x => x.BriefDescription).HasMaxLength(250).IsRequired();
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.PublishDate).IsRequired();
            builder.Property(x => x.AuthorId).IsRequired();
            builder.HasOne(x => x.Author)
                .WithMany(x => x.News)
                .HasForeignKey(x => x.AuthorId)
                .HasPrincipalKey(x => x.Id);
        }
    }
}
