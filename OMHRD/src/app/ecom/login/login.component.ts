import { Component, OnInit } from '@angular/core';
import { MatFormFieldControl, MatDialogRef } from '@angular/material';
import { UserService } from '../../services/user.service';
import { SessionService } from '../../services/session.service';
import { Ng4LoadingSpinnerService } from 'ng4-loading-spinner';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  username: string;
  password: string;
  constructor(private _userService: UserService,
    private _spinnerService: Ng4LoadingSpinnerService,
    private _sessionService: SessionService,
    private dialogRef: MatDialogRef<LoginComponent>) { }
  ngOnInit() {
  }
  doLogin() {
    this._spinnerService.show();
    this._userService.DoLogin(this.username, this.password).subscribe(response => {
      const user: any = response;
      if (user && user != null && user != undefined) {
        this._sessionService.setUser(user);
        this.dialogRef.close(true);
      }
      else {
        console.log("invalid ");
      }
      this._spinnerService.hide();
    },
      error => {
        console.error(error);
        this._spinnerService.hide();
      });
  }
}
