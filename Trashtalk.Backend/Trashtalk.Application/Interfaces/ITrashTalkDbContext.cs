using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Trashtalk.Domain;

namespace Trashtalk.Application.Interfaces
{
    public interface ITrashTalkDbContext
    {
        DbSet<News> News { get; set; }
        DbSet<ReceptionPoint> ReceptionPoints { get; set; }
        DbSet<Trash> Trash { get; set; }
        DbSet<TrashType> TrashTypes { get; set; }
        DbSet<TrashBin> TrashBins { get; set; }
        DbSet<UserTrash> UserTrash { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
