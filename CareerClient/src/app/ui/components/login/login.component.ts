import { Component } from '@angular/core';
import { UserService } from '../../../services/models/user.service';
import { AuthService } from '../../../services/common/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss'
})
export class LoginComponent {

  constructor(private userService: UserService, private authService: AuthService, private router: Router) {}

  login(UsernameOrEmail: string, Password: string) {
    this.userService.login(UsernameOrEmail, Password, () => {
      // Token'in alınıp kaydedildiğinden emin olmak için küçük bir gecikme ekliyoruz
      setTimeout(() => {
        this.authService.identityCheck();
        // Başarılı girişten sonra yönlendirme
        this.router.navigate(["admin"]); 
      }, 0);
    });
  }
}
