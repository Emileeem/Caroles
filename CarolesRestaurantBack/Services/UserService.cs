using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CarolesRestaurantBack.Services;

using DTO;
using Model;

public class UserService : IUserService
{
    CarolesContext ctx;
    ISecurityService security;
    public UserService(CarolesContext ctx, ISecurityService security)
    {
        this.ctx = ctx;
        this.security = security;
    }
    public async Task Create(ClienteData data)
    {
        Cliente cliente = new Cliente();
        var salt = await security.GenerateSalt();

        cliente.Nome = data.Login;
        cliente.Senha = await security.HashPassword(
            data.Password, salt
        );
        cliente.Salt = salt;

        this.ctx.Add(cliente);
        await this.ctx.SaveChangesAsync();
    }

    public async Task<Cliente> GetByLogin(string login)
    {   
        var query =
            from u in this.ctx.Clientes
            where u.Nome == login
            select u;

        return await query.FirstOrDefault();
    }
}