import { Injectable } from '@angular/core';
import { HttpClientService } from '../common/http-client.service';
import { user } from '../../entities/user';
import { Create_User } from '../../contracts/users/create_user';
import { firstValueFrom, Observable } from 'rxjs';
import { CustomToastrService, ToastrMessageType, ToastrPosition } from '../ui/custom-toastr.service';
import { tokenResponse } from '../../contracts/Token/tokenResponse';
import { updateUser } from '../../contracts/users/update_user';
import { profileUser } from '../../contracts/users/profile_user';


@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private httpClientService: HttpClientService, private toastrService:CustomToastrService) { 

  }

 async create(user:user): Promise<Create_User> {
   const observable:Observable<Create_User| user> = this.httpClientService.post<Create_User | user>({
      controller:"Users",
    },user);
   return await firstValueFrom(observable) as Create_User
  }


 async login(UsernameOrEmail: string, Password: string, callBackFunction?: () => void):Promise<any>{
   const observable:Observable<any | tokenResponse> = this.httpClientService.post<any | tokenResponse>({
        controller:"Users",
        action:"login"
      },{ UsernameOrEmail,Password })

    const tokenResponse:tokenResponse = await firstValueFrom(observable) as tokenResponse;
    callBackFunction();

    if (tokenResponse) {
      
      localStorage.setItem("accessToken",tokenResponse.token.accessToken);

      this.toastrService.message("Kullanıcı girişi başarıyla sağlanmıştır.","Giriş Başarılı",ToastrMessageType.Success,ToastrPosition.TopRight)
      
    }
  }
  async updateUser(updateRequest: updateUser): Promise<void> {
    try {
      const observable: Observable<any> = this.httpClientService.put<any>({
        controller: "Users",
        action: "updateUser"
      }, { ...updateRequest });
  
      // Yanıtın düz string olabileceği durumu ele almak
      const response = await firstValueFrom(observable);
  
      // Sunucu yanıtının JSON yerine düz bir mesaj içerdiğini varsayıyoruz
      if (typeof response === 'string') {
        this.toastrService.message(response, "Güncelleme Başarılı", ToastrMessageType.Success, ToastrPosition.TopRight);
      } else {
        this.toastrService.message("Güncelleme işlemi başarılı.", "Başarılı", ToastrMessageType.Success, ToastrPosition.TopRight);
      }
    } catch (error) {
      console.error(error);
    }
  }

   // Kullanıcı rolünü getirmek için yeni metod
   async getUserRole(username: string): Promise<string> {
    const observable: Observable<any> = this.httpClientService.get({
      controller: "Users",
      action: "role"
    }, `${encodeURIComponent(username)}`);

    const response = await firstValueFrom(observable);
    return response.role; 
    }

    async getUser(userName: string): Promise<profileUser> {
      try {
        const observable: Observable<profileUser> = this.httpClientService.get<profileUser>({
          controller: "Users",
        }, `${encodeURIComponent(userName)}`);
  
        return await firstValueFrom(observable);
      } catch (error) {
        console.error('Error fetching user data', error);
        this.toastrService.message("Kullanıcı verilerini alırken bir hata oluştu.", "Hata", ToastrMessageType.Error, ToastrPosition.TopRight);
        throw error;
      }
    }

     
}
