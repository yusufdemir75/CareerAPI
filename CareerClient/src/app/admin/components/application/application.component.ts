import { Component, OnInit, AfterViewChecked } from '@angular/core';
import { AdvertsService } from '../../../services/models/adverts.service';
import { advert } from '../../../contracts/adverts/advert';
import Quill from 'quill';
import { CustomToastrService, ToastrMessageType, ToastrPosition } from '../../../services/ui/custom-toastr.service';
declare var $:any;
@Component({
  selector: 'app-application',
  templateUrl: './application.component.html',
  styleUrls: ['./application.component.scss']
})
export class ApplicationComponent implements OnInit, AfterViewChecked {
  jobs: advert[] = [];
  quillRendered: boolean[] = [];

  constructor(private advertsService: AdvertsService, private toastrService:CustomToastrService) { }

  ngOnInit(): void {
    
    this.fetchAdverts();
    this.updateAllAdverts();
  }

  updateAllAdverts(): void {
    this.advertsService.updateAllAdverts(
      () => {
        console.log('All adverts updated successfully');
        this.fetchAdverts(); // Güncellemeden sonra verileri tekrar al
      },
      (errorMessage) => {
        console.error('Error updating adverts:', errorMessage);
        this.toastrService.message("Güncelleme Hatası","Başarısız",ToastrMessageType.Error,ToastrPosition.TopRight)
      }
    );
  }

  fetchAdverts(): void {
    debugger;
    this.advertsService.getAdverts().subscribe(
      
      (data: advert[]) => {
        this.jobs = data;
        this.quillRendered = Array(this.jobs.length).fill(false); 
        console.log('Jobs data on ngOnInit:', this.jobs);
      },
      (error) => {
        console.error('Error fetching job data', error);
      }
    );
  }

  ngAfterViewChecked(): void {
    this.jobs.forEach((job, index) => {
      if (job.requirements && !this.quillRendered[index]) {
        this.displayQuillContent(job.requirements, `quill-container-${index}`);
        this.quillRendered[index] = true;
      }
    });
    console.log('Jobs data on ngAfterViewChecked:', this.jobs);
  }

  displayQuillContent(requirements: string, containerId: string): void {
    try {
      const parsedRequirements = JSON.parse(requirements);
      const quillContainer = document.getElementById(containerId);

      if (quillContainer) {
        const quill = new Quill(quillContainer, {
          theme: 'snow',
          readOnly: true,
          modules: {
            toolbar: false
          }
        });

        quill.setContents(parsedRequirements); 
      }
    } catch (e) {
      console.error('Error parsing requirements JSON', e);
    }
  }

  deleteAdvert(advertNo:number,event){
    this.advertsService.delete_Advert(advertNo,
      () => {
        this.toastrService.message("Silme işlemi Yapıldı","İlan İşlemi",ToastrMessageType.Success,ToastrPosition.TopRight)
      },
      (errorMessage: string) => {
        this.toastrService.message("Silme işlemi Yapılamadı","İlan İşlemi",ToastrMessageType.Error,ToastrPosition.TopRight)
      });
    const btn: HTMLButtonElement=event.srcElement;
    $(btn.parentElement.parentElement.parentElement).fadeOut(2000);
    
  }
}
