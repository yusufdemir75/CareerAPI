import { Component } from '@angular/core';
import { QuillEditorComponent } from 'ngx-quill';
import { Delta } from 'quill/core';
import { CustomToastrService, ToastrMessageType, ToastrPosition } from '../../../services/ui/custom-toastr.service';
import { HttpClientService } from '../../../services/common/http-client.service';
import { UserService } from '../../../services/models/user.service';
import { updateUser } from '../../../contracts/users/update_user';

@Component({
  selector: 'app-create-profile',
  templateUrl: './create-profile.component.html',
  styleUrl: './create-profile.component.scss'
})
export class CreateProfileComponent {

  userName: string | null = null;
  constructor(private userService:UserService,private toastrService:CustomToastrService) {
    this.userName = localStorage.getItem('username');
  }

  
  updateUser(position:HTMLInputElement,address:HTMLInputElement,birthDate:HTMLInputElement,skills:QuillEditorComponent,instaLink:HTMLInputElement,githubLink:HTMLInputElement,twitterLink:HTMLInputElement) {
    const delta: Delta = skills.quillEditor.getContents();
    debugger;
    const updateRequest: updateUser = {
      position: position.value,
      address: address.value,
      birthDate: new Date(birthDate.value), 
      skills: JSON.stringify(delta),
      instaLink: instaLink.value,
      githubLink: githubLink.value,
      twitterLink: twitterLink.value,
      userName:this.userName
    };
    console.log('Update Request:', updateRequest);

    this.userService.updateUser(updateRequest).then(() => {
    });
  }


}
