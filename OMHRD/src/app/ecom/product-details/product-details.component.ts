import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { Ng4LoadingSpinnerService } from 'ng4-loading-spinner';
import { ProductService } from '../../services/product.service';

import { ProductPriceDTO } from '../../models/ProductPriceDTO';
import { ProductDTO } from '../../models/ProductDTO';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.css']
})
export class ProductDetailsComponent implements OnInit {
  product:ProductDTO;
  selectedPrice:ProductPriceDTO;
  productId:number;
  sizeCode:string;
  colorCode:string;
  hasColor:boolean;

  constructor(private _route: ActivatedRoute,
    private _productService: ProductService,
    private _spinnerService: Ng4LoadingSpinnerService,
  ) { }

  ngOnInit() {    
    this._spinnerService.show();
    this.hasColor = true;
    this.product = new ProductDTO();
    this.selectedPrice = new ProductPriceDTO();
    this.product.PriceList = [];
    this._route.queryParams
      .subscribe(params => { 
        console.log(params); 
        console.log(params["product"]);
        this.productId = params["product"];
        this.sizeCode = params["size"];
        this.colorCode = params["color"];
        this.loadProduct();
      });
      
  }

  changeSize(size:string){
    this._spinnerService.show();
    this.sizeCode = size;
    this.updateSelectedPrice();
    this._spinnerService.hide();
  }

  changeColor(color:string){
    this._spinnerService.show();
    this.colorCode = color;
    this.updateSelectedPrice();
    this._spinnerService.hide();
  }
  
  loadProduct() {    
    this._productService.getProductById(this.productId).subscribe(response => {
      const productResponse :any = response;     
      this.product=  productResponse;
       //this.product = response.json();
    this.updateSelectedPrice();

    if(!this.selectedPrice || this.selectedPrice.SizeCode != undefined || this.selectedPrice.SizeCode != ""){
      this.selectedPrice = this.product.PriceList[0];
    }
    if(this.selectedPrice.ColorCode == null || this.selectedPrice.ColorCode == undefined || this.selectedPrice.ColorCode == ""){
      this.hasColor = false;
    }
    if(this.sizeCode == null || this.sizeCode == undefined || this.sizeCode == ""){
      this.sizeCode = this.selectedPrice.SizeCode;
    }
    if(this.colorCode == null || this.colorCode == undefined || this.colorCode == ""){
      this.colorCode = this.selectedPrice.ColorCode;
    }
      this._spinnerService.show();
   },
     error => {
      this.hasColor = false;
       console.error(JSON.stringify(error));
       this._spinnerService.show();
     });
 }
 
 private updateSelectedPrice(){
  for(var item in this.product.PriceList) {
    var price = this.product.PriceList[item];
    if(price.SizeCode == this.sizeCode && (this.colorCode == undefined || this.colorCode.trim() == "" || price.ColorCode == this.colorCode.trim())){
      this.selectedPrice = price;
      break;
    }
 };  
}

}
