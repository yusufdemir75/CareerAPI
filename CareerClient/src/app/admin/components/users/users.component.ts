import { Component, OnInit, AfterViewChecked } from '@angular/core';
import Quill from 'quill';
import { CustomToastrService, ToastrMessageType, ToastrPosition } from '../../../services/ui/custom-toastr.service';
import { ApplyAdvertService } from '../../../services/models/apply-advert.service';
import { applyAdvert } from '../../../contracts/adverts/applyAdvert';
import { approvedAdvert } from '../../../contracts/adverts/approvedAdvert';
import * as XLSX from 'xlsx';

declare var $ :any;

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
  success(advertNo: number): void {

    const updatedAdvert: approvedAdvert = {
      advertNo: advertNo,  // idString kullanarak `string` türünde Id'yi atıyoruz
      isApproved: true,
      status: "Başvuru Onaylandı"
    };

    this.applyAdvertService.update_applyAdvert(advertNo, updatedAdvert, 
      () => {
        this.toastrService.message("Başvuru başarıyla onaylandı.","ONAY",ToastrMessageType.Success,ToastrPosition.TopRight);
        this.fetchAdverts(); 
      },
      (errorMessage) => {
        this.toastrService.message("Başvuru Durumu ", errorMessage,ToastrMessageType.Info,ToastrPosition.TopRight);
      }
    );
  }

  reject(advertNo: number): void {

    const updatedAdvert: approvedAdvert = {
      advertNo: advertNo,  // idString kullanarak `string` türünde Id'yi atıyoruz
      isApproved: false,
      status: "Başvuru Reddedildi"
    };

    this.applyAdvertService.update_applyAdvert(advertNo, updatedAdvert, 
      () => {
        this.toastrService.message("Başvuru reddedildi.","RED",ToastrMessageType.Success,ToastrPosition.TopRight);
        this.fetchAdverts();
      },
      (errorMessage) => {
        this.toastrService.message("Başvuru Durumu.",errorMessage,ToastrMessageType.Info,ToastrPosition.TopRight);
      }
    );
  }
  
  delete(advertNo,event){
    this.applyAdvertService.delete_applyAdvert(advertNo,
      () => {
        console.log("İlan başarıyla silindi.");
        // Başarılı işlem sonrası yapılacaklar
      },
      (errorMessage: string) => {
        console.error("Hata:", errorMessage);
        // Hata mesajını kullanıcıya gösterebilirsin
      });
    const btn: HTMLButtonElement=event.srcElement;
    $(btn.parentElement.parentElement.parentElement).fadeOut(2000);
  }










  exportExcel(): void {
    const selectedData = this.applyAdverts.map(advert => ({
      advertNo: advert.advertNo,
      name: advert.nameSurname,
      address:advert.address,
      advertTitle:advert.advertTitle,
      position:advert.position,
      cvUrl:advert.cvUrl,
      status: advert.status,
    }));
  
    const worksheet: XLSX.WorkSheet = XLSX.utils.json_to_sheet(selectedData);
    const workbook: XLSX.WorkBook = { Sheets: { 'Başvurular': worksheet }, SheetNames: ['Başvurular'] };
    XLSX.writeFile(workbook, 'basvurular.xlsx');
  }
}



