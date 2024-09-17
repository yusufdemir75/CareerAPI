import { Component } from '@angular/core';
import Quill from 'quill';
import { CustomToastrService, ToastrMessageType, ToastrPosition } from '../../../services/ui/custom-toastr.service';
import { ApplyAdvertService } from '../../../services/models/apply-advert.service';
import { personelApplyAdvert } from '../../../contracts/adverts/personelApplyAdvert';
@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.scss'
})
export class HomeComponent {
  personelApplyAdverts: personelApplyAdvert[] = [];
  quillRendered: boolean[] = [];
  username=localStorage.getItem('username')

  constructor(private applyAdvertService: ApplyAdvertService, private toastrService: CustomToastrService) { }

  ngOnInit(): void {
    
    this.fetchAdverts();
  }

  fetchAdverts(): void {
    debugger;
    this.applyAdvertService.getPersonelApplies(this.username).subscribe(
      (data: personelApplyAdvert[]) => {
        this.personelApplyAdverts = data;
        this.quillRendered = Array(this.personelApplyAdverts.length).fill(false); // Quill render durumunu izlemek için array başlat
        console.log('Jobs data on ngOnInit:', this.personelApplyAdverts);
      },
      (error) => {
        console.error('Error fetching job data', error);
      }
    );
  }

  ngAfterViewChecked(): void {

    debugger;
    this.personelApplyAdverts.forEach((personelApplyAdvert, index) => {
      if (personelApplyAdvert.skills && !this.quillRendered[index]) {
        this.displayQuillContent(personelApplyAdvert.skills, `quill-container-${index}`);
        this.quillRendered[index] = true;
      }
    });
    console.log('Jobs data on ngAfterViewChecked:', this.personelApplyAdverts);
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
