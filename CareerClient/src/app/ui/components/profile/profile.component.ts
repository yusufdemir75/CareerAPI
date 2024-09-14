import { Component, OnInit, AfterViewChecked } from '@angular/core';
import { UserService } from '../../../services/models/user.service';
import { profileUser } from '../../../contracts/users/profile_user';
import Quill from 'quill';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss']
})
export class ProfileComponent implements OnInit, AfterViewChecked {
  user: profileUser | null = null;
  error: string | null = null;
  quillRendered: boolean = false; // Quill'in sadece bir kez render edilmesi için kontrol

  constructor(private userservice: UserService) {}

  async ngOnInit(): Promise<void> {
    const username = localStorage.getItem('username');
    try {
      this.user = await this.userservice.getUser(username);
    } catch (error) {
      this.error = 'Kullanıcı verileri alınamadı.';
    }
    console.log(this.user);
  }

  ngAfterViewChecked(): void {
    if (this.user && !this.quillRendered) {
      this.displayQuillContent(this.user.skills, 'quill-container');
      this.quillRendered = true;
    }
  }

  displayQuillContent(skills: string, containerId: string): void {
    try {
      const parsedSkills = JSON.parse(skills); // Eğer skills JSON formatında geliyorsa
      const quillContainer = document.getElementById(containerId);

      if (quillContainer) {
        const quill = new Quill(quillContainer, {
          theme: 'snow',
          readOnly: true,
          modules: {
            toolbar: false
          }
        });

        quill.setContents(parsedSkills);
      }
    } catch (e) {
      console.error('Error parsing skills JSON', e);
    }
  }
}
