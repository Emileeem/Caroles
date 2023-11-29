using System;
using System.Collections.Generic;

namespace CarolesRestaurantBack.Model;

public partial class Funcionario
{
    public int Id { get; set; }

    public string Senha { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string Salt { get; set; } = null!;
}
