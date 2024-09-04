import { Injectable } from '@angular/core';
import { HttpClientService } from '../common/http-client.service';
import { user } from '../../entities/user';
import { Create_User } from '../../contracts/users/create_user';
import { firstValueFrom, Observable } from 'rxjs';
import { CustomToastrService, ToastrMessageType, ToastrPosition } from '../ui/custom-toastr.service';
import { tokenResponse } from '../../contracts/Token/tokenResponse';


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
  debugger;
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
}
