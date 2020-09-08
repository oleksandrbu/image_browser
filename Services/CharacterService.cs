using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace image_browser{
    public class CharacterService{
        private DbConnectionContext db;
        public CharacterService(DbConnectionContext dbConnection){
            db = dbConnection;
        }
        public void Add(List<Character> characters){
            db.Characters.AddRange(characters);
            db.SaveChanges();
        }
        public Character GetById(long id){
            return db.Characters.FirstOrDefault(c => c.Id == id);
        }
        public List<Character> GetAll(){
            return db.Characters.ToList();
        }
        public void Delete(long id){
            Character which = db.Characters.FirstOrDefault(c => c.Id == id);
            if (which != null){
                db.Characters.Remove(which);
                db.SaveChanges();
            }
        }
        public Character Patch(long id, int newAge){
            Character character = db.Characters.FirstOrDefault(c => c.Id == id);
            character.Age = newAge;
            db.SaveChanges();
            return character;
        }
        public List<Image> GetImages(long id){
            db.Images.Load();
            List<Image> charList = new List<Image>();
            List<ImageCharacter> imCharList = db.ImageCharacters.Where(p => p.CharacterId == id).ToList();
            if (imCharList != null){
                foreach (ImageCharacter character in imCharList){
                    charList.Add(character.Image);
                }
            }   
            return charList;
        }   
        public List<Title> GetTitles(long id){
            db.Titles.Load();
            List<Title> charList = new List<Title>();
            List<TitleCharacter> imCharList = db.TitleCharacters.Where(p => p.CharacterId == id).ToList();
            if (imCharList != null){
                foreach (TitleCharacter character in imCharList){
                    charList.Add(character.Title);
                }
            }   
            return charList;
        }   
    }
}