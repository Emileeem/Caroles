using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace CarolesRestaurantBack.Services;

using System;
using System.Collections.Generic;
using CarolesRestaurantBack.Model;
using DTO;
using Model;

public class OrderService : IOrderService
{
    CarolesContext ctx;

    public OrderService(CarolesContext ctx)
    {
        this.ctx = ctx;
    }
    public async Task Create(PedidoData data)
    {
        PedidoCliente pedido = new PedidoCliente();

        pedido.Apelido = data.Nickname;
        pedido.HoraPedido = data.OrderTime;
        pedido.HoraPronto = data.ReadyTime;
        pedido.ProdutosId = data.ProdutosId;

        this.ctx.Add(pedido);
        await this.ctx.SaveChangesAsync();
    }

    public async Task<List<PedidoCliente>> GetByTime(DateTime hora)
    {
        var query = 
            from p in this.ctx.PedidoClientes
            where p.HoraPedido <= hora
            select p;
        
        return await query.ToListAsync();
    }
}