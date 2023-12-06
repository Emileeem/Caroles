import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';
import { ProductServiceService } from '../services/product-service.service';
import { ProductDataMenu } from '../data/product-dataMenu';
import { MatDialog } from '@angular/material/dialog';
import { CarrinhoComponent } from '../carrinho/carrinho.component';

@Component({
  selector: 'app-produtos-totem',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './produtos-totem.component.html',
  styleUrl: './produtos-totem.component.css'
})
export class ProdutosTotemComponent {
  constructor(
    private router: Router,
    private service: ProductServiceService,
    public dialog: MatDialog
  ) {}

  produtos: ProductDataMenu[] = [];
  selectedCategory: string = '';
  selected = ''

  getByCategory(categoria: string): void
  {
    if (this.selected == categoria)
    {
      this.selected = '';
      this.loadAll()
      return;
    }

    this.selectedCategory = categoria;
    console.log(this.selectedCategory)
    this.service.getCategory(categoria).subscribe
    (
      (data: any) => {
        this.selected = categoria
        this.produtos = []
        data.data.forEach((x:any) => this.produtos.push(x))
      }
    )
}

  openDialog() {
    this.dialog.open(CarrinhoComponent);
  }
  
  ngOnInit() {
    this.loadAll()
    }

    loadAll()
    {
      this.service.take().subscribe(
        (produto : any) => {
          this.produtos = []
          produto.a.forEach((x:any) => this.produtos.push(x))
        },
        (error) => {
          console.error('Não foi possível obter produtos', error)
        });
    }
}
