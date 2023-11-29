import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ClientServiceService } from '../client-service.service';
import { Router } from '@angular/router';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  constructor (private client: ClientServiceService,
    private router: Router ) { }

    name: string = ""
    surname: string = ""
    birthday: string = ""
    email: string = ""
    password: string = ""
    repeatPassword: string = ""

  logar()
  {
    this.client.login({
      login: this.email,
      password: this.password,
    }, (result: any) => {

      if(result === null)
      {
        alert('Senha ou email incorreto!')
      }
      else
      {
        sessionStorage.setItem('jwt', JSON.stringify(result))
        this.router.navigate(['menu'])
      }
    })
  }
}
