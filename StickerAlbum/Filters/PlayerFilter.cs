namespace StickerAlbum.Filters
{
    public class PlayerFilter : Filter
    {
        public PlayerFilter(string club, Guid id, string name)
            :base(id, name)
        {
            Club = club;
        }

        public string Club { get; set; }

    }
}
