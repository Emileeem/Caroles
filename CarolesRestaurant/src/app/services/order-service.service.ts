import { Injectable } from '@angular/core';
import { OrderData } from '../data/order-data';
import { ApiOrderService } from '../api/api-order.service';
import { catchError } from 'rxjs';

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
  confirmarPedido(dadosPedido: any) {
    return this.http.post('/orders/', dadosPedido).pipe(
      catchError((error: any) => {
        console.error('Erro na chamada HTTP:', error);
        throw error; // Pode ser necessário ajustar o tratamento de erro conforme necessário
      })
    );
  }

}
