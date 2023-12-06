using System.Dynamic;
using System;

namespace DTO;

public class PedidoData
{
    public String Apelido { get; set; }
    public DateTime HoraPedido { get; set; }
    public DateTime HoraPronto { get; set; }
    public int ProdutosId { get; set; }
}