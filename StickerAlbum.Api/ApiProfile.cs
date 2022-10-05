using AutoMapper;
using StickerAlbum.Filters;
using StickerAlbum.Model.ImagePlayers;
using StickerAlbum.Model.Players;
using StickerAlbum.Model.Teams;
using StickerAlbum.ViewModel.ImagePlayers;
using StickerAlbum.ViewModel.Players;
using StickerAlbum.ViewModel.Teams;

namespace StickerAlbum.Api
{
    public class ApiProfile : Profile
    {
        public ApiProfile()
        {
            CreateMap<Player, PlayerViewModel>();
            CreateMap<FilterPlayerViewModel, PlayerFilter>();

            CreateMap<Team, TeamViewModel>();
            CreateMap<FilterTeamViewModel, Filter>();

            CreateMap<ImagePlayer, ImagePlayerViewModel>();
            CreateMap<FilterImagePlayerViewModel, Filter>();


        }
    }
}
