using System.Dynamic;
using System;

namespace DTO;

public class PedidoData
{
    public String Nickname { get; set; }
    public DateTime OrderTime { get; set; }
    public DateTime ReadyTime { get; set; }
    public int ProdutosId { get; set; }
}