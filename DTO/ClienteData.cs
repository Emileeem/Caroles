using System.Dynamic;
using System;
namespace DTO;

public class ClienteData
{
    public string Login { get; set; }
    public string Password { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }
    public DateTime Birthday { get; set; }
    public bool IsAdmin { get; set;}
}