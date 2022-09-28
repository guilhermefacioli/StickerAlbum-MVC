using AutoMapper;
using StickerAlbum.Model.Players;
using StickerAlbum.ViewModel.Player;

namespace StickerAlbum.Api
{
    public class ApiProfile : Profile
    {
        public ApiProfile()
        {
            CreateMap<Player, PlayerViewModel>();

        }
    }
}
