using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace image_browser{
    public class Character{
        public ulong Id {get; set;}
        public string Name  {get;set;}
        public uint Age {get;set;}
        [NotMapped]
        public List<Title> Titles;
        public Character(){
        }
    }
}