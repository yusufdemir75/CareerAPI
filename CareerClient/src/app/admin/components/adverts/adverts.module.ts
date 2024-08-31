import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdvertsComponent } from './adverts.component';
import { RouterModule } from '@angular/router';
import {MatSidenavModule} from '@angular/material/sidenav';




@NgModule({
  declarations: [
    AdvertsComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forChild([
      { path: "", component: AdvertsComponent}
      
    ]),
    MatSidenavModule
  ]
})
export class AdvertsModule { }
