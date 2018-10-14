import {RouterModule,Routes} from '@angular/router';
import { ModuleWithProviders } from '@angular/core/src/metadata/ng_module';
 import { EcomMasterComponent } from './ecom/master/ecommaster.component';
 import { EcomHomeComponent } from './ecom/home/home.component';
 import { EcomProductsComponent } from './ecom/products/products.component';
 import { ProductDetailsComponent } from './ecom/product-details/product-details.component';
 import { CheckoutComponent } from './ecom/checkout/checkout.component';

// import { AuthGuard } from './auth.guard'


export const AppRoutes: Routes =[
  {
    path: '', component: EcomMasterComponent, data: { title: 'OMHRD Shopping' },
    children: [ 
      { path: '', component: EcomHomeComponent },
      { path: 'new-collection', component: EcomHomeComponent },
      { path: 'products', component: EcomProductsComponent },
      { path: 'product-detail', component: ProductDetailsComponent },
      { path: 'checkout', component: CheckoutComponent },
    ]
  },

  { path: '**', redirectTo: '' }

];
export const ROUTING: ModuleWithProviders = RouterModule.forRoot(AppRoutes);

