import { Routes } from '@angular/router';
import { CadastroComponent } from './cadastro/cadastro.component';
import { LoginComponent } from './login/login.component';
import { IndexUserComponent } from './index-user/index-user.component';
import { IndexAdminComponent } from './index-admin/index-admin.component';

export const routes: Routes = [
  {path: '', component: LoginComponent},
  {path: 'cadastro', component: CadastroComponent},
  {path: 'index', component: IndexUserComponent},
  {path: 'indexAdmin', component: IndexAdminComponent},
];
