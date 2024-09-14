import { NgModule } from '@angular/core';
import { BrowserModule, provideClientHydration } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AdminModule } from './admin/admin.module';
import { UiModule } from './ui/ui.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { ToastrModule } from 'ngx-toastr';
import { HttpClientModule } from '@angular/common/http';
import { JwtModule } from '@auth0/angular-jwt';
import { ProfileModule } from './ui/components/profile/profile.module';
import { AngularFireModule } from '@angular/fire/compat';
import { AngularFireStorageModule } from '@angular/fire/compat/storage';
import { environment } from '../environments/environment';
@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AngularFireModule.initializeApp(environment.firebaseConfig),
    AngularFireStorageModule,
    AppRoutingModule,
    UiModule,
    ToastrModule.forRoot(),
    HttpClientModule,
    JwtModule.forRoot({
      config:{
        tokenGetter:()=> localStorage.getItem("accessToken"),
        allowedDomains:["localhost:7259"]
      }
    })
  ],
  providers: [
    {provide:"baseUrl", useValue:"https://localhost:7259/api" ,multi: true}
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
