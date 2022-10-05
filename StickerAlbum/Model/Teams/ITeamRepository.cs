using StickerAlbum.Common;
using StickerAlbum.Filters;

namespace StickerAlbum.Model.Teams
{
    public interface ITeamRepository
    {
        Task<ApplicationResult> Create(Team team);

        Task<ApplicationResult> Update(Team team);

        Task<ApplicationResult> Delete(Guid id);

        Task<ApplicationResult<Team>> Get(Guid id);

        Task<ApplicationResult<CollectionResult<Team>>> GetAll(Filter filter, PagingOptions pagingOptions);
    }
}
