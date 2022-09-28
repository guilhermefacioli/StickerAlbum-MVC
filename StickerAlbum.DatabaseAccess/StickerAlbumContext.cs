using Microsoft.EntityFrameworkCore;
using StickerAlbum.Model.ImagePlayers;
using StickerAlbum.Model.Players;
using StickerAlbum.Model.Teams;

namespace StickerAlbum.DatabaseAccess
{
    public class StickerAlbumContext : DbContext
    {
        public StickerAlbumContext(DbContextOptions<StickerAlbumContext> options) : base(options) 
        {
        }

    public DbSet<Player> Players { get; set; }
    public DbSet<ImagePlayer> ImagePlayers { get; set; }
    public DbSet<Team> Teams { get; set; }

    }
}
