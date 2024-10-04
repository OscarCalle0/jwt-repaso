using Microsoft.AspNetCore.Mvc;
using RepasoJWT.Models;
using RepasoJWT.Repositories;

namespace RepasoJWT.Controllers.v1.Pets;

[ApiController]
[Route("api/v1/pets")]
public class PetsController : ControllerBase
{
    private readonly IPetRepository servicios;

    public PetsController(IPetRepository petRepository)
    {
        servicios = petRepository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllPets()
    {
        var pets = await servicios.GetAll();
        if (pets == null || !pets.Any())
        {
            return NoContent();
        }

        return Ok(pets);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPetById(int id)
    {
        var pet = await servicios.GetById(id);
        if (pet == null)
        {
            return NotFound();
        }

        return Ok(pet);
    }

    [HttpPost]
    public async Task<IActionResult> AddPet(Pet pet)
    {
        await servicios.Add(pet);
        return Ok("mascota creada");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePet(int id)
    {
        await servicios.Delete(id);
        return NoContent();
    }

}
