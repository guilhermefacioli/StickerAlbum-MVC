using StickerAlbum.Command.Teams;
using StickerAlbum.Common;
using StickerAlbum.Filters;

namespace StickerAlbum.Model.Teams
{
    public class TeamService : ITeamService
    {
        private readonly ITeamRepository _teamRepository;

        public TeamService(ITeamRepository teamRepository)
        {
            _teamRepository = teamRepository;
        }

        public async Task<ApplicationResult<Team>> CreateTeam(TeamCreateCommand command)
        {
            var entity = new Team(
                Guid.NewGuid(), 
                command.Name, 
                command.PrimaryColor, 
                command.SecondaryColor
                );

            var creationResult = await _teamRepository.Create(entity);

            var result = new ApplicationResult<Team>
            {
                Result = creationResult.IsSuceccss ? entity : null,//Como ler essa linha
                Errors = creationResult.Errors
            };

            return result;
        
        }

        public async Task<ApplicationResult> UpdateTeam(Guid id, TeamUpdateCommand command)
        {
            var searchResult = await _teamRepository.Get(id);

            var entity = searchResult.Result;

            if (entity == null)
            {
                return new ApplicationResult
                {
                    Errors = new List<string> { "Team not found!" }
                };
            }
                entity.Id = id;
                entity.Name = command.Name;
                entity.PrimaryColor = command.PrimaryColor;
                entity.SecondaryColor = command.SecondaryColor;

                var updateResult = await _teamRepository.Update(entity);

                var result = new ApplicationResult<Team>
                {
                    Result = updateResult.IsSuceccss ? entity : null,
                    Errors = updateResult.Errors
                };
            return result;
        }

        public async Task<ApplicationResult> DeleteTeam(Guid id)
        {
            var deleteResult = await _teamRepository.Delete(id);

            var result = new ApplicationResult
            {
                Errors = deleteResult.Errors
            };

            return result;
        }

        public Task<ApplicationResult<Team>> GetTeam(Guid id)
        {
            return _teamRepository.Get(id);
        }

        public Task<ApplicationResult<CollectionResult<Team>>> GetAllTeam(Filter filter, PagingOptions pagingOptions)
        {
            return _teamRepository.GetAll(filter, pagingOptions);
        }
    }
}
