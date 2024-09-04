import { Component } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { CustomToastrService, ToastrMessageType, ToastrPosition } from './services/ui/custom-toastr.service';
import { AuthService } from './services/common/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent {
 
 
  constructor(public authService:AuthService,private toastrService:CustomToastrService) {
  
   this.authService.identityCheck();
  }
  
  signOut(){
    localStorage.removeItem("accessToken");
    this.authService.identityCheck();
    this.toastrService.message("Oturum Kapatılmıştır","Çıkış Başarılı",ToastrMessageType.Info,ToastrPosition.TopRight)

  }
  
}




