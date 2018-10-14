import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import 'rxjs/add/operator/map';
import { CartItemDTO } from '../models/CartItemDTO';

@Injectable()
export class CartService {

  constructor(private _http: HttpClient) {
  }

  updateCart(cartItem: CartItemDTO) {
    var jsonData = JSON.stringify(cartItem);
    return this._http.post('cart/addtocart', jsonData);
  }

  getCartItems(userId: number) {
    return this._http.get('cart/items/userid/' + userId);
  }

  getCartTotal(userId: number) {
    return this._http.get('cart/total/userid/' + userId);
  }

}
