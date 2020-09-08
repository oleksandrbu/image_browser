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
            db.Characters.FirstOrDefault(c => c.Id == id);
        }
        public Character Patch(long id, int newAge){
            Character character = db.Characters.FirstOrDefault(c => c.Id == id);
            character.Age = newAge;
            db.SaveChanges();
            return character;
        }
    }
}