import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { NgbModalConfig, NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Ng4LoadingSpinnerService } from 'ng4-loading-spinner';
import { MatDialogModule } from '@angular/material/dialog';
import { MatDialog } from '@angular/material';
import { LoginComponent } from '../login/login.component';
import { RegisterComponent } from '../register/register.component';
import { SessionService } from '../../services/session.service';
import { DataService } from '../../services/data.service';
import { CartService } from 'src/app/services/cart.service';

@Component({
  selector: 'ecom-master',
  templateUrl: './ecommaster.component.html',
  styleUrls: ['./ecommaster.component.css'],
  providers: [NgbModalConfig, NgbModal]
})
export class EcomMasterComponent implements OnInit {
  userProfile: Object;
  isUserLoggedIn: boolean;
  cartValue: number;
  cartQty: number;

  constructor(
    private _sessionService: SessionService,
    private router: Router,
    config: NgbModalConfig,
    public dialog: MatDialog,
    private data: DataService,
    private _cartService: CartService,
    private _spinnerService: Ng4LoadingSpinnerService,
  ) {
    config.backdrop = 'static';
    config.keyboard = true;
    this.userProfile = this._sessionService.getUser();
    this.isUserLoggedIn = this._sessionService.isUserLoggedIn();
    this.data.cartValue.subscribe(value => this.cartValue = value);
    this.data.cartQty.subscribe(value => this.cartQty = value);
  }

  ngOnInit() {
    this.updateCartTotal();
  }

  logout() {
    this._sessionService.resetUserData();
    this.userProfile = {};;
    this.isUserLoggedIn = false;
    this.cartValue = 0;
    this.cartQty = 0;
    this.router.navigate(['/']);
  }

  gotoCheckout() {
    if (this._sessionService.isUserLoggedIn()) {
      this.router.navigate(['/checkout']);
    }
    else{
      this.openLoginDialog();
    }
  }

  openLoginDialog() {
    const dialogRef = this.dialog.open(LoginComponent, {
      width: '450px',
      disableClose: false
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        this.userProfile = this._sessionService.getUser();
        this.isUserLoggedIn = this._sessionService.isUserLoggedIn();
        this.updateCartTotal();
      }
    });
  }

  private updateCartTotal() {
    this._cartService.getCartTotal(this._sessionService.getUser().Id).subscribe(response => {
      const data: any = response;
      this.cartValue = data.TotalPrice;
      this.cartQty = data.Quantity;
    },
      error => {
        console.error(JSON.stringify(error));
      });
  }

  openRegisterDialog() {
    const dialogRegisterRef = this.dialog.open(RegisterComponent, {
      width: '800px',
      //disableClose: true 
    });

    dialogRegisterRef.afterClosed().subscribe(result => {
      if (result != null && result != undefined) {
        this.openLoginDialog();
      }
    });
  }

}
