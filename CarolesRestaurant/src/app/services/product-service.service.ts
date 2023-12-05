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
  getSolo()
  {
    return this.http.get('/product/products')
  }
  getCategory(categoria: string)
  {
    return this.http.get('/product/categoria/' + categoria)
  }
}

