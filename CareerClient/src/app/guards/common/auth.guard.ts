import { Inject, inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { ToastrService } from 'ngx-toastr';
import { CustomToastrService, ToastrMessageType, ToastrPosition } from '../../services/ui/custom-toastr.service';
import { _isAuthenticated } from '../../services/common/auth.service';

export const authGuard: CanActivateFn = (route, state) => {
  const jwtHelper: JwtHelperService = inject(JwtHelperService); 
  const router:Router = inject(Router);
  const toastrService: CustomToastrService= inject(CustomToastrService);
 

  
  if (!_isAuthenticated) {
   
    router.navigate(["login"],{queryParams:{returnUrl:state.url}});
    toastrService.message("Oturum Açmanız Gerekiyor!","Yetkisiz Erişim",ToastrMessageType.Warning,ToastrPosition.TopRight)
  }
  return true;
}
