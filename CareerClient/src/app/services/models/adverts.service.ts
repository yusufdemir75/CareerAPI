import { Injectable } from '@angular/core';
import { HttpClientService } from '../common/http-client.service';
import { advert } from '../../contracts/adverts/advert';
import { CustomToastrService, ToastrMessageType, ToastrPosition } from '../ui/custom-toastr.service';
import { HttpErrorResponse } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AdvertsService {

  constructor(private httpClientService:HttpClientService,private toastrSevice:CustomToastrService) { }
  
  getAdverts(): Observable<advert[]> {
    return this.httpClientService.get<advert[]>({
      controller: 'advert'
    });
  }


  create_advert(advert: advert, successCallBack?: () => void, errorCallBack?: (errorMessage: string) => void) {
    this.httpClientService.post({
      controller: "advert"
    }, advert).subscribe({
      next: result => {
        if (successCallBack) {
          successCallBack();
        }
        alert("Başarılı");
      },
      error: (errorResponse: HttpErrorResponse) => {
        let message = "";
  
        // Hata içeriğini konsola yazdır
        console.log("Error Response:", errorResponse);
  
        // Hata türünü kontrol et
        
        if (Array.isArray(errorResponse.error)) {
          const _error: Array<{ key: string; value: Array<string> }> = errorResponse.error;
          _error.forEach((v) => {
            v.value.forEach((_v) => {
              message += `${_v}<br>`;
              
            });
          });
        } else if (typeof errorResponse.error === 'string') {
          message = errorResponse.error; // Hata mesajı düz metin olarak gelebilir
        } else if (typeof errorResponse.error === 'object') {
          // Eğer hata bir nesne ise, hata detaylarını alalım
          message = JSON.stringify(errorResponse.error);
        } else {
          message = "Bilinmeyen bir hata oluştu.";
        }
  
        if (errorCallBack) {
          errorCallBack(message);
        }
      },
      
    });
  }
  
  

}
