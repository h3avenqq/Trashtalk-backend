using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Trashtalk.Domain;

namespace Trashtalk.Persistence.EntityTypeConfigurations
{
    public class UserTrashConfiguration : IEntityTypeConfiguration<UserTrash>
    {
        public void Configure(EntityTypeBuilder<UserTrash> builder)
        {
            builder.HasKey(x => x.Id);
            builder.HasIndex(x => x.Id).IsUnique();
            builder.HasOne(x => x.Trash)
                .WithMany(x => x.UserTrash)
                .HasForeignKey(x => x.TrashId)
                .HasPrincipalKey(x => x.Id);
            builder.Property(x => x.Country).HasMaxLength(50);
            builder.Property(x=>x.Region).HasMaxLength(50);
            builder.Property(x=>x.City).HasMaxLength(50);
            builder.Property(x => x.District).HasMaxLength(50);
        }
    }
}
