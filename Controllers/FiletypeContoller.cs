using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace image_browser{
    [ApiController]
    [Route("api/[controller]")]
    public class FiletypeController : ControllerBase{
        private FiletypeService _filetypeService;

        public FiletypeController(FiletypeService filetypeService){
            _filetypeService = filetypeService;
        }

        [HttpGet("")]
        public IActionResult AllFiletypes(){
            return new JsonResult(_filetypeService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult FiletypeById(long id){
            return new JsonResult(_filetypeService.GetById(id));
        }

        [HttpPost("")]
        public void AddTask(Filetype filetype){
            _filetypeService.Add(filetype);
        }
        [HttpDelete("{id}")]
        public void Delete(long id){
            _filetypeService.Delete(id);
        }
    }
 }