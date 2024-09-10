import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { advertsComponent } from './adverts.component';
import { RouterModule } from '@angular/router';



@NgModule({
  declarations: [
    advertsComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forChild([
      {path:"", component: advertsComponent}
    ])
  ]
})
export class AdvertsModule { }
