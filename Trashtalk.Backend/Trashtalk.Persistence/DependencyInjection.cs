using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Trashtalk.Application.Interfaces;

namespace Trashtalk.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services,
            IConfiguration configuration)
        {
            var connection = configuration["DbConnection"];
            services.AddDbContext<TrashTalkDbContext>(opt =>
            {
                opt.UseNpgsql(connection,
                    x=>x.UseNetTopologySuite());
            });

            services.AddScoped<ITrashTalkDbContext>(provider =>
                provider.GetService<TrashTalkDbContext>());

            return services;
        }
    }
}
