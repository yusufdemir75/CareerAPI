import { Component, NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from './admin/components/dashboard/dashboard.component';
import { LayoutComponent } from './admin/layout/layout.component';
import { AdvertsModule } from './admin/components/adverts/adverts.module';
import { ApplicationModule } from './admin/components/application/application.module';
import { UsersModule } from './admin/components/users/users.module';
import { HomeComponent } from './ui/components/home/home.component';
import { AdvertsComponent } from './ui/components/adverts/adverts.component';
import { UsersComponent } from './ui/components/users/users.component';


const routes: Routes = [
    {path: "admin", component:LayoutComponent,children:[
      {path: "adverts", loadChildren : ()=> import("./admin/components/adverts/adverts.module").then(module => AdvertsModule)},
      {path: "application", loadChildren : ()=> import("./admin/components/application/application.module").then(module => ApplicationModule)},
      {path: "users", loadChildren : ()=> import("./admin/components/users/users.module").then(module => UsersModule)},
      {path: "", component : DashboardComponent}
      
    ]},
    {path: "", component: HomeComponent},
    {path: "adverts", loadChildren:()=> import("./ui/components/adverts/adverts.module").then(module => module.AdvertsModule)},
    {path: "users", loadChildren:()=> import("./ui/components/users/users.module").then(module => module.UsersModule)},

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
