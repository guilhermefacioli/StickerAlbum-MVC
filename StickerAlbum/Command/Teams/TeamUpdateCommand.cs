namespace StickerAlbum.Command.Teams
{
    public class TeamUpdateCommand
    {
        public TeamUpdateCommand(string name, string primaryColor, string secondaryColor)
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
