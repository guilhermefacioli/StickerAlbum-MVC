namespace StickerAlbum.Command.Players
{
    public class PlayerCreateCommand
    {
        public PlayerCreateCommand( string name, int height, string club)
        {
            Name = name;
            Height = height;
            Club = club;
        }

        public string Name { get; set; }

        public int Height { get; set; }

        public string Club { get; set; }

    }
}
