using StickerAlbum.Command.ImagePlayers;
using StickerAlbum.Common;
using StickerAlbum.Filters;

namespace StickerAlbum.Model.ImagePlayers
{
    public interface IImagePlayerService
    {
        Task<ApplicationResult<ImagePlayer>> CreateImage(ImagePlayerCreateCommand command);

        Task<ApplicationResult> DeleteImage(Guid id);

        Task<ApplicationResult<ImagePlayer>> GetImage(Guid id);

        Task<ApplicationResult<CollectionResult<ImagePlayer>>> GetAllImage(Filter filter, PagingOptions pagingOptions);


    }
}
