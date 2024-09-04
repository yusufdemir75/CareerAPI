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
import { authGuard } from './guards/common/auth.guard';


const routes: Routes = [
    {path: "admin", component:LayoutComponent,children:[
      {path: "adverts", loadChildren : ()=> import("./admin/components/adverts/adverts.module").then(module => AdvertsModule),canActivate:[authGuard]},
      {path: "application", loadChildren : ()=> import("./admin/components/application/application.module").then(module => ApplicationModule) ,canActivate:[authGuard]},
      {path: "users", loadChildren : ()=> import("./admin/components/users/users.module").then(module => UsersModule) ,canActivate:[authGuard]},
      {path: "", component : DashboardComponent ,canActivate:[authGuard]}
      
    ],canActivate:[authGuard]},
    
    {path: "", component: HomeComponent},
    {path: "adverts", loadChildren:()=> import("./ui/components/adverts/adverts.module").then(module => module.AdvertsModule)},
    {path: "register", loadChildren:()=> import("./ui/components/register/register.module").then(module => module.RegisterModule)},
    {path: "login", loadChildren:()=> import("./ui/components/login/login.module").then(module => module.LoginModule)},

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
