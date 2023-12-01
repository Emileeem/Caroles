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
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Model;
using Services;

[ApiController]
[Route("product")]
public class ProductController : ControllerBase
{
    [HttpPost("new")]
    [EnableCors("DefaultPolicy")]

    public async Task<IActionResult> CadastrarProduto(
        [FromBody]ProdutoData produto,
        [FromServices]IProductService service,
        [FromForm] Produto p
    )
    {
        Console.WriteLine("aquiiiiiiiiiiiiiiiiiiiiiiiiiiiiiii");
        var errors = new List<string>();

        if (produto.Name == p.Nome)
            errors.Add("Não pode ser criado produtos com os mesmos nomes.");
        if (produto.Name.Length < 5)
            errors.Add("O produto precisa conter ao menos 5 caracteres.");
        if(produto.Price < 10)
            errors.Add("Os produtos da nossa loja tem o preço maior que esse!");
        if(produto.Category == null)
            errors.Add("Você precisa dar uma categoria ao produto.");

        if(errors.Count > 0)
            return BadRequest(errors);
        
        await service.Create(produto);
        return Ok();
    }
    [HttpGet("image")]
    [EnableCors("DefaultPolicy")]
    
    public async Task<IActionResult> GetImage(
        int photoId,
        [FromServices]ISecurityService security,
        [FromServices]CarolesContext ctx
    )
    {
        var query =
            from image in ctx.Imagems
            where image.Id == photoId
            select image;

        var photo = await query.FirstOrDefaultAsync();
        if(photo is null)
            return NotFound();

        return File(photo.Foto, "image/jpeg");
    }
    [DisableRequestSizeLimit]
    [HttpPut("imagem")]
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

        CarolesContext ctx = new CarolesContext();
        ctx.Add(img);
        await ctx.SaveChangesAsync();

        return Ok();
    }
}