namespace StickerAlbum.Model.Players
{
    public class Player
    {
        public Player(Guid id, string name, int height, string club)
        {
            Id = id;
            Name = name;
            Height = height;
            Club = club;    
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public int Height { get; set; }

        public string Club { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime DateModified { get; set; }

        public DateTime? DateDeleted { get; set; }
    }
}
