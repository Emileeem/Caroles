import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ProductServiceService } from '../product-service.service';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';

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
  category: string = ""
  description: string = ""

  constructor(private product: ProductServiceService,
    private router: Router,
    private http: HttpClient ) {}

  create()
  {
      this.product.register({
        name: this.name,
        price: this.price,
        category: this.category,
        description: this.description,
      })
      this.router.navigate(['indexAdmin'])
  }

  uploadFile = (files:any) => {
    if(files.lenght === 0){
      return;
    }
    let fileToUpload = <File>files[0];
    const formData = new FormData();
    formData.append('file', fileToUpload, fileToUpload.name);

    var jwt = sessionStorage.getItem('jwt');
    if(jwt == null)
      return
    formData.append('jwt', jwt)

    this.http.put('http://localhost:5083/product/imagem', formData)
      .subscribe(result => console.log("ok!"))
  }
}
