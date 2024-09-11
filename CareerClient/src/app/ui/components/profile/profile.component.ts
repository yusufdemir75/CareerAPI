import { Component, OnInit, AfterViewChecked } from '@angular/core';
import { UserService } from '../../../services/models/user.service';
import { profileUser } from '../../../contracts/users/profile_user';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss']
})
export class ProfileComponent implements OnInit {
  user: profileUser | null = null;
  error: string | null = null;

  

  constructor(private userservice: UserService) {}
  async ngOnInit(): Promise<void> {
    debugger;
    const username = localStorage.getItem('username')

    try {
      this.user = await this.userservice.getUser(username);
    } catch (error) {
      this.error = 'Kullanıcı verileri alınamadı.';
    }
    console.log(this.user);
  }
  
}
