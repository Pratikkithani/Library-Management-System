import { Injectable } from '@angular/core';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class RouterService {

  constructor(private router:Router) { }

  gotoDashBoard(){
    this.router.navigate(['dashBoard']);
  }
  goToLogin(){
    this.router.navigate(['login']);
  }
}
