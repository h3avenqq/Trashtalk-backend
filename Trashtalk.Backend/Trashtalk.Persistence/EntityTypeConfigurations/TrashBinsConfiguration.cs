using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trashtalk.Domain;

namespace Trashtalk.Persistence.EntityTypeConfigurations
{
    public class TrashBinsConfiguration : IEntityTypeConfiguration<TrashBin>
    {
        public void Configure(EntityTypeBuilder<TrashBin> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Id).IsUnique();
            builder.Property(x => x.Name).HasMaxLength(50).IsRequired();
            builder.Property(x=>x.Color).HasMaxLength(7).IsRequired();
            builder.HasMany(x=>x.TrashTypes)
                .WithOne(x=>x.TrashBin)
                .HasForeignKey(x=>x.TrashBinId)
                .HasPrincipalKey(x=>x.Id);
        }
    }
}
