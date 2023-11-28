import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ClientServiceService } from '../client-service.service';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  constructor (private client: ClientServiceService) { }

  email: string = ""
  password: string = ""

  logar()
  {
    this.client.login({
      login: this.email,
      password: this.password
    }, (result: any) => {
      if(result == null)
      {
        alert('Senha ou usuário incorreto!')
      }
      else
      {
        
      }
    })
  }
}
