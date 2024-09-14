import { Component, OnInit, AfterViewChecked } from '@angular/core';
import { AdvertsService } from '../../../services/models/adverts.service';
import { advert } from '../../../contracts/adverts/advert';
import Quill from 'quill';
import { CustomToastrService, ToastrMessageType, ToastrPosition } from '../../../services/ui/custom-toastr.service';
import { UserService } from '../../../services/models/user.service';
import { Router } from '@angular/router';
import { applyAdvert } from '../../../contracts/adverts/applyAdvert';
import { ApplyAdvertService } from '../../../services/models/apply-advert.service';

@Component({
  selector: 'app-adverts',
  templateUrl: './adverts.component.html',
  styleUrl: './adverts.component.scss'
})
export class advertsComponent  implements OnInit, AfterViewChecked  {
  jobs: advert[] = [];
  quillRendered: boolean[] = [];

  constructor(private advertsService: AdvertsService, private applyAdvertService:ApplyAdvertService, private toastrService:CustomToastrService, private userService: UserService, // Kullanıcı servisi dahil edildi
    private router: Router) { }
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
        console.log('Gelen iş ilanları:', this.jobs); // Verileri kontrol et
      },
      (error) => {
        console.error('İlan verisi alınamadı', error);
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

        quill.setContents(parsedRequirements); 
      }
    } catch (e) {
      console.error('Error parsing requirements JSON', e);
    }
  }
  async applyForJob(event: Event, jobTitle: string) {
    event.preventDefault();
    const create_applyAdvert: applyAdvert = new applyAdvert();
    const username = localStorage.getItem('username'); // LocalStorage'dan username alınır
    const userDetails = await this.userService.getUser(username);
  
    if (username) {
      create_applyAdvert.nameSurname = userDetails.nameSurname;
      create_applyAdvert.address = userDetails.address;
      create_applyAdvert.advertTitle = jobTitle;
      create_applyAdvert.position = userDetails.position;
      create_applyAdvert.skills = userDetails.skills;
      create_applyAdvert.userName = username;
  
      this.applyAdvertService.create_applyAdvert(create_applyAdvert,
        () => {
          this.toastrService.message("Kayıt Başarılı", "İlan Kaydı", ToastrMessageType.Success, ToastrPosition.TopRight);
        },
        errorMessage => {
          this.toastrService.message(errorMessage, "Kayıt Durumu", ToastrMessageType.Info, ToastrPosition.TopRight);
        }
      );
    }
  }
  
}
