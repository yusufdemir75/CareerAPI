import { Injectable } from '@angular/core';
import { HttpClientService } from '../common/http-client.service';
import { CustomToastrService } from '../ui/custom-toastr.service';
import { applyAdvert } from '../../contracts/adverts/applyAdvert';
import { HttpErrorResponse } from '@angular/common/http';
import { Observable } from 'rxjs';

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
  getApplyAdverts(): Observable<applyAdvert[]> {
    return this.httpClientService.get<applyAdvert[]>({
      controller: 'ApplyAdvert'
    });
  }
}
