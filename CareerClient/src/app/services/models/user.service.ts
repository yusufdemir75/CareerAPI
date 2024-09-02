import { Injectable } from '@angular/core';
import { HttpClientService } from '../common/http-client.service';
import { user } from '../../entities/user';
import { Create_User } from '../../contracts/users/create_user';
import { firstValueFrom, Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private httpClientService: HttpClientService) { 

  }

 async create(user:user): Promise<Create_User> {
   const observable:Observable<Create_User| user> = this.httpClientService.post<Create_User | user>({
      controller:"Users",
    },user);
   return await firstValueFrom(observable) as Create_User
  }


 async login(UsernameOrEmail:string,Password:string):Promise<void>{
   const observable:Observable<any>=   this.httpClientService.post({
        controller:"Users",
        action:"login"
      },{ UsernameOrEmail,Password })

      await firstValueFrom(observable);
  }
}
