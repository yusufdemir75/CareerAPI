import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UsersModule } from './users/users.module';
import { HomeModule } from './home/home.module';
import { AdvertsModule } from './adverts/adverts.module';
import { RegisterModule } from './register/register.module';
import { LoginModule } from './login/login.module';
import { ProfileModule } from './profile/profile.module';
import { CreateProfileModule } from './create-profile/create-profile.module';



@NgModule({
  declarations: [
    
  
  ],
  imports: [
    CommonModule,
    UsersModule,
    HomeModule,
    AdvertsModule,
    RegisterModule,
    LoginModule,
    ProfileModule
    
  ]
})
export class ComponentsModule { }
