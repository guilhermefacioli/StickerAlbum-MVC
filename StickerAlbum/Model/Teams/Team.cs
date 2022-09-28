namespace StickerAlbum.Model.Teams
{
    public class Team
    {
        public Team(Guid id, string name, string primaryColor, string secondaryColor)
        {
            Id = id;
            Name = name;
            PrimaryColor = primaryColor;
            SecondaryColor = secondaryColor;
        }

        public Guid Id { get; set; }

        public string  Name { get; set; }

        public string PrimaryColor { get; set; }

        public string SecondaryColor { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public DateTime? DateDeleted { get; set; }

    }
}
