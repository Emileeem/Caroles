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

[ApiController]
[Route("user")]
public class UserController : ControllerBase
{
    [HttpPost("login")]
    [EnableCors("DefaultPolicy")]
    public async Task<IActionResult> Login(
        [FromBody]ClienteData user,
        [FromServices]IUserService service,
        [FromServices]ISecurityService security)
    {
        var loggedUser = await service
            .GetByLogin(user.Login);
        
        if (loggedUser == null)
            return Unauthorized("Usuário não existe.");
        
        var password = await security.HashPassword(
            user.Password, loggedUser.Salt
        );
        var realPassword = loggedUser.Senha;
        if (password != realPassword)
            return Unauthorized("Senha incorreta.");
        
        var jwt = await security.GenerateJwt(new {
            id = loggedUser.Id,
            photoId = loggedUser.ImagemId
        });
        
        return Ok(new { jwt });
    }

    [HttpPost("register")]
    [EnableCors("DefaultPolicy")]
    public async Task<IActionResult> Create(
        [FromBody]ClienteData user,
        [FromServices]IUserService service)
    {
        var errors = new List<string>();
        if (user is null || user.Login is null)
            errors.Add("É necessário informar um login.");
        if (user.Login.Length < 5)
            errors.Add("O Login deve conter ao menos 5 caracteres.");

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

    // [HttpGet("image")]
    // [EnableCors("DefaultPolicy")]
    // public async Task<IActionResult> GetImage(
    //     int photoId,
    //     [FromServices]ISecurityService security,
    //     [FromServices]CarolesContext ctx)
    // {
    //     var query =
    //         from image in ctx.Imagems
    //         where image.Id == photoId
    //         select image;
        
    //     var photo = await query.FirstOrDefaultAsync();
    //     if (photo is null)
    //         return NotFound();

    //     return File(photo.Foto, "image/jpeg");
    // }

    [DisableRequestSizeLimit]
    [HttpPut("image")]
    [EnableCors("DefaultPolicy")]
    public async Task<IActionResult> AddImage(
        [FromServices]ISecurityService security
    )
    {
        var jwtData = Request.Form["jwt"];
        var jwtObj = JsonSerializer
            .Deserialize<JwtToken>(jwtData);
        var jwt = jwtObj.jwt;

        var userOjb = await security
            .ValidateJwt<JwtPayload>(jwt);
        if (userOjb is null)
            return Unauthorized();
        var userId = userOjb.id;

        var files = Request.Form.Files;
        if (files is null || files.Count == 0)
            return BadRequest();
        
        var file = Request.Form.Files[0];
        if (file.Length < 1)
            return BadRequest();
 
        using MemoryStream ms = new MemoryStream();
        await file.CopyToAsync(ms);
        var data = ms.GetBuffer();

        Imagem img = new Imagem();
        img.Foto = data;

        DonOrgDbContext ctx = new DonOrgDbContext();
        ctx.Add(img);
        await ctx.SaveChangesAsync();
        
        var query =
            from user in ctx.Usuarios
            where user.Id == userId
            select user;
        var loggedUser = query.FirstOrDefault();
        loggedUser.ImagemId = img.Id;

        await ctx.SaveChangesAsync();

        return Ok();
    }

    [HttpDelete("image")]
    [EnableCors("DefaultPolicy")]
    public IActionResult RemoveImage()
    {
        throw new NotImplementedException();
    }
}