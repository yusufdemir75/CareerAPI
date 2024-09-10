import { Component } from '@angular/core';
import { CustomToastrService, ToastrMessageType, ToastrPosition } from './services/ui/custom-toastr.service';
import { AuthService } from './services/common/auth.service';
import { UserService } from './services/models/user.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent {
  userRole: string | null = null; 

  constructor(public authService:AuthService,private toastrService:CustomToastrService, private userService: UserService) {}

  async ngOnInit() {
    this.userRole = localStorage.getItem('userRole'); // Kullanıcı rolünü localStorage'dan alıyorum
    this.authService.identityCheck();
    
  }

  signOut(){
    localStorage.removeItem("accessToken");
    localStorage.removeItem("userRole"); 
    this.authService.identityCheck();
    this.toastrService.message("Oturum Kapatılmıştır","Çıkış Başarılı",ToastrMessageType.Info,ToastrPosition.TopRight);
  }
}
