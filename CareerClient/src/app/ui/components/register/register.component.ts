import { Component } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, ValidationErrors, Validators } from '@angular/forms';
import { group } from 'console';
import { user } from '../../../entities/user';
import { UserService } from '../../../services/models/user.service';
import { Create_User } from '../../../contracts/users/create_user';
import { CustomToastrService, ToastrMessageType, ToastrPosition } from '../../../services/ui/custom-toastr.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrl: './register.component.scss'
})
export class RegisterComponent {

  /**
   *
   */
  constructor(private formBuilder: FormBuilder, private userService:UserService, private toastrService: CustomToastrService) {}


    frm:FormGroup;
    ngOnInit(): void{
      this.frm=this.formBuilder.group({
        nameSurname:["",[
          Validators.required,
          Validators.maxLength(50), 
          Validators.minLength(3)]],
        username:["",[
          Validators.required,
          Validators.maxLength(50), 
          Validators.minLength(3)]],
        email:["",[
          Validators.required,
          Validators.maxLength(250), 
          Validators.minLength,
          Validators.email]],
        password:["",[
          Validators.required,
        ]],
        passwordConfirm:["",[
          Validators.required,
        ]]
      },{
        validators:(group: AbstractControl): ValidationErrors | null =>{
            let password = group.get("password").value;
            let passwordConfirm = group.get("passwordConfirm").value;
            return password === passwordConfirm ? null : {notSame:true};
        }
      })
    }
    get component(){
      return this.frm.controls
    }

    submitted:boolean=false;

    async onSubmit(user:user){
      this.submitted=true;
      
      if(this.frm.invalid)
        return;
        
    
      const result : Create_User = await this.userService.create(user)
      if (result.succeded) {
        this.toastrService.message(result.message,"Kullanıcı Kaydı Başarılı",
          ToastrMessageType.Success,
          ToastrPosition.TopRight,
        )
      }
      else{
        this.toastrService.message(result.message,"Kullanıcı Kaydı Hatalı",
          ToastrMessageType.Error,
          ToastrPosition.TopRight,
        )
      }

      
    }
    
  

}
