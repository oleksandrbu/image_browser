using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace image_browser{
    public class Title{
        public long Id {get; set;}
        public string Name  {get;set;}
        public DateTime Release {get;set;}
        [JsonIgnore]
        public List<TitleCharacter> TitleCharacters {get; set;}
        public Title(){
        }
    }
}