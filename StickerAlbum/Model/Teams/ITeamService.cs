using StickerAlbum.Command.Teams;
using StickerAlbum.Common;
using StickerAlbum.Filters;

namespace StickerAlbum.Model.Teams
{
    public interface ITeamService
    {
        Task<ApplicationResult<Team>> CreateTeam(TeamCreateCommand command);

        Task<ApplicationResult> UpdateTeam (Guid id, TeamUpdateCommand command);

        Task<ApplicationResult> DeleteTeam(Guid id);

        Task<ApplicationResult<Team>> GetTeam(Guid id);

        Task<ApplicationResult<CollectionResult<Team>>> GetAllTeam(Filter filter, PagingOptions pagingOptions);
    }
}
