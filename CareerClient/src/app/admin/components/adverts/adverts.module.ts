import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdvertsComponent } from './adverts.component';
import { RouterModule } from '@angular/router';
import {MatSidenavModule} from '@angular/material/sidenav';
import { QuillModule } from 'ngx-quill';
import {MatInputModule} from '@angular/material/input';
import { ReactiveFormsModule } from '@angular/forms';



@NgModule({
  declarations: [
    AdvertsComponent,
    
  ],
  imports: [
    CommonModule,
    RouterModule.forChild([
      { path: "", component: AdvertsComponent}
      
    ]),
    MatSidenavModule,
    QuillModule.forRoot(),
    MatInputModule,
    ReactiveFormsModule
  ]
})
export class AdvertsModule { }
