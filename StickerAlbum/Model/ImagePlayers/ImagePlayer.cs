using StickerAlbum.Model.Players;

namespace StickerAlbum.Model.ImagePlayers
{
    public class ImagePlayer
    {
        public ImagePlayer(Guid id, string name, string path, DateTime dateCreated)
        {
            Id = id;
            Name = name;
            Path = path;
            DateCreated = dateCreated;
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Path { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime? DateDeleted { get; set; }

    }
}
