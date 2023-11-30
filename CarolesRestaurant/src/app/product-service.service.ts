import { Injectable } from '@angular/core';
import { ApiProductService } from './api-product.service';
import { ProductData } from './product-data'

@Injectable({
  providedIn: 'root'
})
export class ProductServiceService {
  constructor(private http: ApiProductService) { }

  register(data: ProductData)
  {
    this.http.post('/product/new', data)
      .subscribe(response => console.log(response))
  }
}
