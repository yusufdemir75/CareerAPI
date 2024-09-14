import { Component } from '@angular/core';
import { QuillEditorComponent } from 'ngx-quill';
import { Delta } from 'quill/core';
import { CustomToastrService, ToastrMessageType, ToastrPosition } from '../../../services/ui/custom-toastr.service';
import { HttpClientService } from '../../../services/common/http-client.service';
import { UserService } from '../../../services/models/user.service';
import { updateUser } from '../../../contracts/users/update_user';
import { AngularFireStorage } from '@angular/fire/compat/storage';
import { finalize } from 'rxjs';

@Component({
  selector: 'app-create-profile',
  templateUrl: './create-profile.component.html',
  styleUrl: './create-profile.component.scss'
})
export class CreateProfileComponent {

  userName: string | null = null;
  constructor(private userService:UserService,private toastrService:CustomToastrService,private storage: AngularFireStorage) {
    this.userName = localStorage.getItem('username');
  }
  selectedFile: File | null = null;
  fileUrl:string | null=null


  // Handle file input change
  OnFileChange(event: any) {
    const file = event.target.files[0];
    if (file) {
      this.selectedFile = file;
      this.uploadFile();  // Call upload function
    }
  }

  // Upload the file to Firebase Storage
  uploadFile() {
    if (this.selectedFile) {
      const filePath = `profile_pics/${Date.now()}_${this.selectedFile.name}`;
      const fileRef = this.storage.ref(filePath);
      const task = this.storage.upload(filePath, this.selectedFile);
      task.snapshotChanges().pipe(
        finalize(() => {
          fileRef.getDownloadURL().subscribe(url => {
            this.fileUrl= url;
            console.log('File URL:', this.fileUrl); // Log file URL after successful upload
          });
        })
      ).subscribe();
    } else {
      console.error('No file selected!');
    }
  }

  
  updateUser(event: Event,position:HTMLInputElement,PhoneNumber:HTMLInputElement ,address:HTMLInputElement,age:HTMLInputElement,skills:QuillEditorComponent, instaLink:HTMLInputElement,githubLink:HTMLInputElement,twitterLink:HTMLInputElement) {
    event.preventDefault(); 
    const delta: Delta = skills.quillEditor.getContents();
    debugger;
    const updateRequest: updateUser = {
      position: position.value,
      PhoneNumber:PhoneNumber.value,
      address: address.value,
      age: age.value,
      skills: JSON.stringify(delta),
      instaLink: instaLink.value,
      githubLink: githubLink.value,
      twitterLink: twitterLink.value,
      userName:this.userName,
      imageUrl:this.fileUrl
    };
    console.log('Update Request:', updateRequest);
    debugger;
    this.userService.updateUser(updateRequest).then(() => {
      this.toastrService.message("Güncelleme Başarılı", "Başarılı", ToastrMessageType.Success, ToastrPosition.TopRight);
    }).catch(() => {
      this.toastrService.message("Güncelleme işlemi sırasında bir hata oluştu.", "Başarısız", ToastrMessageType.Error, ToastrPosition.TopRight);
    });
  }


}
