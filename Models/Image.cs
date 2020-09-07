using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace image_browser{
    public class Image{
        public long Id {get; set;}
        public string Path  {get;set;}
        public int Width {get; set;}
        public int Height {get;set;}
        public Filetype Filetype {get; set;}
        public Title Title {get; set;}
        public List<ImageCharacter> ImageCharacters {get; set;}
        public Image(){
        }
        public Image(ImageDTO image, Filetype type, Title title){
            Path = image.Path;
            Width = image.Width;
            Height = image.Height;
            Filetype = type;
            Title = title;
        }
    }

    public class ImageDTO{
                public long Id {get; set;}
        public string Path  {get;set;}
        public int Width {get; set;}
        public int Height {get;set;}
        public long FiletypeId {get; set;}
        public long TitleId {get; set;}
        public long[] ImageCharacterId {get; set;}
        public ImageDTO(){
        }
    }

    public class ImageSearch{
        public long? width {get; set;}
        public long? minWidth {get; set;}
        public long? maxWidth {get; set;} 
        public long? height {get; set;} 
        public long? minHeight {get; set;} 
        public long? maxHeight {get; set;} 
        public long? filetype {get; set;}
    }
}