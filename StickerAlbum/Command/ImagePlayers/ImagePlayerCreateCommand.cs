namespace StickerAlbum.Command.ImagePlayers
{
    public class ImagePlayerCreateCommand
    {
        public ImagePlayerCreateCommand(Guid id, string name, string path, IFormFile file){
          
            Id = id;
            Name = name;
            Path = path;
            File = file;
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Path { get; set; }

        public IFormFile File { get; set; }
    }
}
