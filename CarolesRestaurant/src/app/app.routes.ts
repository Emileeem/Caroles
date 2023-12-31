import { Routes } from '@angular/router';
import { CadastroComponent } from './cadastro/cadastro.component';
import { LoginComponent } from './login/login.component';
import { IndexAdminComponent } from './index-admin/index-admin.component';
import { MenuComponent } from './menu/menu.component';
import { IngredientsComponent } from './ingredients/ingredients.component';
import { CodeComponent } from './code/code.component';
import { ProdutoComponent } from './produto/produto.component';
import { PedidosComponent } from './pedidos/pedidos.component';
import { TotemComponent } from './totem/totem.component';
import { ProdutosTotemComponent } from './produtos-totem/produtos-totem.component';
import { CarrinhoComponent } from './carrinho/carrinho.component';

export const routes: Routes = [
  {path: '', component: LoginComponent},
  {path: 'cadastro', component: CadastroComponent},
  {
    path: 'indexAdmin',
    component: IndexAdminComponent,
    children: [
      {path: 'produto', component: ProdutoComponent}
    ],
  },
  {path: 'menu', component: MenuComponent},
  {
    path: 'ingredients/:id',
    component: IngredientsComponent,
    children: [
      {path: 'code', component: CodeComponent}
    ]
  },
  {path: 'pedidos', component: PedidosComponent},
  {
    path: 'totem',
    component: TotemComponent,
    children: [
      {path: 'totemCode', component: TotemComponent}
    ]
  },
  {
    path: 'produtosTotem',
     component: ProdutosTotemComponent,
     children: [
       {path: 'carrinho', component: CarrinhoComponent},
     ]
    },

];
