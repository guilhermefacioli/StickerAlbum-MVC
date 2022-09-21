namespace StickerAlbum.Command.Players
{
    public class PlayerUpdateCommand
    {
        public PlayerUpdateCommand(string name, int height, string club)
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
