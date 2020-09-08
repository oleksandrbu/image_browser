using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace image_browser{
    public class Character{
        public long Id {get; set;}
        public string Name  {get;set;}
        public int Age {get;set;}
        [JsonIgnore]
        public List<TitleCharacter> TitleCharacters {get; set;}
        [JsonIgnore]
        public List<ImageCharacter> ImageCharacters {get; set;}
        public Character(){
        }
    }
}