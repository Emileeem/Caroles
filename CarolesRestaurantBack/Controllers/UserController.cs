using System.ComponentModel.Design;
using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Cors;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CarolesRestaurantBack.Controllers;

using DTO;
using Model;
using Services;
using Trevisharp.Security.Jwt;

[ApiController]
[Route("user")]
public class UserController : ControllerBase
{
    [HttpPost("login")]
    [EnableCors("DefaultPolicy")]
    public async Task<IActionResult> Login(
        [FromBody]ClienteData user,
        [FromServices]IUserService service,
        [FromServices]ISecurityService security,
        [FromServices]CryptoService crypto)
    {
        var loggedUser = await service
            .GetByLogin(user.Login);
        
        Console.WriteLine(loggedUser);
        if (loggedUser == null)
            return Unauthorized("Usuário não existe.");
        
        var password = await security.HashPassword(
            user.Password, loggedUser.Salt
        );
        var realPassword = loggedUser.Senha;
        if (password != realPassword)
            return Unauthorized("Senha incorreta.");
        
        var jwt = crypto.GetToken(new {
            id = loggedUser.Id,
            isAdm = loggedUser.IsAdmin
        });
        
        // var value = crypto.Validate<JwtPayload>(jwt);
        
        return Ok(new { jwt });
    }

    [HttpPost("register")]
    [EnableCors("DefaultPolicy")]
    public async Task<IActionResult> Create(
        [FromBody]ClienteData user,
        [FromServices]IUserService service)
    {
        var errors = new List<string>();

        Console.WriteLine(user.Login);
        Console.WriteLine(user.Name);
        Console.WriteLine(user.Surname);
        Console.WriteLine(user.Birthday);
        
        if(user.Birthday >= DateTime.Today)
            errors.Add("Insira uma data válida.");

        if (user is null || user.Login is null || user.Name is null || user.Surname is null)
            errors.Add("É necessário informar todos os campos pedidos.");

        if (user.IsAdmin is null)
            user.IsAdmin = "Não";
            
        if (errors.Count > 0)
            return BadRequest(errors);
        
        await service.Create(user);
        return Ok();
    }

    [HttpDelete]
    [EnableCors("DefaultPolicy")]
    public IActionResult DeleteUser()
    {
        throw new NotImplementedException();
    }
}