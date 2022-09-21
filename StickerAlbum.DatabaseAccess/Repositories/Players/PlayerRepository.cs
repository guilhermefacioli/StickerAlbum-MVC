using Microsoft.EntityFrameworkCore;
using StickerAlbum.Common;
using StickerAlbum.Filters;
using StickerAlbum.Model.Players;

namespace StickerAlbum.DatabaseAccess.Repositories.Players
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly StickerAlbumContext _context;

        private IQueryable<Player> Players => _context.Players.AsQueryable();

        public PlayerRepository(StickerAlbumContext context)
        {
            _context = context;
        }

        public async Task<ApplicationResult> Create(Player player)
        {
            player.DateCreated = DateTime.UtcNow;
            player.DateModified = DateTime.UtcNow;

            await _context.AddAsync(player);
            await _context.SaveChangesAsync();

            return new ApplicationResult();
        }

        public async Task<ApplicationResult> Update(Player player)
        {
            var item = await _context.Players.FindAsync(player.Id);

            item.Name = player.Name;
            item.Club = player.Club;
            item.Height = player.Height;
            item.DateModified = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return new ApplicationResult();
        }

        public async Task<ApplicationResult> Delete(Guid id)
        {
            var item = await _context.Players.FindAsync(id);

            item.DateDeleted = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return new ApplicationResult();
        }

        public async Task<ApplicationResult<Player>> Get(Guid id)
        {
            var item = await Players.Where(x => x.Id == id).ToListAsync();

            var result = new ApplicationResult<Player>()
            {
                Result = item.FirstOrDefault()
            };
            if (!item.Any())
            {
                result.Errors.Add($"No items found for the id: {id}");
            }

            return result;
        }

        public Task<ApplicationResult<CollectionResult<Player>>> GetAll(PlayerFilter filter, PagingOptions pagingOptions)
        {
            throw new NotImplementedException();
        }
    }
}
