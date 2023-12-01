using System;
using System.Collections.Generic;

namespace CarolesRestaurantBack.Model;

public partial class Cliente
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public string Sobrenome { get; set; } = null!;

    public string Senha { get; set; } = null!;

    public DateTime DataNasc { get; set; }

    public string Email { get; set; } = null!;

    public string Salt { get; set; } = null!;

    public bool IsAdmin { get; set; }
}
