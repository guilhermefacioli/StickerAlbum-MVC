namespace StickerAlbum.Command.Players
{
    public class PlayerCreateCommand
    {
        public PlayerCreateCommand( string name, int height, string club, Guid imagePlayerId)
        {
            Name = name;
            Height = height;
            Club = club;
            ImagePlayerId = imagePlayerId;
        }

        public string Name { get; set; }

        public int Height { get; set; }

        public string Club { get; set; }

        public Guid ImagePlayerId { get; set; }

    }
}
