using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

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
            Path = "";
            Width = 0;
            Height = 0;
            Filetype = null;
            Title = null;
            ImageCharacters = null;
        }
    }
}