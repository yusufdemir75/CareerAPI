import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LayoutModule } from './layout/layout.module';
import { ComponentsModule } from './components/components.module';
import { ProfileModule } from '../ui/components/profile/profile.module';



@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    LayoutModule,
    ProfileModule,
    ComponentsModule
  ],
  exports :[
    LayoutModule
  ]
})
export class AdminModule { }
