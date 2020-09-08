using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace image_browser{
    public class TitleService{
        private DbConnectionContext db;
        public TitleService(DbConnectionContext dbConnection){
            db = dbConnection;
        }
        public void Add(List<Title> titles){
            db.Titles.AddRange(titles);
            db.SaveChanges();
        }
        public Title GetById(long id){
            return db.Titles.FirstOrDefault(c => c.Id == id);
        }
        public List<Title> GetAll(){
            return db.Titles.ToList();
        }
        public void Delete(long id){
            Title which = db.Titles.FirstOrDefault(p => p.Id == id);
            if (which != null){
                db.Titles.Remove(which);
                db.SaveChanges();
            }
        }
        public TitleCharacter AddCharacter(long id, long character){
            TitleCharacter newCharacters = null;
            if (db.Titles.FirstOrDefault(c => c.Id == id) != null && db.Characters.FirstOrDefault(c => c.Id == id) != null){
                newCharacters = new TitleCharacter(id, character);
                db.TitleCharacters.Add(newCharacters);
                db.SaveChanges();
            }

            return newCharacters;
        }
        public List<Character> GetCharacters(long id){
            db.Characters.Load();
            List<Character> charList = new List<Character>();
            List<TitleCharacter> imCharList = db.TitleCharacters.Where(p => p.TitleId == id).ToList();
            if (imCharList != null){
                foreach (TitleCharacter character in imCharList){
                    charList.Add(character.Character);
                }
            }   
            return charList;
        }
        public List<Image> GetImages(long id){
            db.Images.Load();
            List<Image> imList = db.Images.Where(p => p.Title.Id == id).ToList();
            return imList;
        }      
    }
}