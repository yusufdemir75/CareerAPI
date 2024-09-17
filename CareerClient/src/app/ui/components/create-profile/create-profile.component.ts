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
  fileUrl:string | null=null;
  fileCvUrl:string| null=null;


  // Handle file input change
  OnFileImageChange(event: any) {
    const file = event.target.files[0];
    if (file) {
      this.selectedFile = file;
      this.uploadImageFile();  // Call upload function
    }
  }
  OnFileCvChange(event:any){
    const file = event.target.files[0];
    if (file) {
      this.selectedFile = file;
      this.uploadCvFile();  // Call upload function
    }
  }

  // Upload the file to Firebase Storage
  uploadImageFile() {
    if (this.selectedFile) {
      const filePath = `profile_pics/${Date.now()}_${this.selectedFile.name}`;
      const fileRef = this.storage.ref(filePath);
      const task = this.storage.upload(filePath, this.selectedFile);
      task.snapshotChanges().pipe(
        finalize(() => {
          fileRef.getDownloadURL().subscribe(url => {
            this.fileUrl= url;
            console.log('İmage URL:', this.fileUrl); 
          });
        })
      ).subscribe();
    } else {
      console.error('No file selected!');
    }
  }
  uploadCvFile() {
    if (this.selectedFile) {
      const filePath = `user_cv/${Date.now()}_${this.selectedFile.name}`;
      const fileRef = this.storage.ref(filePath);
      const task = this.storage.upload(filePath, this.selectedFile);
      task.snapshotChanges().pipe(
        finalize(() => {
          fileRef.getDownloadURL().subscribe(url => {
            this.fileCvUrl= url;
            console.log('Cv URL:', this.fileUrl); // Log file URL after successful upload
          });
        })
      ).subscribe();
    } else {
      console.error('No file selected!');
    }
  }
  
  updateUser(event: Event,nameSurname:HTMLInputElement, position:HTMLInputElement,PhoneNumber:HTMLInputElement ,address:HTMLInputElement,age:HTMLInputElement,skills:QuillEditorComponent, instaLink:HTMLInputElement,githubLink:HTMLInputElement,twitterLink:HTMLInputElement) {
    event.preventDefault(); 
    const delta: Delta = skills.quillEditor.getContents();
    debugger;
    const updateRequest: updateUser = {
      nameSurname:nameSurname.value,
      position: position.value,
      PhoneNumber:PhoneNumber.value,
      address: address.value,
      age: age.value,
      skills: JSON.stringify(delta),
      instaLink: instaLink.value,
      githubLink: githubLink.value,
      twitterLink: twitterLink.value,
      userName:this.userName,
      imageUrl:this.fileUrl,
      cvUrl:this.fileCvUrl
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
