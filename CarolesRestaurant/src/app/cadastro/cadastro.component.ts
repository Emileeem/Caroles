import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Data } from '@angular/router';
import { ClientServiceService } from '../client-service.service';

@Component({
  selector: 'app-cadastro',
  standalone: true,
  imports: [CommonModule],
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

  constructor(private client: ClientServiceService) {}

  create()
  {
    this.client.register({
      login: this.email,
      password: this.password
    })
  }
}
