import { Component } from '@angular/core';
import { UserService } from '../../../services/models/user.service';
import { AuthService } from '../../../services/common/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss'] // Düzeltilmiş dosya adı
})
export class LoginComponent {
  constructor(private userService: UserService, private authService: AuthService, private router: Router) {}

  async ngOnInit() {
    localStorage.removeItem("accessToken");
    localStorage.removeItem("userRole");
    
  
    
  }

  async login(UsernameOrEmail: string, Password: string) {
    if (UsernameOrEmail && Password) {
      try {
        await this.userService.login(UsernameOrEmail, Password, async () => {
          try {
            const role = await this.userService.getUserRole(UsernameOrEmail);
            localStorage.setItem('userRole', role);
            localStorage.setItem('username',UsernameOrEmail)

            // Token'in alınıp kaydedildiğinden emin olmak için küçük bir gecikme ekliyorum
            this.authService.identityCheck();

            // Kullanıcı rolüne göre yönlendirme yapalım
            if (role === 'Admin') {
              this.router.navigate(['admin']).then(() => {
                // Sayfanın 1 kere daha yenilenmesini sağlamak için
                setTimeout(() => {
                  window.location.reload();
                }, 0); 
              });
            } else if (role === 'Customer') {
              this.router.navigate(['home']).then(() => {
                // Sayfanın 1 kere daha yenilenmesini sağlamak için
                setTimeout(() => {
                  window.location.reload();
                }, 0); 
              });
            } else {
              console.error('Bilinmeyen rol:', role);
            }
            
          } catch (error) {
            console.error('Rol alınırken bir hata oluştu:', error);
          }
        });
      } catch (error) {
        console.error('Giriş yapılırken bir hata oluştu:', error);
      }
    } else {
      console.error('Kullanıcı adı veya şifre boş olamaz');
    }
  }
}
