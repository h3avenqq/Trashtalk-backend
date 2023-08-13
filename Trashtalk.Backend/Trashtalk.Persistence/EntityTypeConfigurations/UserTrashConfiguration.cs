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
            builder.Property(x => x.TrashId).IsRequired(); ;
            builder.Property(x=>x.UserId).IsRequired();
            builder.HasOne(x => x.Trash)
                .WithMany(x => x.UserTrash)
                .HasForeignKey(x => x.TrashId)
                .HasPrincipalKey(x => x.Id);
            builder.Property(x => x.Coordinates).IsRequired();
            builder.Property(x => x.Time).IsRequired();
        }
    }
}
