import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';
import { ClientServiceService } from '../services/client-service.service';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-cadastro',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './cadastro.component.html',
  styleUrl: './cadastro.component.css'
})
export class CadastroComponent {
  name: string = ""
  surname: string = ""
  birthday: string = ""
  email: string = ""
  password: string = ""
  repeatPassword: string = ""

  constructor(private client: ClientServiceService,
    private router: Router ) {}

  create()
  {
    if(this.password === this.repeatPassword)
    {
      this.client.register({
        name: this.name,
        surname: this.surname,
        birthday: this.birthday,
        login: this.email,
        password: this.password,
      })
      this.router.navigate([''])
    }
    else
    {
      alert("As senhas não coincidem!")
    }
  }
}
