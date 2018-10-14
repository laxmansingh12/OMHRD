import { Injectable } from '@angular/core';
import { Http, Headers, RequestOptions } from '@angular/http';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import 'rxjs/add/operator/map';

@Injectable()
export class ProductService {

  constructor(private _http: HttpClient) { }

  getProducts(searchDto) {
    var jsonData = JSON.stringify(searchDto);
    return this._http.post('product/search', jsonData);
  }

  getProductById(productId: number) {
    return this._http.get('product/byid/' + productId);
  }
}
