using System;
using System.Collections.Generic;

namespace CarolesRestaurantBack.Model;

public partial class Produto
{
    public int Id { get; set; }

    public string Nome { get; set; } = null!;

    public decimal Preco { get; set; }

    public string Descricao { get; set; } = null!;

    public string Categoria { get; set; } = null!;

    public string? Promocao { get; set; }

    public int? ImagemId { get; set; }

    public int? CodigosId { get; set; }

    public virtual Codigo? Codigos { get; set; }

    public virtual Imagem? Imagem { get; set; }

    public virtual ICollection<PedidoCliente> PedidoClientes { get; set; } = new List<PedidoCliente>();
}
