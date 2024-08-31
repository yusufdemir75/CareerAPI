import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UsersModule } from './users/users.module';
import { HomeModule } from './home/home.module';
import { AdvertsModule } from './adverts/adverts.module';
import { RegisterComponent } from './register/register.component';
import { RegisterModule } from './register/register.module';



@NgModule({
  declarations: [
    
  ],
  imports: [
    CommonModule,
    UsersModule,
    HomeModule,
    AdvertsModule,
    RegisterModule
  ]
})
export class ComponentsModule { }
