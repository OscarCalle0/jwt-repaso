using Microsoft.AspNetCore.Mvc;
using RepasoJWT.Models;
using RepasoJWT.Repositories;

namespace RepasoJWT.Controllers.v1.Pets;

[ApiController]
[Route("api/v1/pets")]
public class PetsController : ControllerBase
{
    protected readonly IPetRepository servicios;

    public PetsController(IPetRepository petRepository)
    {
        servicios = petRepository;
    }
}
