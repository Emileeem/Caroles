import { Injectable } from '@angular/core';
import { ProductData } from '../data/product-data'
import { ApiImageService } from '../api/api-image.service';

@Injectable({
  providedIn: 'root'
})
export class ImageServiceService {
  constructor(private http: ApiImageService) { }

  getImage()
  {
    return this.http.get('http://localhost:5083/product/image')
  }

}

