using StickerAlbum.Command.Players;
using StickerAlbum.Common;
using StickerAlbum.Filters;

namespace StickerAlbum.Model.Players
{
    public class PlayerService : IPlayerService
    {
        private IPlayerRepository _playerRepository;

        public PlayerService(IPlayerRepository playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public async Task<ApplicationResult<Player>> CreatePlayer(PlayerCreateCommand command)
        {
            var entity = new Player(Guid.NewGuid(), command.Name, command.Height, command.Club);

            var creationResult = await _playerRepository.Create(entity);

            var result = new ApplicationResult<Player>
            {
                Result = creationResult.IsSuceccss ? entity : null,
                Errors = creationResult.Errors
            };

            return result;
        }
        public async Task<ApplicationResult> UpdatePlayer(Guid id, PlayerUpdateCommand command)
        {
            var searchResult = await _playerRepository.Get(id);

            var entity = searchResult.Result;

            if(entity == null)
            {
                return new ApplicationResult
                {
                    Errors = new List<string> { "Player not found!" }
                };
            }

            entity.Name = command.Name;
            entity.Club = command.Club;
            entity.Height = command.Height;

            var updateResult = await _playerRepository.Update(entity);

            var result = new ApplicationResult<Player>
            {
                Result = updateResult.IsSuceccss ? entity : null,
                Errors = updateResult.Errors
            };

            return result;
        }

        public async Task<ApplicationResult> DeletePlayer(Guid id)
        {
            var deleteResult = await _playerRepository.Delete(id);

            var result = new ApplicationResult
            {
                Errors = deleteResult.Errors
            };

            return result;
        }

        public Task<ApplicationResult<CollectionResult<Player>>> GetAllPlayer(PlayerFilter filter, PagingOptions pagingOptions)
        {
            return _playerRepository.GetAll(filter, pagingOptions);
        }

        public Task<ApplicationResult<Player>> GetPlayer(Guid id)
        {
            return _playerRepository.Get(id);
        }

        
    }
}
