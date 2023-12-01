using System.Threading.Tasks;

namespace CarolesRestaurantBack.Services;

using DTO;
using Model;

public interface IOrderService
{
    Task Create(PedidoData data);
    Task<List<PedidoCliente>> GetByTime(DateTime hora);
}