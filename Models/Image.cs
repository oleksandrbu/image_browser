namespace image_browser{
    public class Image{
        public ulong Id {get; set;}
        public string Path  {get;set;}
        public uint Width {get; set;}
        public uint Height {get;set;}
        public Filetype FiletypeId {get; set;}
        public Title TitleId {get; set;}
        public Character Characters;
        public Image(){

        }
    }
}