using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RepasoJWT.Models;
using RepasoJWT.Repositories;

namespace RepasoJWT.Controllers.v1.Pets
{
    [ApiController]
    [Route("api/v1/pets")]
    [Tags("pets")]
    public class PetsCreateController : PetsController
    {
        public PetsCreateController(IPetRepository petRepository) : base(petRepository)
        {
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> AddPet(Pet pet)
        {
            await servicios.Add(pet);
            return Ok("mascota creada");
        }
    }
}