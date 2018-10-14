//import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClient, HttpHeaders, HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { HttpModule, Http, XHRBackend, RequestOptions } from '@angular/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { CanActivate } from "@angular/router";
//import {AgGridModule} from "ag-grid-angular/main";
import { Ng4LoadingSpinnerModule } from 'ng4-loading-spinner';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import {
  MatFormFieldModule,
  MatAutocompleteModule,
  MatBadgeModule,
  MatBottomSheetModule,
  MatButtonModule,
  MatButtonToggleModule,
  MatCardModule,
  MatCheckboxModule,
  MatChipsModule,
  MatDatepickerModule,
  MatDialogModule,
  MatDividerModule,
  MatExpansionModule,
  MatGridListModule,
  MatIconModule,
  MatInputModule,
  MatListModule,
  MatMenuModule,
  MatNativeDateModule,
  MatPaginatorModule,
  MatProgressBarModule,
  MatProgressSpinnerModule,
  MatRadioModule,
  MatRippleModule,
  MatSelectModule,
  MatSidenavModule,
  MatSliderModule,
  MatSlideToggleModule,
  MatSnackBarModule,
  MatSortModule,
  MatStepperModule,
  MatTableModule,
  MatTabsModule,
  MatToolbarModule,
  MatTooltipModule,
  MatTreeModule,
} from '@angular/material';

import { ROUTING } from './app.routing.module'
import { AuthInterceptor } from './interceptor'
//import { httpFactory } from "./http.factory";

import { AppComponent } from './app.component';
import { EcomMasterComponent } from './ecom/master/ecommaster.component';
import { LoginComponent } from './ecom/login/login.component';
import { RegisterComponent } from './ecom/register/register.component';
import { EcomHomeComponent } from './ecom/home/home.component';
import { EcomProductsComponent } from './ecom/products/products.component';
import { ProductDetailsComponent } from './ecom/product-details/product-details.component';
import { CheckoutComponent } from './ecom/checkout/checkout.component';

import { AppConfig } from './app.config';
import { UserService } from './services/user.service';
import { ProductService } from './services/product.service';
import { SessionService } from './services/session.service';
import { CartService } from './services/cart.service';
import { DataService } from './services/data.service';

import { ProductDTO } from './models/ProductDTO';
import { ProductPriceDTO } from './models/ProductPriceDTO';
import { UserProfileDTO } from './models/UserProfileDTO';
import { ProductSearchDTO } from './models/ProductSearchDTO';
import { CartItemDTO } from './models/CartItemDTO';

@NgModule({
  entryComponents: [EcomMasterComponent, LoginComponent, RegisterComponent],
  declarations: [
    AppComponent,
    EcomMasterComponent,
    EcomHomeComponent,
    EcomProductsComponent,
    ProductDetailsComponent,
    CheckoutComponent,
    LoginComponent,
    RegisterComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpModule,
    HttpClientModule,
    ReactiveFormsModule,
    Ng4LoadingSpinnerModule.forRoot(),
    NgbModule, BrowserAnimationsModule,
    MatFormFieldModule,
    MatAutocompleteModule,
    MatBadgeModule,
    MatBottomSheetModule,
    MatButtonModule,
    MatButtonToggleModule,
    MatCardModule,
    MatCheckboxModule,
    MatChipsModule,
    MatStepperModule,
    MatDatepickerModule,
    MatDialogModule,
    MatDividerModule,
    MatExpansionModule,
    MatGridListModule,
    MatIconModule,
    MatInputModule,
    MatListModule,
    MatMenuModule,
    MatNativeDateModule,
    MatPaginatorModule,
    MatProgressBarModule,
    MatProgressSpinnerModule,
    MatRadioModule,
    MatRippleModule,
    MatSelectModule,
    MatSidenavModule,
    MatSliderModule,
    MatSlideToggleModule,
    MatSnackBarModule,
    MatSortModule,
    MatTableModule,
    MatTabsModule,
    MatToolbarModule,
    MatTooltipModule,
    MatTreeModule,
    ROUTING
  ],
  providers: [
    DataService,
    UserService,
    ProductService,
    SessionService,
    CartService,
    CartItemDTO,
    ProductPriceDTO,
    ProductDTO,
    ProductSearchDTO,
    UserProfileDTO,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptor,
      multi: true
    }
    // {
    //   provide: Http,
    //   useFactory: httpFactory,
    //   deps: [XHRBackend, RequestOptions]
    // }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
