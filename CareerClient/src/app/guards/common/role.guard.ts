import { CanActivateFn, Router, UrlTree } from '@angular/router';
import { CustomToastrService, ToastrMessageType, ToastrPosition } from '../../services/ui/custom-toastr.service';
import { inject } from '@angular/core';
import { JwtHelperService } from '@auth0/angular-jwt';
import { _isAuthenticated } from '../../services/common/auth.service';

export const roleGuard: CanActivateFn = (route, state) => {

  const jwtHelper: JwtHelperService = inject(JwtHelperService); 
  const router: Router = inject(Router);
  const toastrService: CustomToastrService = inject(CustomToastrService);
  const userRole = localStorage.getItem('userRole');

  // Kullanıcının oturum açıp açmadığını kontrol et
  if (!_isAuthenticated) {
    toastrService.message("Oturum Açmanız Gerekiyor!", "Yetkisiz Erişim", ToastrMessageType.Warning, ToastrPosition.TopRight);
    router.navigate(["login"], { queryParams: { returnUrl: state.url } });
    return false;
  }

  // Kullanıcının rolünü kontrol et
  if (userRole !== 'Customer') {
    toastrService.message("Kullanıcı Rolünüz Geçerli Değil!", "Yetkisiz Erişim", ToastrMessageType.Warning, ToastrPosition.TopRight);
    router.navigate(["admin/adverts"], { queryParams: { returnUrl: state.url } });
    return false;
  }

  // Tüm kontroller başarılı ise erişime izin ver
  return true;
};
