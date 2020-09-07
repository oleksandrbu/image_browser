using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace image_browser{
    public class FiletypeService{
        private DbConnectionContext db;
        public FiletypeService(DbConnectionContext dbConnection){
            db = dbConnection;
        }
        public void Add(Filetype filetype){
            db.Filetypes.Add(filetype);
            db.SaveChanges();
        }
        public Filetype GetById(long id){
            return db.Filetypes.FirstOrDefault(c => c.Id == id);
        }
        public List<Filetype> GetAll(){
            return db.Filetypes.ToList();
        }
        public void Delete(long id){
            Filetype which = db.Filetypes.FirstOrDefault(p => p.Id == id);
            if (which != null){
                db.Filetypes.Remove(which);
                db.SaveChanges();
            }
        }
    }
}