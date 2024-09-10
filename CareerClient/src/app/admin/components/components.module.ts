import { ApplicationModule, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdvertsModule } from './adverts/adverts.module';
import { UsersModule } from './users/users.module';
import { ProfileModule } from '../../ui/components/profile/profile.module';




@NgModule({
  declarations: [
  ],
  imports: [
    CommonModule,
    AdvertsModule,
    ApplicationModule,
    ProfileModule,
    UsersModule
  ]
})
export class ComponentsModule { }
