import { Injectable } from '@angular/core';
import { OrderData } from '../data/order-data';
import { ApiOrderService } from '../api/api-order.service';

@Injectable({
  providedIn: 'root'
})
export class OrderServiceService {
  constructor(private http: ApiOrderService) { }

  login(data: OrderData, callback: any)
  {
    this.http.post('/user/login', data)
      .subscribe(
        response => {
          callback(response)
        },
        error => {
          callback(null)
        })
  }
  confirmarPedido(data: OrderData, callback: any)
  {
    this.http.post('/orders', data)
      .subscribe(
        response => {
          callback(response);
        },
        error => {
          console.error('Erro ao confirmar pedido', error);
          callback(null);
        });
  }

}
