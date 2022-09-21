using Microsoft.EntityFrameworkCore;
using StickerAlbum.DatabaseAccess.Repositories.Players;
using StickerAlbum.Model.Players;

namespace StickerAlbum.DatabaseAccess
{
    public static class DatabaseAccessRegistry
    {
        public static IServiceCollection AddStickerAlbumDatabaseAccess(this IServiceCollection services, string connectionString, bool inMemory = false)
        {
            if (inMemory)
            {
                services.AddDbContext<StickerAlbumContext>(options =>
                options.UseInMemoryDatabase("TestDatabase"));
            }
            else
            {
                services.AddDbContext<StickerAlbumContext>(options =>
                options.UseSqlServer(connectionString));
            }

            services.AddTransient<IPlayerRepository, PlayerRepository>();

            return services;
        }
    }
}
