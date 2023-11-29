using System.Threading.Tasks;

namespace CarolesRestaurantBack.Services;

using DTO;
using Model;

public interface IProductService
{
    Task Create(ProdutoData data);
    Task<Produto> GetByCategoria(string categoria);
}