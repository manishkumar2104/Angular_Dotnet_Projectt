import { CanActivateFn, Router } from '@angular/router';
import { inject } from "@angular/core";

export const userAuthGuard: CanActivateFn = (route, state) => {
  let _router= inject(Router);
  if(localStorage.getItem('isUserLoggedIn')=='true'){
    return true;
  }
  else{
    alert('You Need to Login First to Access this Page');
    _router.navigate(['login']);
    return false;
  }
};
