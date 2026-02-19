import { inject } from '@angular/core';
import { CanActivateFn } from '@angular/router';
import { LoginService } from './services/login.service';
import { TokenService } from './services/token.service';

export const authGuard: CanActivateFn = (route, state) => {


  const userService=inject(LoginService);
  if(userService.isLoggedIn()){
    return true;
  }
  else{
    return false;
  }



  // const userService = inject(LoginService);
  // const tokenService = inject(TokenService);
  // if (userService.isLoggedIn()) {
  //   const userRole = tokenService.getUserRole();
  //   const allowedRoles = route.data['roles']; 

  //   if (allowedRoles && allowedRoles.includes(userRole)) {
  //     return true; 
  //   } else {
  //     return false;
  //   }
  // } else {
  //   return false;
  // }
};
