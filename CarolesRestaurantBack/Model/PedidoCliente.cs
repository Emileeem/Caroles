using System;
using System.Collections.Generic;

namespace CarolesRestaurantBack.Model;

public partial class PedidoCliente
{
    public int Id { get; set; }

    public string? Apelido { get; set; }

    public int ProdutosId { get; set; }

    public DateTime? HoraPedido { get; set; }

    public DateTime? HoraPronto { get; set; }

    public virtual Produto Produtos { get; set; } = null!;
}
