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

  produtos: ProductDataMenu[] = [];

  ingredientsDetails(id: number): void {
    this.router.navigate(['/ingredients', id]);
  }
  onClickByCategory()
  {
    
  }
  ngOnInit() {
    this.service.take().subscribe(
      (produto : any) => {
        this.produtos = []
        produto.a.forEach((x:any) => this.produtos.push(x))
        console.log(this.produtos)
      },
      (error) => {
        console.error('Não foi possível obter produtos', error)
      });
    }

}
