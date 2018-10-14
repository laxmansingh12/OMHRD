import { Component, OnInit } from '@angular/core';
import { Ng4LoadingSpinnerService } from 'ng4-loading-spinner';
import { MatDialogRef } from "@angular/material";
import { UserService } from '../../services/user.service';
import { UserProfileDTO } from '../../models/UserProfileDTO';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  user: UserProfileDTO;
  constructor(private _userService: UserService,
    private _spinnerService: Ng4LoadingSpinnerService,
    private dialogRef:MatDialogRef<RegisterComponent>) {
    this.user = new UserProfileDTO();
  }

  ngOnInit() {
  }

  registerUser() {
    this._spinnerService.show();
    this._userService.RegisterUser(this.user).subscribe(response => {
      const userId :number =Number( response);     
      if(userId > 0){
        this.dialogRef.close(userId);
      }
      console.log(userId);
      this._spinnerService.hide();
   },
     error => {
      console.error(error);
      this._spinnerService.hide();
     });
  }
}
