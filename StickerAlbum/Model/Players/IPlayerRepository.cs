using StickerAlbum.Common;
using StickerAlbum.Filters;

namespace StickerAlbum.Model.Players
{
    public interface IPlayerRepository
    {
        Task<ApplicationResult> Create(Player player);

        Task<ApplicationResult> Update(Player player);

        Task<ApplicationResult> Delete(Guid id);

        Task<ApplicationResult<Player>> Get(Guid id);

        Task<ApplicationResult<CollectionResult<Player>>> GetAll(PlayerFilter filter, PagingOptions pagingOptions);
    }
}
