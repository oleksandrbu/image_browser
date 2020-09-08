using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace image_browser{
    [ApiController]
    [Route("api/[controller]")]
    public class ImageController : ControllerBase{
        private ImageService _imageService;

        public ImageController(ImageService imageService){
            _imageService = imageService;
        }

        [HttpGet("")]
        public IActionResult AllImage(){
            return new JsonResult(_imageService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult ImageById(long id){
            return new JsonResult(_imageService.GetById(id));
        }

        [HttpPost("")]
        public void AddTask(List<Image> images){
            _imageService.Add(images);
        }
        
        [HttpDelete("{id}")]
        public void Delete(long id){
            _imageService.Delete(id);
        }

        [HttpPatch("{id}")]
        public IActionResult AddCharacters(long id, long characterId){
            return new JsonResult(_imageService.AddCharacters(id, characterId));
        }

        [HttpGet("search")]
        public IActionResult Search(long? width = null, 
                                    long? minWidth = null, 
                                    long? maxWidth = null,
                                    long? height= null,
                                    long? minHeight = null,
                                    long? maxHeight = null, 
                                    long? filetype = null)
        {
            return new JsonResult(_imageService.Search(width, minWidth, maxWidth, height, minHeight, maxHeight, filetype));
        }
    }
 }