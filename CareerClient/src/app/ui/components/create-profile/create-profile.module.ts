import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CreateProfileComponent } from './create-profile.component';
import { RouterModule } from '@angular/router';
import { QuillModule } from 'ngx-quill';

@NgModule({
  declarations: [
    CreateProfileComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forChild([
      { path : "", component : CreateProfileComponent}
    ]),
    QuillModule.forRoot()
  ]
})
export class CreateProfileModule { }
