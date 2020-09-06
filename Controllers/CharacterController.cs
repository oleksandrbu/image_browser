using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace image_browser{
    [ApiController]
    [Route("api/[controller]")]
    public class CharacterController : ControllerBase{
        private CharacterService _characterService;

        public CharacterController(CharacterService characterService){
            _characterService = characterService;
        }

        [HttpGet("")]
        public IActionResult AllCharacters(){
            return new JsonResult(_characterService.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult CharacterById(long id){
            return new JsonResult(_characterService.GetById(id));
        }

        [HttpPost("")]
        public void AddTask(List<Character> characters){
            _characterService.Add(characters);
        }
    }
 }