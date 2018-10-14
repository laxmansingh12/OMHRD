import { Injectable } from '@angular/core';
import 'rxjs/add/operator/map';
import { UserProfileDTO } from '../models/UserProfileDTO';

@Injectable()
export class SessionService {

  constructor() {
  }

  getToken() {
    return localStorage.getItem("_ATHUSTN_");
  }

  setToken(token) {
    localStorage.setItem("_ATHUSTN_",token);
  }
  getUser() {
    const user = localStorage.getItem("_LGINUR_");
    if(user && user != null && user != undefined){
      return JSON.parse(user);
    }
    return null;
  }

  isUserLoggedIn() {
    const user = localStorage.getItem("_LGINUR_");
    if(user && user != null && user != undefined){
      return true;
    }
    return false;
  }

  setUser(user) {    
    const jsonUser = JSON.stringify(user)
    localStorage.setItem("_LGINUR_",jsonUser);
  }
  
  resetUserData() {    
    localStorage.removeItem("_LGINUR_");
    localStorage.removeItem("_ATHUSTN_");
  }
}
