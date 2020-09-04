using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace image_browser{
    public class Character{
        public long Id {get; set;}
        public string Name  {get;set;}
        public int Age {get;set;}
        public List<TitleCharacter> TitleCharacters {get; set;}
        public List<ImageCharacter> ImageCharacters {get; set;}
        public Character(){
        }
    }
}