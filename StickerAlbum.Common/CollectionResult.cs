namespace StickerAlbum.Common;

    public class CollectionResult<T>
    {
        public int Total { get; set; }

        public List<T>? Items { get; set; }
    }

