using System.Threading.Tasks;

namespace CarolesRestaurantBack.Services;

public interface ISecurityService
{
    Task<string> GenerateSalt();
    Task<string> HashPassword(string password, string salt);
    Task<string> GenerateJwt<T>(T obj);
    Task<string> ValidateJwt<T>(string jwt);
}