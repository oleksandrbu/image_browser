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
            TitleCharacter newCharacters = new TitleCharacter(id, character);
            db.TitleCharacters.Add(newCharacters);
            db.SaveChanges();
            return newCharacters;
        }   
    }
}