import { Injectable, Inject, PLATFORM_ID } from '@angular/core';

import { JwtHelperService } from '@auth0/angular-jwt';
import { HttpClientService } from './http-client.service';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  constructor(private jwtHelper: JwtHelperService) { }

  identityCheck() {
    
      const token: string = localStorage.getItem("accessToken");
      console.log("Token:", token);

      let expired: boolean;
      try {
        expired = this.jwtHelper.isTokenExpired(token);
      } catch {
        expired = true;
      }

      _isAuthenticated = token != null && !expired;
    
  }

  get isAuthenticated(): boolean {
    return _isAuthenticated;
  }

  
}

export let _isAuthenticated: boolean ;