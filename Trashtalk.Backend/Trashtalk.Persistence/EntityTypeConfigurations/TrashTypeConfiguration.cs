using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trashtalk.Domain;

namespace Trashtalk.Persistence.EntityTypeConfigurations
{
    public class TrashTypeConfiguration : IEntityTypeConfiguration<TrashType>
    {
        public void Configure(EntityTypeBuilder<TrashType> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Id).IsUnique();
            builder.Property(x => x.Name).HasMaxLength(50);
            builder.HasOne(x=>x.TrashBin)
                .WithMany(x=>x.TrashTypes)
                .HasForeignKey(x=>x.TrashBinId)
                .HasPrincipalKey(x=>x.Id);
            builder.HasMany(x => x.Trash)
                .WithOne(x => x.Type)
                .HasForeignKey(x => x.TypeId)
                .HasPrincipalKey(x => x.Id);
        }
    }
}
