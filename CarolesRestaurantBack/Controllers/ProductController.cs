using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace CarolesRestaurantBack.Controllers;

using DTO;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
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
        var errors = new List<string>();

        if (produto.Name == p.Nome)
            errors.Add("Não pode ser criado produtos com os mesmos nomes.");
        if (produto.Name.Length < 5)
            errors.Add("O produto precisa conter ao menos 5 caracteres.");
        if(produto.Price < 10)
            errors.Add("Os produtos da nossa loja tem o preço maior que esse!");
        if(produto.Photo == null)
            errors.Add("É necessário adicionar uma foto do produto.");
        if(produto.Category == null)
            errors.Add("Você precisa dar uma categoria ao produto.");

        if(errors.Count > 0)
            return BadRequest(errors);
        
        await service.Create(produto);
        return Ok();
    }

}