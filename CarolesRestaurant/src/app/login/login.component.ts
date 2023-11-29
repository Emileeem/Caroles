import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ClientServiceService } from '../client-service.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  constructor (private client: ClientServiceService,
    private router: Router ) { }

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
        this.router.navigate(['menu'])
      }
    })
  }
}
