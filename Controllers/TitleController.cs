using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace image_browser{
    [ApiController]
    [Route("api/[controller]")]
    public class TitleController : ControllerBase{
        private TitleService _titleService;

        public TitleController(TitleService titleService){
            _titleService = titleService;
        }

        [HttpGet("")]
        public IActionResult AllTitles(){
            return new JsonResult(_titleService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult TitleById(long id){
            return new JsonResult(_titleService.GetById(id));
        }

        [HttpPost("")]
        public void AddTask(List<Title> titles){
            _titleService.Add(titles);
        }
        [HttpDelete("{id}")]
        public void Delete(long id){
            _titleService.Delete(id);
        }
        [HttpPatch("{id}")]
        public IActionResult AddCharacter(long id, long characterId){
            return new JsonResult(_titleService.AddCharacter(id, characterId));
        }
    }
 }