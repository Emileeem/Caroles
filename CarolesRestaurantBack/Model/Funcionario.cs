using System;
using System.Collections.Generic;

namespace CarolesRestaurantBack.Model;

public partial class Funcionario
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string Sobrenome { get; set; } = null!;

    public string Senha { get; set; } = null!;

    public string Email { get; set; } = null!;
}
