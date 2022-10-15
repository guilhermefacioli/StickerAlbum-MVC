using StickerAlbum.Model.ImagePlayers;
using StickerAlbum.Model.Players;
using StickerAlbum.Model.Teams;

namespace StickerAlbum
{
    public static class DomainRegistry
    {
        public static IServiceCollection AddStickerAlbumDomain(this IServiceCollection services)
        {
            services.AddTransient<IPlayerService, PlayerService>();

            services.AddTransient<IImagePlayerService, ImagePlayerService>();

            services.AddTransient<ITeamService, TeamService>();

            return services;

        }
    }
}
