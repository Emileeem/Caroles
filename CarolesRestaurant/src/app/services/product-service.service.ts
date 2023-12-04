import { Injectable } from '@angular/core';
import { ApiProductService } from '../api/api-product.service';
import { ProductData } from '../data/product-data'

@Injectable({
  providedIn: 'root'
})
export class ProductServiceService {
  constructor(private http: ApiProductService) { }

  register(data: ProductData, callback: any = null)
  {
    this.http.post('/product/new', data)
      .subscribe(response => callback(response))
  }

  take()
  {
    return this.http.get('/product/product')
  }
}

