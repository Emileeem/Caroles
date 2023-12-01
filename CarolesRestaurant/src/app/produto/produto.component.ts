import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { ProductServiceService } from '../services/product-service.service';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';

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

  constructor(
    private product: ProductServiceService,
    private router: Router,
    private http: HttpClient,
    private dialogRef: MatDialogRef<ProdutoComponent>) {}

  create()
  {

    this.http.post('http://localhost:5083/product/imagem', this.formData)
      .subscribe((result: any)  =>
      {
        this.product.register({
          name: this.name,
          price: this.price,
          category: this.category,
          description: this.description,
          imgID: result.imgID
        }, (response:any) => {
          this.dialogRef.close()
        })
      })
  }

  private formData = new FormData()
  uploadFile = (files:any) => {
    if(files.lenght === 0){
      return;
    }
    let fileToUpload = <File>files[0];
    this.formData = new FormData();
    this.formData.append('file', fileToUpload, fileToUpload.name);

    var jwt = sessionStorage.getItem('jwt');
    if(jwt == null)
      return
    this.formData.append('jwt', jwt)
  }
}
