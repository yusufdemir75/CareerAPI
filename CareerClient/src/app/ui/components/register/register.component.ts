import { Component } from '@angular/core';
import { AbstractControl, FormBuilder, FormGroup, ValidationErrors, Validators } from '@angular/forms';
import { group } from 'console';
import { user } from '../../../entities/user';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrl: './register.component.scss'
})
export class RegisterComponent {

  /**
   *
   */
  constructor(private formBuilder: FormBuilder) {}


    frm:FormGroup;
    ngOnInit(): void{
      this.frm=this.formBuilder.group({
        adSoyad:["",[
          Validators.required,
          Validators.maxLength(50), 
          Validators.minLength(3)]],
        kullaniciAdi:["",[
          Validators.required,
          Validators.maxLength(50), 
          Validators.minLength(3)]],
        email:["",[
          Validators.required,
          Validators.maxLength(250), 
          Validators.minLength,
          Validators.email]],
        sifre:["",[
          Validators.required,
        ]],
        sifreTekrar:["",[
          Validators.required,
        ]]
      },{
        validators:(group: AbstractControl): ValidationErrors | null =>{
            let sifre = group.get("sifre").value;
            let sifreTekrar = group.get("sifreTekrar").value;
            return sifre === sifreTekrar ? null : {notSame:true};
        }
      })
    }
    get component(){
      return this.frm.controls
    }

    submitted:boolean=false;

    onSubmit(data:user){
      this.submitted=true;
      debugger;
      if(this.frm.invalid)
        return;
        debugger;
    }
    
  

}
