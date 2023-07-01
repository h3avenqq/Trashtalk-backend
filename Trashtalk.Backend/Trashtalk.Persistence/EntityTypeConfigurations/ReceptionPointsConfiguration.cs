using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trashtalk.Domain;

namespace Trashtalk.Persistence.EntityTypeConfigurations
{
    public class ReceptionPointsConfiguration : IEntityTypeConfiguration<ReceptionPoint>
    {
        public void Configure(EntityTypeBuilder<ReceptionPoint> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Id).IsUnique();
            builder.Property(x => x.Name).HasMaxLength(50).IsRequired();
            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.Address).HasMaxLength(128).IsRequired();
            builder.Property(x => x.Coordinates).IsRequired();
            builder.HasMany(x=>x.News)
                .WithOne(x=>x.Author)
                .HasForeignKey(x=>x.AuthorId)
                .HasPrincipalKey(x=>x.Id);
        }
    }
}
