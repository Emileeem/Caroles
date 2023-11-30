import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ProductServiceService } from '../product-service.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-produto',
  standalone: true,
  imports: [CommonModule, FormsModule],
  templateUrl: './produto.component.html',
  styleUrl: './produto.component.css'
})
export class ProdutoComponent {
  name: string = ""
  price: any = ""
  photo: any = ""
  category: string = ""
  description: string = ""

  constructor(private product: ProductServiceService,
    private router: Router ) {}

  create()
  {
      this.product.register({
        name: this.name,
        price: this.price,
        photo: this.photo,
        category: this.category,
        description: this.description,
      })
      this.router.navigate(['indexAdmin'])
  }
}
