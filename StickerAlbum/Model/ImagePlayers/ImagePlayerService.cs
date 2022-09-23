using StickerAlbum.Command.ImagePlayers;
using StickerAlbum.Common;

namespace StickerAlbum.Model.ImagePlayers
{
    public class ImagePlayerService : IImagePlayerService
    {
        private readonly IImagePlayerRepository _imagePlayerRepository;

        public ImagePlayerService(IImagePlayerRepository imagePlayerRepository)
        {
            _imagePlayerRepository = imagePlayerRepository;
        }

        public async Task<ApplicationResult<ImagePlayer>> CreateImage(ImagePlayerCreateCommand command)
        {
            var path = Path.GetTempPath();

            var extension = command.File.FileName.Split('.').Last();

            path = Path.Combine(path, $"{command.Name}.{extension}");
            
            using var stream = File.Create(path);

            command.File.CopyTo(stream);

            var entity = new ImagePlayer(
                Guid.NewGuid(),
                command.Name,
                path, 
                DateTime.Now);

            var cretionResult = await _imagePlayerRepository.Create(entity);

            var result = new ApplicationResult<ImagePlayer>
            {
                Result = cretionResult.IsSuceccss ? entity : null,
                Errors = cretionResult.Errors
            };

            return result;
                
        }

        public async Task<ApplicationResult> DeleteImage(Guid id)
        {
            var deleteResult = await _imagePlayerRepository.Delete(id);

            var result = new ApplicationResult
            {
                Errors = deleteResult.Errors
            };

            return result;
        }

        public Task<ApplicationResult<ImagePlayer>> GetImage(Guid id)
        {
            return _imagePlayerRepository.Get(id);
        }
    }
}
