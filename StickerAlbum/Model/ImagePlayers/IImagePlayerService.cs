using StickerAlbum.Command.ImagePlayers;
using StickerAlbum.Common;

namespace StickerAlbum.Model.ImagePlayers
{
    public interface IImagePlayerService
    {
        Task<ApplicationResult<ImagePlayer>> CreateImage(ImagePlayerCreateCommand command);

        Task<ApplicationResult> DeleteImage(Guid id);

        Task<ApplicationResult<ImagePlayer>> GetImage(Guid id);

    }
}
