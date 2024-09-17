import { Injectable } from '@angular/core';
import { HttpClientService } from '../common/http-client.service';
import { CustomToastrService } from '../ui/custom-toastr.service';
import { applyAdvert } from '../../contracts/adverts/applyAdvert';
import{approvedAdvert} from '../../contracts/adverts/approvedAdvert';
import { HttpErrorResponse } from '@angular/common/http';
import { Observable } from 'rxjs';
import { personelApplyAdvert } from '../../contracts/adverts/personelApplyAdvert';

@Injectable({
  providedIn: 'root'
})
export class ApplyAdvertService {

  constructor(private httpClientService: HttpClientService, private toastrService: CustomToastrService) { }

  async create_applyAdvert(applyAdvert: applyAdvert, successCallBack?: () => void, errorCallBack?: (errorMessage: string) => void) {
    this.httpClientService.post({
      controller: "ApplyAdvert"
    }, applyAdvert).subscribe({
      next: result => {
        if (successCallBack) {
          successCallBack();
        }
      },
      error: (errorResponse: HttpErrorResponse) => {
        let message = "";

        console.log("Error Response:", errorResponse);

        // Hata mesajını al
        if (errorResponse.error && errorResponse.error.text) {
          message = errorResponse.error.text; // Sadece 'text' kısmını al
        } else if (typeof errorResponse.error === 'string') {
          message = errorResponse.error; // Hata mesajı düz metin olarak gelebilir
        } else if (typeof errorResponse.error === 'object') {
          // Eğer hata bir nesne ise, hata detaylarını alalım
          message = JSON.stringify(errorResponse.error);
        } else {
          message = "Bilinmeyen bir hata oluştu.";
        }

        // Hata durumunda errorCallBack çağrılır
        if (errorCallBack) {
          errorCallBack(message);
        }
      },
    });
  }

  update_applyAdvert(advertNo: number, approvedAdvert: approvedAdvert, successCallBack?: () => void, errorCallBack?: (errorMessage: string) => void): void {
    this.httpClientService.put({
      controller: 'ApplyAdvert',
      action: `${encodeURIComponent(advertNo)}`
    }, approvedAdvert).subscribe({
      next: result => {
        if (successCallBack) {
          successCallBack();
        }
      },
      error: (errorResponse: HttpErrorResponse) => {
        let message = "";

        console.log("Error Response:", errorResponse);

        // Hata mesajını al
        if (errorResponse.error && errorResponse.error.text) {
          message = errorResponse.error.text; 
        } else if (typeof errorResponse.error === 'string') {
          message = errorResponse.error; 
        } else if (typeof errorResponse.error === 'object') {
          message = JSON.stringify(errorResponse.error);
        } else {
          message = "Bilinmeyen bir hata oluştu.";
        }

        // Hata durumunda errorCallBack çağrılır
        if (errorCallBack) {
          errorCallBack(message);
        }
      },
    });
}

  getApplyAdverts(): Observable<applyAdvert[]> {
    return this.httpClientService.get<applyAdvert[]>({
      controller: 'ApplyAdvert'
    });
  }

  getPersonelApplies(userName:string): Observable<personelApplyAdvert[]> {
    return this.httpClientService.get<personelApplyAdvert[]>({
      controller: 'ApplyAdvert',
      action: 'getpersonelapplies'
    }, `${encodeURIComponent(userName)}`);
  }

  async delete_applyAdvert(advertNo: number, successCallBack?: () => void, errorCallBack?: (errorMessage: string) => void): Promise<void> {
    this.httpClientService.delete({
      controller: 'ApplyAdvert' // ApplyAdvert controller'ına istek yapıyoruz
    }, `${encodeURIComponent(advertNo)}`).subscribe({
      next: result => {
        if (successCallBack) {
          successCallBack(); // Başarılı işlem sonrası callback çağrılıyor
        }
      },
      error: (errorResponse: HttpErrorResponse) => {
        let message = "";
  
        console.log("Error Response:", errorResponse);
  
        // Hata mesajını anlamlı hale getirme
        if (errorResponse.error && errorResponse.error.text) {
          message = errorResponse.error.text;
        } else if (typeof errorResponse.error === 'string') {
          message = errorResponse.error;
        } else if (typeof errorResponse.error === 'object') {
          message = JSON.stringify(errorResponse.error);
        } else {
          message = "Bilinmeyen bir hata oluştu.";
        }
  
        if (errorCallBack) {
          errorCallBack(message); // Hata durumunda callback çağrılıyor
        }
      },
    });
  }

  

}
