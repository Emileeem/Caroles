using System;
using System.Collections.Generic;

namespace CarolesRestaurantBack.Model;

public partial class Codigo
{
    public int Id { get; set; }

    public string CodigoAleat { get; set; } = null!;

    public virtual ICollection<Produto> Produtos { get; set; } = new List<Produto>();
}
