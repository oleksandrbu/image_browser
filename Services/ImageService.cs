using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System;

namespace image_browser{
    public class ImageService{
        private DbConnectionContext db;
        public ImageService(DbConnectionContext dbConnectionContext){
            db = dbConnectionContext;
        }
        public void Add(List<Image> images){
            db.Images.AddRange(images);
            db.SaveChanges();
        }
        public Image GetById(long id){
            return db.Images.Include(f => f.Filetype)
                            .Include(t => t.Title)
                            .Include(i => i.ImageCharacters)
                            .ThenInclude(ic => ic.Character)
                            .FirstOrDefault(c => c.Id == id);
        }
        public List<Image> GetAll(){
            return db.Images/*.Include(f => f.Filetype)
                            .Include(t => t.Title)
                            .Include(i => i.ImageCharacters)
                            .ThenInclude(ic => ic.Character)*/
                            .ToList();
        }
        public void Delete(long id){
            db.Images.Remove(db.Images.FirstOrDefault(p => p.Id == id));
            db.SaveChanges();
        }
        public List<ImageCharacter> AddCharacters(List<ImageCharacter> characters){
            db.ImageCharacters.AddRange(characters);
            db.SaveChanges();
            return characters;
        }
    }
}