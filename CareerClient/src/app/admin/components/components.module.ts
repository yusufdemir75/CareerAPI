import { ApplicationModule, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdvertsModule } from './adverts/adverts.module';
import { DashboardModule } from './dashboard/dashboard.module';
import { UsersModule } from './users/users.module';




@NgModule({
  declarations: [
  ],
  imports: [
    CommonModule,
    AdvertsModule,
    ApplicationModule,
    DashboardModule,
    UsersModule
  ]
})
export class ComponentsModule { }
