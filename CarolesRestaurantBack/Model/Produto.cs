using System;
using System.Collections.Generic;

namespace CarolesRestaurantBack.Model;

public partial class Produto
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public decimal Preco { get; set; }

    public byte[]? Foto { get; set; }

    public string Descricao { get; set; } = null!;

    public string Categoria { get; set; } = null!;

    public int? CodigosId { get; set; }

    public virtual Codigo? Codigos { get; set; }

    public virtual ICollection<PedidoCliente> PedidoClientes { get; set; } = new List<PedidoCliente>();
}
