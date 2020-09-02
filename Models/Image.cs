namespace image_browser{
    public class Image{
        ulong Id {get; set;}
        string Path  {get;set;}
        uint Width {get; set;}
        uint Height {get;set;}
        Filetype FiletypeId {get; set;}
        Title TitleId {get; set;}
        Character Characters {get; set;}
        public Image(){

        }
    }
}