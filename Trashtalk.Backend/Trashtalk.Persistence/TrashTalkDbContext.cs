using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Trashtalk.Application.Interfaces;
using Trashtalk.Domain;
using Trashtalk.Persistence.EntityTypeConfigurations;

namespace Trashtalk.Persistence
{
    public class TrashTalkDbContext :  DbContext, ITrashTalkDbContext
    {
        public DbSet<News> News { get; set; }
        public DbSet<ReceptionPoint> ReceptionPoints { get; set; }
        public DbSet<Trash> Trash { get; set; }
        public DbSet<TrashType> TrashTypes { get; set; }
        public DbSet<TrashBin> TrashBins { get; set; }

        public TrashTalkDbContext(DbContextOptions<TrashTalkDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new TrashConfiguration());
            modelBuilder.ApplyConfiguration(new TrashTypeConfiguration());
            modelBuilder.ApplyConfiguration(new TrashBinsConfiguration());
            modelBuilder.ApplyConfiguration(new NewsConfiguration());
            modelBuilder.ApplyConfiguration(new ReceptionPointsConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
