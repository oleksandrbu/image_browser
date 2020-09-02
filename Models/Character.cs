using System.Collections.Generic;

namespace image_browser{
    public class Character{
        ulong Id {get; set;}
        string Name  {get;set;}
        uint Age {get;set;}
        List<Title> Titles {get; set;}
        public Character(){
        }
    }
}