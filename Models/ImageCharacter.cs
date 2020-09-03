using System.ComponentModel.DataAnnotations.Schema;

namespace image_browser{
    public class ImageCharacter{
        public ulong ImageId {get; set;}
        public Image Image {get; set;}
        public ulong CharacterId {get; set;}
        public Character Character {get; set;}
        public ImageCharacter(){
        }
    }
}