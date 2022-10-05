using StickerAlbum.Common;
using StickerAlbum.Filters;

namespace StickerAlbum.Model.ImagePlayers
{
    public interface IImagePlayerRepository
    {
        Task<ApplicationResult> Create(ImagePlayer image);

        Task<ApplicationResult> Update(ImagePlayer image);

        Task<ApplicationResult> Delete(Guid id);

        Task<ApplicationResult<ImagePlayer>> Get(Guid id);

        Task<ApplicationResult<CollectionResult<ImagePlayer>>> GetAll(Filter filter, PagingOptions pagingOptions);

    }
}
