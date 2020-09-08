
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
            Character which = db.Characters.FirstOrDefault(p => p.Id == id);
            if (which != null){
                db.Characters.Remove(which);
                db.SaveChanges();
            }
        }
        public TitleCharacter AddCharacter(long id, long character){
            TitleCharacter newCharacters = new TitleCharacter(id, character);
            db.TitleCharacters.Add(newCharacters);
            db.SaveChanges();
            return newCharacters;
        }
    }
}