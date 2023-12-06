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
using Trevisharp.Security.Jwt;

[ApiController]
[Route("orders")]
public class OrderController : ControllerBase
{
    [HttpPost("")]
    [EnableCors("DefaultPolicy")]

    public async Task<IActionResult> FazerPedido(
        [FromBody] PedidoData pedido,
        [FromServices]IOrderService service
    )
    {
        var errors = new List<string>();

        if(pedido is null)
            errors.Add("O pedido não pode ser nulo!");

        if(pedido.Apelido.Length <= 3)
            errors.Add("Seu apelido precisa ter pelo menos 3 caracteres.");

        if(errors.Count > 0)
            return BadRequest(errors);
        
        await service.Create(pedido);
        return Ok();
    }
}