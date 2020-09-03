using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace image_browser{
    public class Image{
        public ulong Id {get; set;}
        public string Path  {get;set;}
        public uint Width {get; set;}
        public uint Height {get;set;}
        public Filetype Filetype {get; set;}
        public Title Title {get; set;}
        public List<ImageCharacter> ImageCharacters {get; set;}
        public Image(){
        }
    }
}