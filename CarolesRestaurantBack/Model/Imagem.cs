using System;
using System.Collections.Generic;

namespace CarolesRestaurantBack.Model;

public partial class Imagem
{
    public int Id { get; set; }

    public byte[] Foto { get; set; } = null!;

    public virtual ICollection<Produto> Produtos { get; set; } = new List<Produto>();
}
