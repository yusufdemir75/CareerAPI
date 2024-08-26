import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ApplicationComponent } from './application.component';
import { RouterModule } from '@angular/router';



@NgModule({
  declarations: [
    ApplicationComponent
  ],
  imports: [
    CommonModule,
    RouterModule.forChild([
    {path:"", component: ApplicationComponent}
    ])
  ]
})
export class ApplicationModule { }
