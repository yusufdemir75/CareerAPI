import { Component, OnInit, AfterViewChecked } from '@angular/core';
import { AdvertsService } from '../../../services/models/adverts.service';
import { advert } from '../../../contracts/adverts/advert';
import Quill from 'quill';
import { CustomToastrService, ToastrMessageType, ToastrPosition } from '../../../services/ui/custom-toastr.service';

@Component({
  selector: 'app-adverts',
  templateUrl: './adverts.component.html',
  styleUrl: './adverts.component.scss'
})
export class advertsComponent  implements OnInit, AfterViewChecked  {
  jobs: advert[] = [];
  quillRendered: boolean[] = [];

  constructor(private advertsService: AdvertsService, private toastrService:CustomToastrService) { }
  ngOnInit(): void {
    this.updateAllAdverts();
    this.fetchAdverts();
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
    this.advertsService.getActiveAdverts().subscribe(
      (data: advert[]) => {
        this.jobs = data;
        this.quillRendered = Array(this.jobs.length).fill(false); // Quill render durumunu izlemek için array başlat
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
        this.quillRendered[index] = true; // Bu index'te Quill render edildi
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

        quill.setContents(parsedRequirements); // Quill içeriğini ayarla
      }
    } catch (e) {
      console.error('Error parsing requirements JSON', e);
    }
  }
}
