using StickerAlbum.Command.Players;
using StickerAlbum.Common;
using StickerAlbum.Filters;

namespace StickerAlbum.Model.Players
{
    public interface IPlayerService
    {
        Task<ApplicationResult<Player>> CreatePlayer(PlayerCreateCommand command);

        Task<ApplicationResult> UpdatePlayer(Guid id, PlayerUpdateCommand command);

        Task<ApplicationResult> DeletePlayer(Guid id);

        Task<ApplicationResult<Player>> GetPlayer(Guid id);

        Task<ApplicationResult<CollectionResult<Player>>> GetAllPlayer(PlayerFilter filter, PagingOptions pagingOptions);

    }
}
