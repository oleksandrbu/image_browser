using System.ComponentModel.DataAnnotations.Schema;

namespace image_browser{
    public class ImageCharacter{
        public long ImageId {get; set;}
        public Image Image {get; set;}
        public long CharacterId {get; set;}
        public Character Character {get; set;}
        public ImageCharacter(){
        }
        public ImageCharacter(long i, long c){
            ImageId = i;
            CharacterId = c;
        }
    }
}