import { Component, OnInit } from '@angular/core';
import { Ng4LoadingSpinnerService } from 'ng4-loading-spinner';

import { CartService } from '../../services/cart.service';
import { SessionService } from '../../services/session.service';

import { ProductPriceDTO } from '../../models/ProductPriceDTO';
import { CartItemDTO } from '../../models/CartItemDTO';

@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.css']
})
export class CheckoutComponent implements OnInit {
  cartItems: Array<Object>;

  constructor(
    private _cartService: CartService,
    private _sessionService: SessionService,
    private _spinnerService: Ng4LoadingSpinnerService
  ) {

  }

 
  ngOnInit() {
    this.loadCart();
  }

  loadCart() {

    this._spinnerService.show();
    this._cartService.getCartItems(this._sessionService.getUser().Id).subscribe(response => {
      const data: any = response;
      this.cartItems = data;
      this._spinnerService.hide();
    },
      error => {
        console.error(JSON.stringify(error));
        this._spinnerService.hide();
      });
  }
}
