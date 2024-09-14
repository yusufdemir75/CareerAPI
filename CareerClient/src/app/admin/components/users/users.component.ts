import { Component, OnInit, AfterViewChecked } from '@angular/core';
import { AdvertsService } from '../../../services/models/adverts.service';
import { advert } from '../../../contracts/adverts/advert';
import Quill from 'quill';
import { CustomToastrService, ToastrMessageType, ToastrPosition } from '../../../services/ui/custom-toastr.service';
import { ApplyAdvertService } from '../../../services/models/apply-advert.service';
import { applyAdvert } from '../../../contracts/adverts/applyAdvert';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.scss']
})
export class UsersComponent implements OnInit, AfterViewChecked {
  applyAdverts: applyAdvert[] = [];
  quillRendered: boolean[] = [];

  constructor(private applyAdvertService: ApplyAdvertService, private toastrService: CustomToastrService) { }

  ngOnInit(): void {
    this.fetchAdverts();
  }

  fetchAdverts(): void {
    this.applyAdvertService.getApplyAdverts().subscribe(
      (data: applyAdvert[]) => {
        this.applyAdverts = data;
        this.quillRendered = Array(this.applyAdverts.length).fill(false); // Quill render durumunu izlemek için array başlat
        console.log('Jobs data on ngOnInit:', this.applyAdverts);
      },
      (error) => {
        console.error('Error fetching job data', error);
      }
    );
  }

  ngAfterViewChecked(): void {
    this.applyAdverts.forEach((applyAdvert, index) => {
      if (applyAdvert.skills && !this.quillRendered[index]) {
        this.displayQuillContent(applyAdvert.skills, `quill-container-${index}`);
        this.quillRendered[index] = true;
      }
    });
    console.log('Jobs data on ngAfterViewChecked:', this.applyAdverts);
  }

  displayQuillContent(skills: string, containerId: string): void {
    try {
      const parsedRequirements = JSON.parse(skills);
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
}
