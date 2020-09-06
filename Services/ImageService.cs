using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

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
            return db.Images.Include(f => f.Filetype)
                            .Include(t => t.Title)
                            .Include(i => i.ImageCharacters)
                            .ThenInclude(ic => ic.Character)
                            .ToList();
        }
        public void Delete(long id){
            Image which = db.Images.FirstOrDefault(p => p.Id == id);
            if (which != null){
                db.Images.Remove(which);
                db.SaveChanges();
            }
        }
        public ImageCharacter AddCharacters(long id, long character){
            ImageCharacter newCharacters = null;
            if (db.Images.FirstOrDefault(c => c.Id == id) != null && db.Characters.FirstOrDefault(c => c.Id == character) != null){
                newCharacters = new ImageCharacter(id, character);
                db.ImageCharacters.Add(newCharacters);
                db.SaveChanges();
            }
            return newCharacters;
        }
        public List<Image> Search(long? width, long? minWidth, long? maxWidth, long? height, long? minHeight, long? maxHeight, long? filetype){
            IEnumerable<Image> images = db.Images.ToList();
            if (filetype != null){
                images = images.Where(p => p.Filetype.Id == filetype);
            }
            if (width != null){
                images = images.Where(p => p.Width == width);
            } else {
                if (minWidth != null) images = images.Where(p => p.Width >= minWidth);
                if (maxWidth != null) images = images.Where(p => p.Width >= maxWidth);
            }
            if (height != null){
                images = images.Where(p => p.Height == height);
            } else {
                if (minHeight != null) images = images.Where(p => p.Height >= minHeight);
                if (maxHeight != null) images = images.Where(p => p.Width >= maxHeight);
            }

            return images.ToList();
        }
    }
}