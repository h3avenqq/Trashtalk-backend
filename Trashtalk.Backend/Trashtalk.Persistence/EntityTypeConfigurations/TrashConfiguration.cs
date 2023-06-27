using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trashtalk.Domain;

namespace Trashtalk.Persistence.EntityTypeConfigurations
{
    public class TrashConfiguration : IEntityTypeConfiguration<Trash>
    {
        public void Configure(EntityTypeBuilder<Trash> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Id).IsUnique();
            builder.Property(x => x.Name).HasMaxLength(50);
            builder.HasIndex(x => x.Barcode).IsUnique();
            builder.HasOne(x => x.Type)
                .WithMany(x => x.Trash)
                .HasForeignKey(x => x.TypeId)
                .HasPrincipalKey(x => x.Id);
            builder.HasMany(x => x.UserTrash)
                .WithOne(x => x.Trash)
                .HasForeignKey(x => x.TrashId)
                .HasPrincipalKey(x => x.Id);
        }
    }
}
