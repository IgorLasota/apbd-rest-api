using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using RestApi.DTO;
using RestApi.Interface;
using RestApi.Model;

namespace RestApi.Controllers;

[Route("api/animals")]
[ApiController]
public class AnimalsController : ControllerBase
{
    private readonly IAnimalService _animalService;

    public AnimalsController(IAnimalService animalService)
    {
        _animalService = animalService;
    }

    [HttpGet]
    public IActionResult GetAnimals([FromQuery] string orderBy = "idAnimal")
    {
        var result = _animalService.GetAnimals(orderBy);
        return Ok(result);
    }

    [HttpPost]
    public IActionResult CreateAnimal([FromBody] AnimalInputDto animal)
    {
        _animalService.CreateAnimal(animal);
        return StatusCode(StatusCodes.Status201Created);
    }

    [HttpPut("{id:int}")]
    public IActionResult UpdateAnimal(int id, [FromBody] AnimalInputDto animal)
    {
        _animalService.UpdateAnimal(id, animal);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public IActionResult DeleteAnimal(int id)
    {
        _animalService.DeleteAnimal(id);
        return NoContent();
    }
}