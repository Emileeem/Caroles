import { Injectable } from '@angular/core';
import { ClientData } from '../data/client-data';
import { ApiClientService } from '../api/api-client.service';
import { ClientDataLogin } from '../data/client-dataLogin';

@Injectable({
  providedIn: 'root'
})
export class ClientServiceService {
  constructor(private http: ApiClientService) { }

  login(data: ClientDataLogin, callback: any)
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
  register(data: ClientData)
  {
    this.http.post('/user/register', data)
      .subscribe(response => console.log(response))
  }
}
