using System;
using System.Collections.Generic;

namespace image_browser{
    public class Title{
        public ulong Id {get; set;}
        public string Name  {get;set;}
        public DateTime Release {get;set;}
        public List<Character> Characters;
        public Title(){
        }
    }
}