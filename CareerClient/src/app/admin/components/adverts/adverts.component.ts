import { Component } from '@angular/core';
import { AdvertsService } from '../../../services/models/adverts.service';
import { advert } from '../../../contracts/adverts/advert';
import { FormBuilder, FormGroup } from '@angular/forms';
import { QuillEditorComponent } from 'ngx-quill';
import { Delta } from 'quill/core';
import { CustomToastrService, ToastrMessageType, ToastrPosition } from '../../../services/ui/custom-toastr.service';

@Component({
  selector: 'app-adverts',
  templateUrl: './adverts.component.html',
  styleUrl: './adverts.component.scss'
})
export class AdvertsComponent {
  
  
  constructor(private advertsService:AdvertsService, private toastrService:CustomToastrService) {
  }

  
  


  create(event:Event,title:HTMLInputElement,companyName:HTMLInputElement,address:HTMLInputElement, position:HTMLInputElement, typeOfWork:HTMLSelectElement,requirement:QuillEditorComponent,date:HTMLInputElement){
    event.preventDefault();

    const create_advert: advert = new advert();
    create_advert.title= title.value;
    create_advert.address=address.value;
    create_advert.companyName = companyName.value;
    create_advert.position=position.value;
    create_advert.typeOfWork=typeOfWork.value;

    const delta: Delta = requirement.quillEditor.getContents();
    create_advert.requirements = JSON.stringify(delta);

    create_advert.EndDate = new Date(date.value);

    this.advertsService.create_advert(create_advert,()=>{
      this.toastrService.message("Kayıt Başarılı","İlan Kaydı",ToastrMessageType.Success,ToastrPosition.TopRight)
    },errorMesage=>{
      this.toastrService.message(errorMesage,"Kayıt Yapılamadı",ToastrMessageType.Error,ToastrPosition.TopRight)
    })
    

    
  }
  
}
