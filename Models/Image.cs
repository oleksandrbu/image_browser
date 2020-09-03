using System.ComponentModel.DataAnnotations.Schema;

namespace image_browser{
    public class Image{
        public ulong Id {get; set;}
        public string Path  {get;set;}
        public uint Width {get; set;}
        public uint Height {get;set;}
        public uint FiletypeId {get; set;}
        public uint TitleId {get; set;}
        public uint CharactersId {get; set;}
        [NotMapped]
        public Filetype Filetype {get; set;}
        [NotMapped]
        public Title Title {get; set;}
        [NotMapped]
        public Character Characters;
        public Image(){

        }
    }
}