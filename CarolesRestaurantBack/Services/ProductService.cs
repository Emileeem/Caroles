using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CarolesRestaurantBack.Services;

using DTO;
using Model;


public class ProductService : IProductService
{
    CarolesContext ctx;
    public ProductService(CarolesContext ctx)
    {
        this.ctx = ctx;
    }
    public async Task Create(ProdutoData data)
    {
        Produto produto = new Produto();

        produto.Nome = data.Nome;
        produto.Preco = data.Preco;
        produto.Descricao = data.Descricao;
        produto.Categoria = data.Categoria;
        produto.ImagemId = data.imgID;

        this.ctx.Add(produto);
        await this.ctx.SaveChangesAsync();
    }

    public async Task<List<Produto>> Get()
        => await this.ctx.Produtos.ToListAsync();

    public async Task<List<Produto>> GetByCategoria(string categoria)
    {
        var query =
            from p in this.ctx.Produtos
            where p.Categoria == categoria
            select p;

        return await query.ToListAsync();
    }

    public async Task<Produto> GetById(int id)
    {
        var query =
            from p in this.ctx.Produtos
            where p.Id == id
            select p;

        return await query.FirstOrDefaultAsync();
    }
}