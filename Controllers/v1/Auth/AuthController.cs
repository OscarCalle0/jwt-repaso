using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RepasoJWT.Config;
using RepasoJWT.DTOs.Requests;
using RepasoJWT.Models;
using RepasoJWT.Repositories;

namespace RepasoJWT.Controllers.v1.Auth;

[ApiController]
[Route("api/v1/auth")]
public class AuthController : ControllerBase
{
    protected readonly IUserRespository servicios;

    public AuthController(IUserRespository userRepository)
    {
        servicios = userRepository;
    }

    // metodo que me genera un JWT
    [HttpPost]
    public async Task<IActionResult> GenerateToken(User user)
    {
        var token = JWT.GenerateJwtToken(user);

        return Ok($"ACA ESTA SU TOKEN: {token}");
    }

    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Login(LoginDto data)
    {
        var user = await servicios.GetByEmail(data.Email);

        if (user == null)
            return BadRequest("El usuario no existe");

        if (user.Password != data.Password)
            return BadRequest("Contraseña incorrecta");

        if (user.rol != "admin")
        {
            return Unauthorized($"Suerte, no tiene los permisos necesarios");
        }

        var token = JWT.GenerateJwtToken(user);

        return Ok($"ACA ESTA SU TOKEN: {token}");

    }
}