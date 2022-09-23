using StickerAlbum.Model.ImagePlayers;

namespace StickerAlbum.Model.Players
{
    public class Player
    {
        public Player(Guid id, string name, int height, string club, Guid imagePlayerId)
        {
            Id = id;
            Name = name;
            Height = height;
            Club = club;    
            ImagePlayerId = imagePlayerId;
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public int Height { get; set; }

        public string Club { get; set; }

        public Guid ImagePlayerId { get; set; }

        public ImagePlayer? ImagePlayer { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public DateTime? DateDeleted { get; set; }
    }
}
