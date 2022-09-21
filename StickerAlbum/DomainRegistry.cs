using StickerAlbum.Model.Players;

namespace StickerAlbum
{
    public static class DomainRegistry
    {
        public static IServiceCollection AddStickerAlbumDomain(this IServiceCollection services)
        {
            services.AddTransient<IPlayerService, PlayerService>();

            return services;

        }
    }
}
