using System.Collections.Generic;
using API_Ong.Models;
using API_Ong.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Ong.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalController : ControllerBase
    {
        private readonly AnimalService _animalService;

        public AnimalController(AnimalService animalService)
        {
            _animalService = animalService;
        }

        [HttpGet] 
        public ActionResult<List<Animal>> Get() => _animalService.Get();

        [HttpGet("{id:length(24)}", Name = "GetAnimal")]
        public ActionResult<Animal> Get(string id)
        {
            var animal = _animalService.Get(id);
            if (animal == null)
            {
                return NotFound();
            }

            return Ok(animal);
        }
        [HttpPost]
        public ActionResult<Animal> Create(Animal animal)
        {
            _animalService.Create(animal);
            return CreatedAtRoute("GetAnimal", new { id = animal.Id.ToString() }, animal);
        }

        [HttpPut]
        public ActionResult<Animal> Put(Animal animalIn, string id)
        {
            var animal = _animalService.Get(id);
            if (animal == null)
            {
                return NotFound("Não encontrado");
            }
            _animalService.Update(animal.Id, animalIn);
            return NoContent();
        }

        [HttpDelete]
        public ActionResult<Animal> Delete(string id)
        {
            Animal animal = _animalService.Get(id);
            if (animal == null)
            {
                return NotFound();
            }
            _animalService.Remove(animal);

            return NoContent();
        }

    }
}