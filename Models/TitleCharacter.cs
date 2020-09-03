using System.ComponentModel.DataAnnotations.Schema;

namespace image_browser{
    public class TitleCharacter{
        public long TitleId {get; set;}
        public Title Title {get; set;}
        public long CharacterId {get; set;}
        public Character Character {get; set;}
        public TitleCharacter(){
        }
    }
}