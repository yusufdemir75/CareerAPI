import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdvertsComponent } from './adverts.component';
import { RouterModule } from '@angular/router';



@NgModule({
  declarations: [
    AdvertsComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forChild([
      {path:"", component: AdvertsComponent}
    ])
  ]
})
export class AdvertsModule { }
