import { Routes } from '@angular/router';
import { CadastroComponent } from './cadastro/cadastro.component';
import { LoginComponent } from './login/login.component';

export const routes: Routes = [
  {path: 'cadastro', component: CadastroComponent},
  {path: '', component: LoginComponent}
];
