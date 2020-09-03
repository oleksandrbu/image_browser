using System.ComponentModel.DataAnnotations.Schema;

namespace image_browser{
    public class TitleCharacter{
        public ulong TitleId {get; set;}
        public Title Title {get; set;}
        public ulong CharacterId {get; set;}
        public Character Character {get; set;}
        public TitleCharacter(){
        }
    }
}