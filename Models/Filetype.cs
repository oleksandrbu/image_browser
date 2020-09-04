using System.ComponentModel.DataAnnotations.Schema;

namespace image_browser{
    public class Filetype{
        public long Id {get; set;}
        public string Type  {get;set;}
        public Filetype(){
        }
    }
}