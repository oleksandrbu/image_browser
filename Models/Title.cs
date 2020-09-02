using System;
using System.Collections.Generic;

namespace image_browser{
    public class Title{
        ulong Id {get; set;}
        string Name  {get;set;}
        DateTime Release {get;set;}
        List<Character> Characters {get; set;}
        public Title(){
        }
    }
}