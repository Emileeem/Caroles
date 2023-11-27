using System.Threading.Tasks;

namespace CarolesRestaurantBack.Services;

using DTO;
using Model;

public interface IUserService
{
    Task Create(ClienteData data);
    Task<Cliente> GetByLogin(string login);
}