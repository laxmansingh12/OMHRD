import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Ng4LoadingSpinnerService } from 'ng4-loading-spinner';
import { UserService } from '../../services/user.service';
import { ProductService } from '../../services/product.service';
import { CartService } from '../../services/cart.service';
import { SessionService } from '../../services/session.service';
import { DataService } from '../../services/data.service';

import { ProductSearchDTO } from '../../models/ProductSearchDTO';
import { ProductPriceDTO } from '../../models/ProductPriceDTO';
import { ProductDTO } from '../../models/ProductDTO';
import { CartItemDTO } from '../../models/CartItemDTO';
import { UserProfileDTO } from '../../models/UserProfileDTO';
import { Observable } from 'rxjs';

@Component({
  selector: 'ecom-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class EcomProductsComponent implements OnInit {
  currentUser: UserProfileDTO;
  searchDTO: ProductSearchDTO;
  products: Array<Object>;
  btnLogin: HTMLElement;

  constructor(private _UserService: UserService,
    private _productService: ProductService,
    private _cartService: CartService,
    private _sessionService: SessionService,
    private _spinnerService: Ng4LoadingSpinnerService,
    private data: DataService
  ) { }

  ngOnInit() {
    this.loadProducts();
    this.btnLogin = document.getElementById("btnLogin") as HTMLElement;

  }

  loadProducts() {
    this._spinnerService.show();
    this._productService.getProducts(this.searchDTO).subscribe(response => {
      const data: any = response;
      this.products = data;
      this._spinnerService.hide();
    },
      error => {                           
        console.error(JSON.stringify(error));
        this._spinnerService.hide();
      });
  }

  addToCart(product: ProductDTO) {

    if (this._sessionService.isUserLoggedIn()) {
      this._spinnerService.show();
      const cart: CartItemDTO = new CartItemDTO();
      cart.ProductId = product.Id;
      cart.SizeId = product.PriceList[0].SizeId;;
      cart.ColorId = product.PriceList[0].ColorId;
      cart.Quantity = 1;
      cart.UserId = this._sessionService.getUser().Id;
      cart.IsQuantityForAddition = true;

      this._cartService.updateCart(cart).subscribe(response => {
        const data: any = response;
        this.data.updateCartValue(data.TotalPrice, data.Quantity);
        this._spinnerService.hide();
      },
        error => {
          console.error(JSON.stringify(error));
          this._spinnerService.hide();
        });
    }
    else {
      this.btnLogin.click();
    }
  }
}
