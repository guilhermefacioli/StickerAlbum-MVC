using Microsoft.EntityFrameworkCore;
using StickerAlbum.Model.ImagePlayers;
using StickerAlbum.Model.Players;

namespace StickerAlbum.DatabaseAccess
{
    public class StickerAlbumContext : DbContext
    {
        public StickerAlbumContext(DbContextOptions<StickerAlbumContext> options) : base(options) 
        {
        }

    public DbSet<Player> Players { get; set; }
    public DbSet<ImagePlayer> ImagePlayers { get; set; }

    }
}
