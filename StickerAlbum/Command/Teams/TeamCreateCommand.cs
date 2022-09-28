namespace StickerAlbum.Command.Teams
{
    public class TeamCreateCommand
    {
        public TeamCreateCommand(string name, string primaryColor, string secondaryColor)
        {
            Name = name;
            PrimaryColor = primaryColor;
            SecondaryColor = secondaryColor;
        }

        public string Name { get; set; }

        public string PrimaryColor { get; set; }

        public string SecondaryColor { get; set; }
    }
}
