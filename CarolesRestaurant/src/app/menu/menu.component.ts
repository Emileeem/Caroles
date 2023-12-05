import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductServiceService } from '../services/product-service.service';
import { Router } from '@angular/router';
import { ImageServiceService } from '../services/image-service.service';
import { ProductDataMenu } from '../data/product-dataMenu';

@Component({
  selector: 'app-menu',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './menu.component.html',
  styleUrl: './menu.component.css'
})
export class MenuComponent implements OnInit {

  constructor(
    private router: Router,
    private service: ProductServiceService,
    private image: ImageServiceService
  ) {}

  filteredProducts: ProductDataMenu[] = [];
  produtos: ProductDataMenu[] = [];
  selectedCategory: string = '';
  selected = ''

  ingredientsDetails(id: number): void {
    this.router.navigate(['/ingredients', id]);
  }

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
