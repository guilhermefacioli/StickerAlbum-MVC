namespace StickerAlbum.Filters
{
    public class PlayerFilter
    {
        public PlayerFilter(Guid id,string name, string club)
        {
            Id = id;
            Name = name;
            Club = club;
        }

        public Guid Id { get; set; }

        public string  Name { get; set; }

        public string Club { get; set; }

    }
}
