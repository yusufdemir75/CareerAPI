import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UsersModule } from './users/users.module';
import { HomeModule } from './home/home.module';
import { AdvertsModule } from './adverts/adverts.module';



@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    UsersModule,
    HomeModule,
    AdvertsModule
  ]
})
export class ComponentsModule { }
