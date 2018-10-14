import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import 'rxjs/add/operator/map';
import { UserProfileDTO } from '../models/UserProfileDTO';

@Injectable()
export class UserService {

  constructor(private _http:HttpClient) {
   }
      
  RegisterUser(userProfile:UserProfileDTO){
    var jsonData = JSON.stringify(userProfile);
    return this._http.post('user/register', jsonData);
  }
  
  DoLogin(username : string, password:string){
    return this._http.get('user/login/username/'+ username + "/password/"+ password);
  }
   
  IsUsernameAvailable(username : string){
    return this._http.get('user/checkavailable/username/'+ username);
  }
}
