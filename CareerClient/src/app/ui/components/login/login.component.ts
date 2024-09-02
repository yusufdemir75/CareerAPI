import { Component } from '@angular/core';
import { UserService } from '../../../services/models/user.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss'
})
export class LoginComponent {

  
  constructor(private userService :UserService) {
    
    
  }

 async login(UsernameOrEmail:string,Password:string){
    await this.userService.login(UsernameOrEmail,Password)
  }
}
