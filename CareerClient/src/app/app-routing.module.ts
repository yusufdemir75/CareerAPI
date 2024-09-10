import { Component, NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LayoutComponent } from './admin/layout/layout.component';
import { AdvertsModule } from './admin/components/adverts/adverts.module';
import { ApplicationModule } from './admin/components/application/application.module';
import { UsersModule } from './admin/components/users/users.module';
import { authGuard } from './guards/common/auth.guard';
import { ProfileModule } from './ui/components/profile/profile.module';
import { AdvertsComponent } from './admin/components/adverts/adverts.component';
import { LoginComponent } from './ui/components/login/login.component';
import { roleGuard } from './guards/common/role.guard';


const routes: Routes = [
    {path: "admin", component:LayoutComponent,children:[
      {path: "adverts", loadChildren : ()=> import("./admin/components/adverts/adverts.module").then(module => AdvertsModule),canActivate:[authGuard]},
      {path: "application", loadChildren : ()=> import("./admin/components/application/application.module").then(module => ApplicationModule) ,canActivate:[authGuard]},
      {path: "users", loadChildren : ()=> import("./admin/components/users/users.module").then(module => UsersModule) ,canActivate:[authGuard]},
      {path: "", component : AdvertsComponent ,canActivate:[authGuard]}
      
    ],canActivate:[authGuard]},
    {path: "profile", loadChildren : ()=> import("./ui/components/profile/profile.module").then(module => ProfileModule),canActivate:[roleGuard] },
    {path: "", component: LoginComponent},
    {path: "adverts", loadChildren:()=> import("./ui/components/adverts/adverts.module").then(module => module.AdvertsModule),canActivate:[roleGuard]},
    {path: "register", loadChildren:()=> import("./ui/components/register/register.module").then(module => module.RegisterModule)},
    {path: "login", loadChildren:()=> import("./ui/components/login/login.module").then(module => module.LoginModule)},
    {path: "home", loadChildren:()=> import("./ui/components/home/home.module").then(module => module.HomeModule),canActivate:[roleGuard]},
    {path: "create-profile", loadChildren:()=> import("./ui/components/create-profile/create-profile.module").then(module => module.CreateProfileModule),canActivate:[roleGuard]}

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
