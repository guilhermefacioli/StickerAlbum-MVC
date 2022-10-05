using Microsoft.EntityFrameworkCore;
using StickerAlbum.Common;
using StickerAlbum.Filters;
using StickerAlbum.Model.ImagePlayers;

namespace StickerAlbum.DatabaseAccess.Repositories.ImagePlayers
{
    public class ImagePlayerRespository : IImagePlayerRepository
    {
        private readonly StickerAlbumContext _context;
        private IQueryable<ImagePlayer> ImagePlayers => _context.ImagePlayers.AsQueryable();

        public ImagePlayerRespository (StickerAlbumContext context)
        {
            _context = context;
        }

        public async Task<ApplicationResult> Create (ImagePlayer imagePlayer)
        {
            imagePlayer.DateCreated = DateTime.Now;
            await _context.AddAsync(imagePlayer);
            await _context.SaveChangesAsync();

            return new ApplicationResult();
        }

        public async Task<ApplicationResult> Update(ImagePlayer imagePlayer)
        {
            var item = await _context.ImagePlayers.FindAsync(imagePlayer.Id);

            //Aqui só da para alterar isso? e se quiser trocar a imagem?
            item.Name = imagePlayer.Name;
            item.Path = imagePlayer.Path;

            await _context.SaveChangesAsync();

            return new ApplicationResult();
            
        }

        public async Task<ApplicationResult> Delete(Guid id)
        {
            var item = await _context.ImagePlayers.FindAsync(id);

            item.DateDeleted = DateTime.UtcNow;

            await _context.SaveChangesAsync();

            return new ApplicationResult();
        }

        public async Task<ApplicationResult<ImagePlayer>> Get(Guid id)
        {
            var item = await ImagePlayers.Where(x => x.Id == id).ToListAsync();

            var result = new ApplicationResult<ImagePlayer>
            {
                Result = item.FirstOrDefault()
            };

            if (!item.Any())
            {
                result.Errors.Add($"No items found for the id: {id}");
            }

            return result;
        }

        public async Task<ApplicationResult<CollectionResult<ImagePlayer>>> GetAll(Filter filter, PagingOptions pagingOptions)
        {
            var query = ImagePlayers;

            if (filter.Name != null)
            {
                query = query.Where(x => x.Name == filter.Name);
            }

            var items = await query.Skip(pagingOptions.Offset).Take(pagingOptions.Limit).ToListAsync();
            var total = await query.CountAsync();

            var result = new ApplicationResult<CollectionResult<ImagePlayer>>
            {
                Result = new CollectionResult<ImagePlayer>
                {
                    Total = total,
                    Items = items
                }
            };

            if (total == 0)
            {
                result.Errors.Add("No items found for the specified criteria");
            }

            return result;
        }
    }
}
