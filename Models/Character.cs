using System.Collections.Generic;

namespace image_browser{
    public class Character{
        public ulong Id {get; set;}
        public string Name  {get;set;}
        public uint Age {get;set;}
        public List<Title> Titles;
        public Character(){
        }
    }
}