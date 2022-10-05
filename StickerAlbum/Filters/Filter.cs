namespace StickerAlbum.Filters
{
    public class Filter
    {
        public Filter(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

    }
}
