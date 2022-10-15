using Microsoft.EntityFrameworkCore;
using StickerAlbum.DatabaseAccess.Repositories.ImagePlayers;
using StickerAlbum.DatabaseAccess.Repositories.Players;
using StickerAlbum.DatabaseAccess.Repositories.Teams;
using StickerAlbum.Model.ImagePlayers;
using StickerAlbum.Model.Players;
using StickerAlbum.Model.Teams;

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
            services.AddTransient<IImagePlayerRepository, ImagePlayerRepository>();
            services.AddTransient<ITeamRepository, TeamRepository>();

            return services;
        }
    }
}
