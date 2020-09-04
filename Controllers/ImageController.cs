using System;
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
    }
 }