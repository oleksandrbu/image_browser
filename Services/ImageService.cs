using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace image_browser{
    public class ImageService{
        private DbConnectionContext db;
        public ImageService(DbConnectionContext dbConnectionContext){
            db = dbConnectionContext;
        }
        public void Add(List<ImageDTO> images){
            List<Image> newImages = new List<Image>();
            foreach (var im in images){
                Filetype type = db.Filetypes.FirstOrDefault(c => c.Id == im.FiletypeId);
                Title title = db.Titles.FirstOrDefault(c => c.Id == im.TitleId);
                newImages.Add(new Image(im, type, title));
            }
            db.Images.AddRange(newImages);
            db.SaveChanges();
        }
        public Image GetById(long id){
            return db.Images.Include(f => f.Filetype)
                            .Include(t => t.Title)
                            .Include(t => t.ImageCharacters)
                            .ThenInclude(c => c.Character)
                            .FirstOrDefault(c => c.Id == id);
        }
        public List<Image> GetAll(){
            return db.Images.Include(f => f.Filetype)
                            .Include(t => t.Title)
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
        public List<Image> Search(ImageSearch search){
            IEnumerable<Image> images = db.Images.ToList();
            if (search.filetype.HasValue){
                images = images.Where(p => p.Filetype.Id == search.filetype);
            }
            if (search.width.HasValue){
                images = images.Where(p => p.Width == search.width);
            } else {
                if (search.minWidth.HasValue) images = images.Where(p => p.Width >= search.minWidth);
                if (search.maxWidth.HasValue) images = images.Where(p => p.Width >= search.maxWidth);
            }
            if (search.height.HasValue){
                images = images.Where(p => p.Height == search.height);
            } else {
                if (search.minHeight.HasValue) images = images.Where(p => p.Height >= search.minHeight);
                if (search.maxHeight.HasValue) images = images.Where(p => p.Width >= search.maxHeight);
            }

            return images.ToList();
        }
    }
}