using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace image_browser{
    public class Character{
        public ulong Id {get; set;}
        public string Name  {get;set;}
        public uint Age {get;set;}
        public List<TitleCharacter> TitleCharacters {get; set;}
        public List<ImageCharacter> ImageCharacters {get; set;}
    }
}