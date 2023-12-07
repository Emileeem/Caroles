import { Component, Inject } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { OrderServiceService } from '../services/order-service.service';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-carrinho',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './carrinho.component.html',
  styleUrl: './carrinho.component.css'
})
export class CarrinhoComponent {
  apelido: string = "";
  carrinho: any[]
  totalPedido: number = 0;

  constructor(@Inject(MAT_DIALOG_DATA) public data: any,
  private service: OrderServiceService ) {
    // Os dados enviados estão disponíveis na propriedade 'data'
    this.carrinho = data.carrinho;
    this.calcularTotalPedido();
  }

  calcularTotalPedido() {
    this.totalPedido = this.carrinho.reduce((total, item) => total + (item.preco), 0);
  }

  removerItemDoCarrinho(index:number ) {
    if(index !== -1){
      this.carrinho.splice(index, 1);
      this.calcularTotalPedido();
    }
  }

  confirmarPedido() {
    const dadosPedido = {
      apelido: this.apelido,
      itens: this.carrinho.map(item => ({ produtoId: item.produtoId, quantidade: item.quantidade }))
    };

    this.service.confirmarPedido(dadosPedido).subscribe(
      (response: any) => {
        console.log('Pedido confirmado com sucesso!', response);
      },
      (error: any) => {
        console.error('Erro ao confirmar o pedido', error);
      }
    );
  }

}

