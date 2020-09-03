using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace image_browser{
    public class Title{
        public long Id {get; set;}
        public string Name  {get;set;}
        public DateTime Release {get;set;}
        public List<TitleCharacter> TitleCharacters {get; set;}
        public Title(){
        }
    }
}